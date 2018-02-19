using System;
using System.Text;

namespace DataGenerator.CSharp {
	public interface IWriteCsAttribute<A> where A : CSReferenceAttribute {
		void WriteManyToMany( StringBuilder sb, A att, IndentationCount ind );
		void WriteManyToOne( StringBuilder sb, A att, IndentationCount ind );
		void WriteOneToMany( StringBuilder sb, A att, IndentationCount ind );
		void WriteOneToOne( StringBuilder sb, A att, IndentationCount ind );
		void WriteCollectionReference( StringBuilder sb, A att, IndentationCount ind );
		void WriteSimpleReference( StringBuilder sb, A att, IndentationCount ind );
	}
	public class DefaultAttributeWriter : IWriteCsAttribute<CSReferenceAttribute> {
		public  void WriteManyToMany( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			throw new NotImplementedException();
		}
		 
		public  void WriteManyToOne( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			throw new NotImplementedException();
		}
		 
		public  void WriteOneToMany( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			string className = att.ReferencedClass.Name;
			//membre privé
			sb.AppendFormat("\tprivate IEnumerable<{0}> _{1};\n", className, att.Name);
			//attribut
			att.Annotations.CreateString(sb, ind);
			//propriété
			sb.AppendFormat("\tpublic IEnumerable<{0}> {1}", className, att.Name);
			sb.Append(" {");
			//getset
			sb.AppendFormat(@"
		get {0}
			if(_{2} == null) {0}
				_{2} = LoadByForeignKey<{3}>(p => p.{4}Id, Id);
            {1}
			return _{2};
		{1}
		set {0}
			foreach({3} item in _{2}) {0}
				item.{4} = null;
			{1}
			_{2} = value;
			foreach({3} item in value) {0}
				item.{4} = this;
			{1}
		{1}", "{", "}", att.Name, className, att.ReferencedAttribute.Name);
			//fermeture propriété
			sb.Append("\n\t}\n");
		}
		 
		public  void WriteOneToOne( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
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
			string privNameAtt = "_" + att.Name;
			sb.AppendFormat("private {0} {1};\n", att.ReferencedClass.Name, privNameAtt);
			att.Annotations.CreateString(sb, ind);
			sb.AppendLine();
			sb.AppendFormat(
@"public {2} {5} {0}
	get {0} return {3}; {1}
	set {0}
		if({3} == value) {0} return; {1}
		if({3} != null) {0}
			{3}.{4} = null;
		{1}
		{3} = value;
		{3}.{4} = this;
	{1}
{1}", "{", "}", att.ReferencedClass.Name, privNameAtt, att.ReferencedAttribute.Name, att.Name);
		}
		 
		public  void WriteCollectionReference( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			string privateAttName = "_" + att.Name;
			string typeName = att.ReferencedClass.Name;
			//private member
			sb.AppendFormat("\tprivate IEnumerable<{0}> {1};\n", typeName, privateAttName);
			//annotations
			att.Annotations.CreateString(sb, ind);
			//public property : get,set
			sb.AppendFormat("\tpublic IEnumerable<{0}> {1}", typeName, att.Name);
			sb.Append("{\n\t\tget{ ");
			sb.AppendFormat("return {0};", privateAttName);
			sb.Append(" }\n\t\tset{");
			sb.AppendFormat(" {0}.Assign( value );", privateAttName);
			sb.Append(" }\n\t}");
		}
		 
		public  void WriteSimpleReference( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			string privateAttName = "_" + att.Name;
			string typeName = att.ReferencedClass.Name;
			//private member
			sb.AppendFormat("\tprivate {0} {1};\n", typeName, privateAttName);
			//annotations
			att.Annotations.CreateString(sb, ind);
			//public property : get,set
			sb.AppendFormat("\tpublic {0} {1}", typeName, att.Name);
			sb.Append("{\n\t\tget{ ");
			sb.AppendFormat("return {0};", privateAttName);
			sb.Append(" }\n\t\tset{");
			sb.AppendFormat(" {0} = value;", privateAttName);
			sb.Append(" }\n\t}");
		}
	}

	public class DataObjectAttributeWriter : IWriteCsAttribute<CSReferenceAttribute> {
		private static int mo, om, oo, cr, sr;
        public void WriteManyToMany( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			throw new NotImplementedException("You shall not use ManyToMany!!");
			//sb.AppendFormat("\tprivate IEnumerable<{0}> _{1};\n", da.CsJointClass, da.Name);
			//sb.AppendFormat(
			//	"\t[Association(ThisKey = \"Id\", OtherKey = \"{0}Id\", CanBeNull = {1}, Storage=\"{2}\")]\n",
			//	da.ReferencedAttribute.PascalName,
			//	da.IsOptionnal ? "true" : "false",
			//	da.PascalName
			//);
			//sb.AppendFormat("\tpublic IEnumerable<{0}> {1}Rel", da.CsJointClass, Pascalise(da.Name));
			//sb.Append(" {\n");
			//sb.Append("\t\tget { return _" + da.Name + "; }\n\t\tset { _" + da.Name + " = value ; }\n");
			//sb.Append("\t}\n");
			//string className = da.Type.ReferencedTable.CsClassName;
			//sb.AppendFormat("\tpublic IEnumerable<{0}> {1}", className, Pascalise(da.Name));
			//sb.Append(" {\n");
			//sb.Append("\t\tget { return _" + da.Name + ".Select(p=>p." + da.Type.ReferencedTable.PascalName + "); }\n");
			//sb.Append("\t}\n");
		}

		public void WriteManyToOne( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			string className = att.ReferencedClass.Name;mo++;
			string privateName = "_" + att.CamelCaseName;
			sb.AppendLine(ind+"private "+ className+" "+ privateName+";");
			att.Annotations.CreateString(sb, ind);
			//Propriété
			sb.AppendLine(ind+"public "+ className+" "+ att.Name+"{");
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
{5}	{1}", "{", "}", privateName, att.Name, className, ind);
			sb.AppendLine();
			sb.Append(ind + "}");
		}

		public void WriteOneToMany( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			string className = att.ReferencedClass.Name;om++;
			string privateName = "_" + att.Name;
			//membre privé
			sb.AppendLine(ind + "private IEnumerable<"+ className +"> "+ privateName+";");
			//attribut
			att.Annotations.CreateString(sb, ind);
			//propriété
			sb.AppendLine(ind + "public IEnumerable<" + className + "> " + att.Name + "{");
			//getset
			ind.Count++;
			sb.AppendFormat(
@"{5}get {0}
{5}	if(_{2} == null) {0}
{5}		_{2} = LoadByForeignKey<{3}>(p => p.{4}Id, Id);
{5}    {1}
{5}	return _{2};
{5}{1}
{5}set {0}
{5}	foreach({3} item in _{2}) {0}
{5}		item.{4} = null;
{5}	{1}
{5}	_{2} = value;
{5}	foreach({3} item in value) {0}
{5}		item.{4} = this;
{5}	{1}
{5}{1}", "{", "}", att.Name, className, att.ReferencedAttribute.Name, ind);
			ind.Count--;
			sb.AppendLine();
			sb.Append(ind+"}\n");
		}

		public void WriteOneToOne( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
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
			string privNameAtt = "_" + att.Name;oo++;
			sb.AppendLine(ind + "private " + att.ReferencedClass.Name + " " + privNameAtt + ";");
			att.Annotations.CreateString(sb, ind);
			sb.AppendLine();
			sb.AppendFormat(
@"{6}public {2} {5} {0}
{6}	get {0} return {3}; {1}
{6}	set {0}
{6}		if({3} == value) {0} return; {1}
{6}		if({3} != null) {0}
{6}			{3}.{4} = null;
{6}		{1}
{6}		{3} = value;
{6}		{3}.{4} = this;
{6}	{1}
{6}{1}", "{", "}", att.ReferencedClass.Name, privNameAtt, att.ReferencedAttribute.Name, att.Name, ind);
		}

		public void WriteCollectionReference( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
			cr++;
			throw new NotImplementedException("Should not be used because references colections are linked one to many with an indirection table.");
			//string privateAttName = "_" + att.Name;
			//string typeName = att.ReferencedClass.Name;
			////private member
			//sb.AppendLine(ind + "private IEnumerable<" + typeName + "> " + privateAttName + ";");
			////annotations
			//att.Annotations.CreateString(sb, ind);
			////public property : get,set
			//sb.AppendLine(ind + "public IEnumerable<" + typeName + "> " + att.Name + "{");
			//sb.AppendLine(ind + "\tget{ return " + privateAttName + ";}");
			//sb.AppendLine(ind + "\tset{ " + privateAttName + ".Assign( value );}");
			//sb.Append(ind + "}");
		}

		public void WriteSimpleReference( StringBuilder sb, CSReferenceAttribute att, IndentationCount ind ) {
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
			string privateAttName = "_" + att.Name;sr++;
			string typeName = att.ReferencedClass.Name;
			string IdProperty = att.Name + "Id";
			//private member
			sb.AppendLine(ind + "private " + typeName + " " + privateAttName + ";");
			//annotations
			att.Annotations.CreateString(sb, ind);
			//public property : get,set
			sb.AppendLine(ind + "public " + typeName + " " + att.Name + "{");
			sb.AppendLine(ind + "\tget{");
			sb.AppendLine(ind + "\t\tif( "+privateAttName+" == null)");
			sb.AppendLine(ind + "\t\t\t" + privateAttName + " = LoadById<"+ typeName + ">("+ IdProperty + ");");
			sb.AppendLine(ind + "\t\treturn " + privateAttName + ";");
            sb.AppendLine(ind + "\t} set {");
			sb.AppendLine(ind + "\t\tif(" + privateAttName + " == value){return;}");
            sb.AppendLine(ind + "\t\t" + privateAttName + " = value;");
			sb.AppendLine(ind + "\t\tif( value != null)");
			sb.AppendLine(ind + "\t\t\t" + IdProperty + " = value.Id;");
            sb.AppendLine(ind + "\t}");
			sb.Append(ind + "}");
		}
	}
}