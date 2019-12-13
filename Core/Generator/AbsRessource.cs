using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public abstract class AbsRessource : AbsNode
	{
		[XmlAttribute("Tag")]
		public string Name { get; set; }

		public AbsRessource()
		{

		}

		public AbsRessource(string name)
		{
			Name = name;
		}
	}
}
