using DataGenerator.SQL;
using System.Text;

namespace DataGenerator.CSharp
{
	/// <summary>
	/// 
	/// </summary>
	public class CSDataValueProperty : AbstractCSValueAttribute {
		private CSValueAttribute _valueAttribute;
		public CSDataValueProperty( CSValueAttribute va ) : base(va.Name){
			_valueAttribute = va;
        }

		public override CSValueEnum Type {
			get { return _valueAttribute.Type; }

			set { _valueAttribute.Type = value; }
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			_valueAttribute.Annotations.CreateString(sb, indentation);
			Annotations.CreateString(sb, indentation);
			CodeWriter cw = new CodeWriter(sb, indentation).
				Property(StringType(Type), _valueAttribute.Name,
                    "return Value;",
					"Value = value;");
		}
	}


	/// <summary>
	/// 
	/// </summary>
	public class CSDataValueCollectionReference : CSReferenceClass {
		private CSDataValueReferenceToClass _conteneur;
		public CSDataValueReferenceToClass Conteneur { get { return _conteneur; } }
		public CSDataValueCollectionReference( CSDataValueClass refer, string name ) : base(refer, name) {
			_conteneur = refer.Conteneur;
			Annotations.AddAnnotation(new CSAssociationAnnotation(Name, refer.Conteneur.ReferenceKey.Name));
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			//private IEnumerable<machinsFromCarriereModel> _machins;
			//[Association(ThisKey = "Id",CanBeNull = true,Storage = "machins",OtherKey = "Carriere")]
			//public IEnumerable<machinsFromCarriereModel> machins{
			//	get {
			//		if(_machins == null) {
			//			_machins = LoadFromDataValue<machinsFromCarriereModel, string>();
			//	    }
			//		return _machins;
			//	}
			//	set {
			//		SaveDataValue<machinsFromCarriereModel, string>(_machins,value);
			//	}
			//}
			string valType = StringType(((CSDataValueClass)ReferencedClass).ValueAttribute.Type);
            string privName = "_" + CamelCaseName;
			//string type = "IEnumerable < "+ReferencedClass.Name+" >";
			string type = "IEnumerable < " + valType + " >";
			CodeWriter cs = new CodeWriter(sb, indentation).nl();
			cs.AddIndLine("private "+ type + " " + privName+";");
			Annotations.CreateString(sb, indentation);
			cs.PropertyStart(type, Name).
				GetStart().
					If( privName + " == null",
						privName + " = LoadFromDataValue<" + ReferencedClass.Name + ", " + valType + ">();").nl().
					AddIndLine("return "+privName+";").
				EndBlock().nl().
				SetStart().
					AddIndLine("SaveDataValue<" + ReferencedClass.Name + ", " + valType + ">("+ privName+", value);").
				EndBlock().nl().
			EndBlock();
        }
	}


	/// <summary>
	/// 
	/// </summary>
	public class CSDataValueForeignKey : CSForeignKey {
		public CSDataValueForeignKey( SQLForeignKeyAttribute sfa, string name ) : base(sfa, name) { }

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			//[Column(Name = "fk_carriere", Storage = "CarriereModelId")]
			//public int CarriereModelId {
			//	get { return base.FromId; }
			//	set { base.FromId = value; }
			//}
			Annotations.CreateString(sb, indentation);
			CodeWriter cw = new CodeWriter(sb, indentation).
				Property("int", PublicName,
					"return base.FromId;",
					"base.FromId = value;"
				);
		}
	}


	/// <summary>
	/// 
	/// </summary>
	public class CSDataValueReferenceToClass : CSReferenceToUniqueClass {
		public CSDataValueReferenceToClass( CSClass refer, CSDataValueForeignKey key, string name ) : base(refer, key, name) {
			AddForeignKey(key);
		}

		public override void CreateString( StringBuilder sb, IndentationCount ind ) {
			//[Association(ThisKey = "CarriereModelId", OtherKey = "Id", CanBeNull = false, Storage = "Carriere")]
			//public CarriereModel Carriere {
			//	get { return From; }
			//	set { From = value; }
			//}
			CodeWriter cw = new CodeWriter(sb, ind).nl().
				Property(ReferencedClass.Name, PascalCaseName,
					"return From;",
					"From = value;"
				);
		}
	}

}
