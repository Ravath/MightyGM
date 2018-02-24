using DataGenerator.CSharp;
using DataGenerator.SQL;

namespace DataGenerator.DataModel.Model
{
	/// <summary>
	/// Base Class of DataObject Attributes managing only one plain value.
	/// </summary>
	public abstract class DataObjectSimpleAttribute : AbsDataStructAttribute
	{
		public DataObjectSimpleAttribute(string name) : base(name) { }
		protected abstract CSValueAttribute GetSimpleAttribute(Generation generation, CSClass cs);
		protected override CSAttribute GeneratedSpecific(Generation generation, CSClass cs)
		{
			CSValueAttribute result = GetSimpleAttribute(generation, cs);
			SQLAttribute sqlAtt = new SQLAttribute(this, GetSqlType());
			result.AddRelationToSQLAttribute(sqlAtt);
			return result;
		}
	}


	public class DataObjectIntAttribute : DataObjectSimpleAttribute
	{
		public DataObjectIntAttribute(string name) : base(name) { TypeName = "int"; }

		protected override CSValueAttribute GetSimpleAttribute(Generation generation, CSClass cs)
		{
			return new CSValueAttribute(this) { Type = CSValueEnum.Int };
		}

		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Int; }
	}


	public class DataObjectDecimalAttribute : DataObjectSimpleAttribute
	{
		public DataObjectDecimalAttribute(string name) : base(name) { TypeName = "decimal"; }

		protected override CSValueAttribute GetSimpleAttribute(Generation generation, CSClass cs)
		{
			return new CSValueAttribute(this) { Type = CSValueEnum.Decimal };
		}
		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Deci; }
	}


	public class DataObjectRealAttribute : DataObjectSimpleAttribute
	{
		public DataObjectRealAttribute(string name) : base(name) { TypeName = "real"; }

		protected override CSValueAttribute GetSimpleAttribute(Generation generation, CSClass cs)
		{
			return new CSValueAttribute(this) { Type = CSValueEnum.Double };
		}
		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Real; }
	}


	public class DataObjectBooleanAttribute : DataObjectSimpleAttribute
	{
		public DataObjectBooleanAttribute(string name) : base(name) { TypeName = "bool"; }
		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Bool; }

		protected override CSValueAttribute GetSimpleAttribute(Generation generation, CSClass cs)
		{
			return new CSValueAttribute(this) { Type = CSValueEnum.Bool };
		}
	}


	public class DataObjectTextAttribute : DataObjectSimpleAttribute
	{
		public DataObjectTextAttribute(string name) : base(name) { TypeName = "text"; }
		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Text; }

		protected override CSValueAttribute GetSimpleAttribute(Generation generation, CSClass cs)
		{
			CSValueAttribute att = new CSValueAttribute(this) { Type = CSValueEnum.String };
			att.Annotations.AddAnnotation("LargeText");
			return att;
		}
	}


	public class DataObjectVarcharAttribute : DataObjectSimpleAttribute
	{
		public int Length { get; set; }
		public DataObjectVarcharAttribute(string name, int length) : base(name)
		{
			TypeName = "varchar";
			Length = length;
		}
		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Char; }

		protected override CSValueAttribute GetSimpleAttribute(Generation generation, CSClass cs)
		{
			return new CSValueAttribute(this) { Type = CSValueEnum.String };
		}
	}


	public class DataObjectEnumAttribute : DataObjectSimpleAttribute
	{
		public DataObjectEnumAttribute(string name) : base(name) { TypeName = "enum"; }
		public DataEnum Enum { get; set; }
		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Int; }

		protected override CSValueAttribute GetSimpleAttribute(Generation generation, CSClass cs)
		{
			return new CSEnumAttribute(this, generation.GetEnum(Enum));
		}

		protected override string GetTypeName()
		{
			return TypeName + "(" + Enum.Name + ")";
		}
	}
}
