using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.Model
{
	public class DataEnum : DataEntity
	{
		#region Attributes Collection
		private List<DataEnumAttribute> _attributes = new List<DataEnumAttribute>();

		public IEnumerable<DataEnumAttribute> Attributes { get { return _attributes; } }

		public void AddAttribute(DataEnumAttribute attribute)
		{
			attribute.Parent = this;
			_attributes.Add(attribute);
		}
		#endregion

		#region Init
		public DataEnum(string name) : base(name)
		{

		}
		#endregion
	}

	/// <summary>
	/// Enum Attribute
	/// </summary>
	public class DataEnumAttribute : DataAttribute
	{
		public DataEnumAttribute(string name) : base(name)
		{
		}
	}
}
