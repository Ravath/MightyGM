using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.Model
{
	public abstract class DataEntity
	{
		public string Name { get; set; }

		public DataEntity(string name)
		{
			Name = name;
		}
	}
}
