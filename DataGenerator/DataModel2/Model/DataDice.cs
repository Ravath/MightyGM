using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Parser;

namespace DataGenerator.DataModel2.Model
{
	public class DataDice : DataEntity
	{
		#region Attributes Collection
		private List<DataDiceAttribute> _attributes = new List<DataDiceAttribute>();
		private RawTable tab;

		public IEnumerable<DataDiceAttribute> Attributes { get { return _attributes; } }

		public void AddAttribute(DataDiceAttribute attribute)
		{
			attribute.Parent = this;
			_attributes.Add(attribute);
		}
		#endregion

		#region Init
		public DataDice(string name) : base(name)
		{

		}
		#endregion
	}

	public class DataDiceAttribute : DataAttribute{
		public int Odds { get; set; }

		public DataDiceAttribute(string name, int odds) : base(name)
		{
			Odds = odds;
		}
	}
}
