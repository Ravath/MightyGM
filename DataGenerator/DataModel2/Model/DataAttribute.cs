using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.Model
{
	public abstract class DataAttribute
	{
		public string Name { get; set; }
		private DataEntity _parent;

		public DataEntity Parent
		{
			get
			{
				return _parent;
			}
			internal set
			{
				if (_parent != value)
				{
					_parent = value;
				}
			}
		}

		public DataAttribute(string name)
		{
			Name = name;
		}
	}
}
