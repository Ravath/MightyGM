using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public class NodeSelector : NodeSequence
	{
		private int _ponderation;
		[XmlAttribute("Pond")]
		public int Ponderation
		{
			get{ return _ponderation; }
			set { _ponderation = Math.Max(0,value); }
		}

		public NodeSelector() { }
		public NodeSelector(int pond)
		{
			Ponderation = pond;
		}
	}
}
