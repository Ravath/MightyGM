using DataGenerator.CSharp;
using DataGenerator.SQL;

namespace DataGenerator.DataModel.Model
{
	public class DataObjectUnitAttribute : DataObjectEnumAttribute
	{
		public DataObjectUnitAttribute(string name) : base(name) { TypeName = "unit"; }

		protected override CSAttribute GeneratedSpecific(Generation generation, CSClass cs)
		{
			CSUnityValueAttribute cua = new CSUnityValueAttribute(this, Enum.UnitTypeName(), Enum.Name);
			cua.AddRelationToSQLAttribute(cua.SqlUnitAttribute);
			cua.AddRelationToSQLAttribute(cua.SqlValueAttribute);
			return cua;
		}
	}


	public class DataObjectRangeAttribute : AbsDataStructAttribute
	{
		public DataObjectRangeAttribute(string name) : base(name) { TypeName = "range"; }

		protected override CSAttribute GeneratedSpecific(Generation generation, CSClass cs)
		{
			CSRangeAttribute cua = new CSRangeAttribute(this);
			cua.AddRelationToSQLAttribute(cua.SqlMaxAttribute);
			cua.AddRelationToSQLAttribute(cua.SqlMinAttribute);
			return cua;
		}

		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Int; }
	}
}
