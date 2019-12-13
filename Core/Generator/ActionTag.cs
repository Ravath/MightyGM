using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public class ActionTag : AbsNode
	{

		[XmlAttribute("Tag")]
		public string Tag { get; set; }
		[XmlAttribute("Text")]
		public string Value { get; set; }

		public ActionTag() { }
		public ActionTag(string tag, string value)
		{
			Tag = tag;
			Value = value;
		}

		public override void Generation(ref GenerationResult result)
		{
			result.SetTag(Tag, Dice.Procedures.ParseFromText(Value));
		}
	}
}
