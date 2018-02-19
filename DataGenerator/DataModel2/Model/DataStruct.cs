using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Parser;

namespace DataGenerator.DataModel2.Model
{
	public class DataStruct : DataEntity
	{
		public DataStruct(string name) : base(name) { }

		public DataStruct Parent { get; set; }

		private List<DataObjectAttribute> _attributes = new List<DataObjectAttribute>();
		private RawTable tab;

		public IEnumerable<DataObjectAttribute> Attributes { get { return _attributes; } }

		public void AddAttribute(DataObjectAttribute attribute)
		{
			_attributes.Add(attribute);
		}
	}
}
