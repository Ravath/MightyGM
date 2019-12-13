using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public class StateRow : SequenceCollection
	{
		private int _repeat = 1;
		[XmlAttribute("Repeat")]
		public int Repeat
		{
			get { return _repeat; }
			set { _repeat = Math.Max(1, value); }
		}

		public StateRow() { }
		public StateRow(int repeat)
		{
			Repeat = repeat;
		}
	}
}
