using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator2.SQL;
using DataGenerator2.DataModel;

namespace DataGenerator2.CSharp {
	public enum CSValueEnum {
		Int, Float, Decimal, Double, String, Bool
	}

	public abstract class CSAttribute {
		#region members
		private string _name;
		private CSClass _class;
		private CSAnnotationCollection _annotations = new CSAnnotationCollection();
		#endregion

		#region Properties
		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		public string CamelCaseName {
			get {
				return _name[0].ToString().ToLower() + _name.Substring(1);
			}
		}
		public string PascalCaseName {
			get {
				return _name[0].ToString().ToUpper() + _name.Substring(1);
			}
		}
		public CSAnnotationCollection Annotations { get { return _annotations; } }
		public CSClass Class {
			get {
				return _class;
			}
			set {
				if(_class == value) { return; }
				if(_class != null) {
					_class.RemoveAttribute(this);
				}
				_class = value;
				_class.AddAttribute(this);
			}
		}
		/// <summary>
		/// Indique que la valeur peut être nulle. (optionnelle)
		/// </summary>
		public bool IsNullable { get; set; }
		/// <summary>
		/// Indique qu'il s'agit d'une collection de valeurs.
		/// </summary>
		public bool IsCollection { get; set; }
		#endregion

		#region Init
		public CSAttribute( string name ) { Name = name; }
		public CSAttribute( ValueAttribute att ) {
			Name = att.Name;
			IsNullable = att.CardMin == Number.Opt;
			IsCollection = att.CardMax == Number.Many;
			if(att.Type.Type == AttributeTypeEnum.Text)
				Annotations.AddAnnotation("LargeText");
		}
		#endregion

		public void AddRelationToSQLAttribute( SQLAttribute sa ) {
			Annotations.AddAnnotation(new CSColumnAnnotation(Name, sa.Name));
		}

		public static CSValueEnum ConvertAttributeType( AttributeTypeEnum t ) {
			switch(t) {
				case AttributeTypeEnum.Int: return CSValueEnum.Int;
				case AttributeTypeEnum.Text:
				return CSValueEnum.String;
				case AttributeTypeEnum.Varchar:
				return CSValueEnum.String;
				case AttributeTypeEnum.Bool:
				return CSValueEnum.Bool;
				case AttributeTypeEnum.Enum:
				return CSValueEnum.Int;
				case AttributeTypeEnum.Real:
				return CSValueEnum.Double;
				case AttributeTypeEnum.Decimal:
				return CSValueEnum.Decimal;
				case AttributeTypeEnum.Refex:
				return CSValueEnum.Int;
				case AttributeTypeEnum.Ref:
				return CSValueEnum.Int;
				default:
				return CSValueEnum.Int;
			}
		}

		public abstract void CreateString( StringBuilder sb, IndentationCount indentation );

		protected virtual string StringType( CSValueEnum type ) {
			switch(type) {
				case CSValueEnum.Int:
				return "int";
				case CSValueEnum.Float:
				return "float";
				case CSValueEnum.Decimal:
				return "decimal";
				case CSValueEnum.Double:
				return "double";
				case CSValueEnum.String:
				return "string";
				case CSValueEnum.Bool:
				return "bool";
				default:
				return "TypeNotFound";
			}
		}
	}

	public abstract class AbstractCSValueAttribute : CSAttribute {
		public AbstractCSValueAttribute( string name ) : base(name) { }
		public AbstractCSValueAttribute( ValueAttribute att ) : base(att) { }
		public abstract CSValueEnum Type {
			get; set;
		}

	}
	/// <summary>
	 /// A property of basic type.
	 /// </summary>
	public class CSValueAttribute : AbstractCSValueAttribute {

		#region Members
		private CSValueEnum _type;
		#endregion

		#region Properties
		public override CSValueEnum Type {
			get { return _type; }
			set { _type = value; }
		}
		#endregion

		#region Init
		public CSValueAttribute( string name ) : base(name) { }
		public CSValueAttribute( ValueAttribute att ) : base(att) {
			Type = ConvertAttributeType(att.Type.Type);
		}
		#endregion

		#region String Generation
		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			if(IsCollection) {
				WriteMultipleValues(sb, indentation);
			} else {
				WriteSimpleValue(sb, indentation);
			}
		}
		private void WriteSimpleValue( StringBuilder sb, IndentationCount indentation ) {
			string privateAttName = "_" + CamelCaseName;
			string typeName = StringType(Type);
			if(IsNullable)
				typeName += "?";
			//private member
			if(this.Type == CSValueEnum.String && !IsNullable)
				sb.AppendLine(indentation + "private " + typeName + " " + privateAttName + " = \"\";");
			else
				sb.AppendLine(indentation + "private " + typeName + " " + privateAttName + ";");

			//annotations
			Annotations.CreateString(sb, indentation);
			//public property : get,set
			sb.AppendLine(indentation + "public " + typeName + " " + Name + "{");
			sb.AppendLine(indentation + "\tget{ return " + privateAttName + ";}");
			sb.AppendLine(indentation + "\tset{" + privateAttName + " = value;}");
			sb.Append(indentation + "}");
		}
		private void WriteMultipleValues( StringBuilder sb, IndentationCount indentation ) {
			string privateAttName = "_" + CamelCaseName;
			string typeName = StringType(Type);
			//private member
			sb.AppendLine(indentation + "private IEnumerable<" + typeName + "> " + privateAttName + ";");
			//annotations
			Annotations.CreateString(sb, indentation);
			//public property : get,set
			sb.AppendLine(indentation + "public IEnumerable<" + typeName + "> " + Name + "{");
			sb.AppendLine(indentation + "\tget{ return " + privateAttName + ";}");
			sb.AppendLine(indentation + "\tset{ " + privateAttName + ".Assign( value );}");
			sb.Append(indentation + "}");
		}
		#endregion
	}
	/// <summary>
	/// Specific CSValueAttribute for Enumerations.
	/// </summary>
	public class CSEnumAttribute : CSValueAttribute {
		public CSEnum Enumeration { get; set; }
		public CSEnumAttribute( string name ) : base(name) { }
		public CSEnumAttribute( ValueAttribute vat, CSEnum enumeration ) : base(vat) {
			Enumeration = enumeration;
		}

		protected override string StringType( CSValueEnum type ) {
			return Enumeration.Name;
		}
	}
	/// <summary>
	/// A reference to a class
	/// </summary>
	public abstract class CSReferenceClass : CSAttribute {
		#region Members
		private CSClass _class;
		#endregion

		#region Properties
		public CSClass ReferencedClass {
			get { return _class; }
			set { _class = value; }
		}
		#endregion

		#region Init
		public CSReferenceClass( CSClass reference, string name ) : base(name) {
			ReferencedClass = reference;
		}
		#endregion

		public void AddForeignKey( CSForeignKey csk ) {
			Annotations.AddAnnotation(new CSAssociationAnnotation(csk.PublicName, Name, "Id", false));
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public class CSReferenceToUniqueClass : CSReferenceClass {
		#region Members
		private CSForeignKey _key;
		#endregion
		#region Properties
		public CSForeignKey ReferenceKey {
			get { return _key; }
			private set { _key = value; }
		}
		#endregion
		#region Init
		public CSReferenceToUniqueClass( CSClass refer, CSForeignKey key, string name ) : base(refer, name) {
			ReferenceKey = key;
		}

		public override void CreateString( StringBuilder sb, IndentationCount ind ) {
			//get {
			//	if(_Carriere == null)
			//		_Carriere = LoadById<CarriereModel>(CarriereId);
			//	return _Carriere;
			//}
			//set {
			//	if(_Carriere == value) { return; }
			//	_Carriere = value;
			//	CarriereId = value.Id;
			//}
			string privateAttName = "_" + CamelCaseName;
			string typeName = ReferencedClass.Name;
			string IdProperty = ReferenceKey.PublicName;
			//private member
			sb.AppendLine(ind + "private " + typeName + " " + privateAttName + ";");
			//annotations
			Annotations.CreateString(sb, ind);
			//public property : get,set
			sb.AppendLine(ind + "public " + typeName + " " + PascalCaseName + "{");
			sb.AppendLine(ind + "\tget{");
			sb.AppendLine(ind + "\t\tif( " + privateAttName + " == null)");
			sb.AppendLine(ind + "\t\t\t" + privateAttName + " = LoadById<" + typeName + ">(" + IdProperty + ");");
			sb.AppendLine(ind + "\t\treturn " + privateAttName + ";");
			sb.AppendLine(ind + "\t} set {");
			sb.AppendLine(ind + "\t\tif(" + privateAttName + " == value){return;}");
			sb.AppendLine(ind + "\t\t" + privateAttName + " = value;");
			sb.AppendLine(ind + "\t\tif( value != null)");
			sb.AppendLine(ind + "\t\t\t" + IdProperty + " = value.Id;");
			sb.AppendLine(ind + "\t}");
			sb.Append(ind + "}");
		}
		#endregion
	}
	/// <summary>
	/// 
	/// </summary>
	public abstract class CSReferenceAttribute : CSReferenceClass {
		#region Members
		private CSReferenceAttribute _attribute;
		#endregion

		#region Properties
		public CSReferenceAttribute ReferencedAttribute {
			get { return _attribute; }
			set {
				if(_attribute == value) { return; }
				if(_attribute != null) {
					_attribute.ReferencedAttribute = null;
					//if(_attribute.ReferencedAttribute != null) {
					//	CSReferenceAttribute temp = _attribute;
					//	_attribute = null;
					//                   temp.ReferencedAttribute = null;
					//}
				}
				if(value != null) {
					_attribute = value;
					_attribute.ReferencedAttribute = this;
				}
			}
		}
		//public bool OneToOne {
		//	get {
		//		if(ReferencedAttribute == null) { return false; }
		//		return !IsCollection && !ReferencedAttribute.IsCollection; }
		//}
		//public bool OneToMany {
		//	get {
		//		if(ReferencedAttribute == null) { return false; }
		//		return IsCollection && !ReferencedAttribute.IsCollection; }
		//}
		//public bool ManyToOne {
		//	get {
		//		if(ReferencedAttribute == null) { return false; }
		//		return !IsCollection && ReferencedAttribute.IsCollection; }
		//}
		//public bool ManyToMany {
		//	get {
		//		if(ReferencedAttribute == null) { return false; }
		//		return IsCollection && ReferencedAttribute.IsCollection; }
		//}
		//public IWriteCsAttribute<CSReferenceAttribute> AttributeWriter { get; set; }
		#endregion

		#region Init
		/// <summary>
		/// Constructeur sans CSReferenceAttribute pour pouvoir les créer sans le mordre la queue.
		/// </summary>
		/// <param name="refer"></param>
		public CSReferenceAttribute( CSClass refer, string name ) : base(refer, name) { }
		public CSReferenceAttribute( CSClass refer, CSReferenceAttribute att ) : base(refer, refer.Name) {
			ReferencedAttribute = att;
		}
		#endregion
	}
	/// <summary>
	/// 
	/// </summary>
	public class CSOneToOne : CSReferenceAttribute {
		public CSOneToOne( CSClass refer, string name ) : base(refer, name) { }
		public override void CreateString( StringBuilder sb, IndentationCount ind ) {
			string className = ReferencedClass.Name;
			string privateName = "_" + CamelCaseName;
			sb.AppendLine(ind + "private " + className + " " + privateName + ";");
			Annotations.CreateString(sb, ind);
			//Propriété
			sb.AppendLine(ind + "public " + className + " " + PascalCaseName + "{");
			//TODO ajouter une relation dans le cas OneToOne
			sb.AppendFormat(
@"{5}	get {0}
{5}		if({2} == null) {0}
{5}			{2} = LoadById<{4}>({3}Id);
{5}	       {1}
{5}		return {2};
{5}	{1} set {0}
{5}		if(value == {2}) {0} return; {1}
{5}		{2} = value;
{5}		if({2} != null) {0}
{5}			{2}Id = {2}.Id;
{5}		{1} else {0}
{5}			{2}Id = 0;
{5}		{1}
{5}	{1}", "{", "}", privateName, PascalCaseName, className, ind);
			sb.AppendLine();
			sb.Append(ind + "}");
			////Ancient formula
			//private Type privNameAtt
			//public Type NameAtt {
			//	get { return privNameAtt; }
			//	set {
			//		if(privNameAtt == value) { return; }
			//		if(privNameAtt != null) {
			//			privNameAtt.invAtt = null;
			//		}
			//		privNameAtt = value;
			//		privNameAtt.invAtt = this;
			//	}
			//}
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public class CSOneToMany : CSReferenceAttribute {

		public CSOneToMany( CSClass refer, string name ) : base(refer, name) { }
		public override void CreateString( StringBuilder sb, IndentationCount ind ) {
			string className = ReferencedClass.Name;
			string privateName = "_" + CamelCaseName;
			//membre privé
			sb.AppendLine(ind + "private IEnumerable<" + className + "> " + privateName + ";");
			//attribut
			Annotations.CreateString(sb, ind);
			//propriété
			CodeWriter cs = new CodeWriter(sb, ind).
				PropertyStart("IEnumerable <" + className + ">", PascalCaseName).
					GetStart().
						If(privateName + " == null",
							privateName + " = LoadByForeignKey<" + className + ">(p => p." + ReferencedAttribute.Name + "Id, Id);").nl().
						AddIndLine("return " + privateName + ";").
					EndBlock().nl().
					SetStart().
						Foreach(className + " item in " + privateName,
							"item." + ReferencedAttribute.Name + " = null;").
						AddIndLine(privateName + " = value;").
						ForeachStart(className + " item in value").
							AddIndLine("item." + ReferencedAttribute.Name + " = this;").
							AddIndLine("item.SaveObject();").
						EndBlock().nl().
			EndBlock().nl().
			EndBlock();
		}
	}

	public class CSOneToManyJoint : CSOneToMany {
		public bool FromLeft { get; set; }
		public CSClass Joint { get; set; }//la classe de la table de jointure
		public CSOneToManyJoint( CSClass refer, string name ) : base(refer, name) {}
		public override void CreateString( StringBuilder sb, IndentationCount ind ) {
			string className = ReferencedClass.Name;
			string privateName = "_" + CamelCaseName;
			string left = !FromLeft ? "true" : "false";
			//membre privé
			sb.AppendLine(ind + "private IEnumerable<" + className + "> " + privateName + ";");
			//attribut
			Annotations.CreateString(sb, ind);
			//propriété
			CodeWriter cs = new CodeWriter(sb, ind).
				PropertyStart("IEnumerable <" + className + ">", PascalCaseName).
					GetStart().
						If(privateName + " == null",
							privateName + " = LoadFromJointure<" + className + "," + Joint.Name + ">(" + left + ");").nl().
						AddIndLine("return " + privateName + ";").
					EndBlock().nl().
					SetStart().
						AddIndLine("SaveToJointure<"+ className+", "+ Joint.Name +"> (" + privateName + ", value," + left + ");").
						AddIndLine(privateName + " = value;").
					EndBlock().nl().
				EndBlock();
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public class CSManyToOne : CSReferenceAttribute {
		public CSManyToOne( CSClass refer, string name ) : base(refer, name) {
		}
		public override void CreateString( StringBuilder sb, IndentationCount ind ) {
			string className = ReferencedClass.Name;
			string privateName = "_" + CamelCaseName;
			sb.AppendLine(ind + "private " + className + " " + privateName + ";");
			Annotations.CreateString(sb, ind);
			//Propriété
			sb.AppendLine(ind + "public " + className + " " + PascalCaseName + "{");
			//TODO ajouter une relation dans cas OneToOne
			sb.AppendFormat(
@"{5}	get {0}
{5}		if({2} == null) {0}
{5}			{2} = LoadById<{4}>({3}Id);
{5}	       {1}
{5}		return {2};
{5}	{1} set {0}
{5}		if(value == {2}) {0} return; {1}
{5}		{2} = value;
{5}		if({2} != null) {0}
{5}			{2}Id = {2}.Id;
{5}		{1} else {0}
{5}			{2}Id = 0;
{5}		{1}
{5}	{1}", "{", "}", privateName, PascalCaseName, className, ind);
			sb.AppendLine();
			sb.Append(ind + "}");
		}
	}
	/// <summary>
	/// Les propriétés d'une classe héritant de DataRelation.
	/// </summary>
	public class CSDataRelationAttribute : CSReferenceAttribute {
			/// <summary>
			/// Indique si il s'agit des propriétés d'Objet1 ou de l'Objet2 de la classe DataRelation.
			/// </summary>
			public int NumObject { get; }
			public SQLForeignKeyAttribute SQLKey { get; }
			public string PublicIdName { get { return Name + "Id"; } }

			internal CSDataRelationAttribute( CSClass refer, SQLForeignKeyAttribute key, int num ) : base(refer, refer.Name) {
				Name = refer.Name;
				SQLKey = key;
				NumObject = num;
			}

			public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
				string publicName = Name;
				string objectName = "Object" + NumObject.ToString();
				string objectType = ReferencedClass.Name;
				sb.AppendLine(indentation + "[Column(Name = \"" + SQLKey.Name + "\", Storage = \"" + PublicIdName + "\")]");
				sb.AppendLine(indentation + "[HiddenProperty]");
				sb.AppendLine(indentation + "public int " + PublicIdName + " {");
				sb.AppendLine(indentation + "	get { return " + objectName + "Id; }");
				sb.AppendLine(indentation + "	set { " + objectName + "Id= value; }");
				sb.AppendLine(indentation + "}");
				sb.AppendLine(indentation + "[Association(ThisKey = \"" + PublicIdName + "\", OtherKey = \"Id\", CanBeNull = false, Storage = \"" + publicName + "\")]");
				sb.AppendLine(indentation + "public " + objectType + " " + publicName + " {");
				sb.AppendLine(indentation + "	get { return " + objectName + "; }");
				sb.AppendLine(indentation + "	set { " + objectName + " = value; }");
				sb.Append(indentation + "}");
			}
		}
	/// <summary>
	/// 
	/// </summary>
	public class CSDescriptionAttribute : CSReferenceClass {

		#region Init
		public CSDescriptionAttribute( CSClass reference, string name ) : base(reference, name) { }
		#endregion

		public override void CreateString( StringBuilder sb, IndentationCount ind ) {
			//private ObjectDescription _obj;
			//public override IDataDescription Description {
			//	get {
			//		if(_obj == null) {
			//			IEnumerable<ObjectDescription> id = GetModelReferencer<ObjectDescription>();
			//			if(id.Count() == 0) {
			//				_obj = new ObjectDescription();
			//				_obj.Model = this;
			//				_obj.SaveObject();
			//				return _obj;
			//			} else {
			//				return id.ElementAt(0);
			//			}
			//		} else {
			//			return _obj;
			//		}
			//	}
			//}
			CodeWriter cw = new CodeWriter(sb, ind).
				AddIndLine("private " + ReferencedClass.Name + " _obj;");
			Annotations.CreateString(sb, ind);
			cw.PropertyStart("override IDataDescription", "Description").
				GetStart().
					AddIndLine("if(_obj == null){").t().
					AddIndLine("IEnumerable<"+ReferencedClass.Name+ "> id = GetModelReferencer<" + ReferencedClass.Name + ">();").
					AddIndLine("if(id.Count() == 0) {").t().
					AddIndLine("_obj = new " + ReferencedClass.Name + "();").ut().ut().
					AddBlock(
@"		_obj.Model = this;
		_obj.SaveObject();
		return _obj;
	} else {
		return id.ElementAt(0);
	}
} else {
	return _obj;
}
").
				EndBlock().nl().
			EndBlock();
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public class CSForeignKey : CSAttribute {
		private SQLForeignKeyAttribute sqlKey;
		#region Properties
		public string SqlName {
			get {
				return sqlKey.Name;
			}
		}
		public string PrivateName {
			get {
				return "_" + CamelCaseName + "Id";
			}
		}
		public string PublicName {
			get {
				return PascalCaseName + "Id";
			}
		}
		#endregion

		public CSForeignKey( SQLForeignKeyAttribute sfa, string name ) : base(name) {
			sqlKey = sfa;
			Annotations.AddAnnotation(new CSColumnAnnotation(PublicName, sqlKey.Name));
			Annotations.AddAnnotation(new CSAnnotation("HiddenProperty"));
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			sb.AppendLine(indentation + "private int " + PrivateName + ";");
			Annotations.CreateString(sb, indentation);
			sb.AppendLine(indentation + "public int " + PublicName + "{");
			sb.AppendLine(indentation + "\tget{ return " + PrivateName + ";}");
			sb.AppendLine(indentation + "\tset{" + PrivateName + " = value;}");
			sb.Append(indentation + "}");
		}
	}
}
