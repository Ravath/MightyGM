using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.Model
{
	public class DataIntAttribute : DataObjectAttribute
	{
		public DataIntAttribute(string name) : base(name)
		{
			TypeName = "int";
		}
	}
	public class DataDecimalAttribute : DataObjectAttribute
	{
		public DataDecimalAttribute(string name) : base(name)
		{
			TypeName = "decimal";
		}
	}
	public class DataRealAttribute : DataObjectAttribute
	{
		public DataRealAttribute(string name) : base(name)
		{
			TypeName = "real";
		}
	}
	public class DataBooleanAttribute : DataObjectAttribute
	{
		public DataBooleanAttribute(string name) : base(name)
		{
			TypeName = "bool";
		}
	}
	public class DataTextAttribute : DataObjectAttribute
	{
		public DataTextAttribute(string name) : base(name)
		{
			TypeName = "text";
		}
	}
	public class DataVarcharAttribute : DataObjectAttribute
	{
		public int Length { get; set; }
		public DataVarcharAttribute(string name, int length) : base(name)
		{
			TypeName = "varchar";
			Length = length;
		}
	}
	public class DataObjectEnumAttribute : DataObjectAttribute
	{
		public DataObjectEnumAttribute(string name) : base(name)
		{
		}
		public DataEnum Enum { get; set; }
	}
	public abstract class DataReferenceAttribute : DataObjectAttribute
	{
		public DataReferenceAttribute(string name) : base(name)
		{
		}

		public DataReferenceAttribute Reference { get; set; }
	}
	public class DataRefAttribute : DataReferenceAttribute
	{
		public DataRefAttribute(string name) : base(name)
		{
			TypeName = "ref";
		}
	}
	public class DataRefexAttribute : DataReferenceAttribute
	{
		public DataRefexAttribute(string name) : base(name)
		{
			TypeName = "refex";
		}
	}
}
