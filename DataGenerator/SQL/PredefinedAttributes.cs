using DataGenerator.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.SQL
{
	public class SQLForeignKeyAttribute : SQLAttribute
	{
		public SQLForeignKeyAttribute(string RefName, string attName)
		{
			Name = "fk_" + RefName + "_" + attName;
			Type = SQLTypeEnum.Int;
			IsForeignKey = true;
			CanBeNull = true;
		}
		public SQLForeignKeyAttribute(CSClass refClass, string attName) : this(refClass.Name, attName) { }
	}

	public class SQLID : SQLAttribute
	{
		public SQLID() : base()
		{
			Name = "id";
			Type = SQLTypeEnum.Serial;
			CanBeNull = false;
			IsPrimaryKey = true;
			AddConstraint(new SQLPrimaryKey(this));
		}
	}

	public class SQLUniqueName : SQLAttribute
	{
		public SQLUniqueName() : base()
		{
			Name = "name";
			Type = SQLTypeEnum.Char;
			Varying = 40;
			CanBeNull = false;
			IsPrimaryKey = false;
			AddConstraint(new SQLUnique(this));
		}
	}
	public class SQLTag : SQLAttribute
	{
		public SQLTag() : base()
		{
			Name = "tag";
			Type = SQLTypeEnum.Char;
			Varying = 7;
			CanBeNull = false;
			IsPrimaryKey = false;
			AddConstraint(new SQLUnique(this));
		}
	}

	public class SQLDescription : SQLAttribute
	{
		public SQLDescription() : base()
		{
			Name = "description";
			Type = SQLTypeEnum.Text;
			CanBeNull = false;
			IsPrimaryKey = false;
		}
	}
}
