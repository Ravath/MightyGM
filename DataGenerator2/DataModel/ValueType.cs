using DataGenerator2.Parser;
using System;

namespace DataGenerator2.DataModel {
	public enum AttributeTypeEnum {
		Int, Text, Varchar, Bool, Enum, Real, Decimal, Refex, Ref, Range, Time, Distance
	}
	public class EnumType : ValueType {
		public EnumTable EnumReference { get; private set; }
		public EnumType( string typeName, EnumTable enumName ) : base(typeName) {
			EnumReference = enumName;
		}
	}
	public class StringType : ValueType {
		public int Length { get; set; }
		public StringType( string typeName, int length ) : base(typeName) {
			Length = length;
		}
	}
	public class ReferenceType : ValueType {
		public bool ReferencesExemplar { get; set; }
		public AbsTable ReferencedTable { get; set; }
		public ValueAttribute ReferencedAttribute { get; set; }
		public ReferenceType( string typeName, AbsTable refTable ) : base(typeName) {
			ReferencedTable = refTable;
		}
	}
	public class ValueType{
		#region Properties
		public AttributeTypeEnum Type { get; set; }
		public bool Nullable { get; set; }
		#endregion

		#region Init
		public ValueType( string typeName ) {
			string tn = char.ToUpper(typeName[0]) + typeName.Substring(1);
			Type = (AttributeTypeEnum)Enum.Parse(typeof(AttributeTypeEnum), tn);
		}
		/// <summary>
		/// Constructeur par copie
		/// </summary>
		/// <param name="ta">ValueType à copier.</param>
		public ValueType( ValueType ta ) {
			Type = ta.Type;
		}
		#endregion
		/// <summary>
		/// Convertit un type de valeur (cad attributs de StructTable, DataTable,...) en sa version plus raffinée.
		/// </summary>
		/// <param name="rt">Le rawType à convertir</param>
		/// <param name="dic">La liste des tables déjà créées afin de faire les liaisons des référénces.</param>
		/// <returns></returns>
		public static ValueType ConvertToType( RawAttribute rt, DetailedTables dic ) {
			string type = rt.Type.ToLower();
			if(string.IsNullOrWhiteSpace(type))
				return null;
			switch(type) {
				case "int":
				case "bool":
				case "text":
				case "real":
				case "decimal":
				case "range":
				case "time":
				case "distance":
				return new ValueType(type);
				case "varchar":
				{
					int length;
					if(int.TryParse(rt.TypeTag, out length))
						return new StringType(type, length);
					ErrorManager.Error("varchar " + type + " must have a integer length.");
					return null;
				}
				case "ref":
				return new ReferenceType(type, dic.FindTable(rt.TypeTag));
				case "refex":
				return new ReferenceType(type, dic.FindTable(rt.TypeTag)){ ReferencesExemplar = true };
				case "enum":
				return new EnumType(type, (EnumTable)dic.FindTable(rt.TypeTag));
				default:
				ErrorManager.Error("The type " + type + " doesn't exist.");
				return null;
			}
		}

	}
}