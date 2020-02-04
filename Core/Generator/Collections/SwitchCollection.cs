using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public class SwitchCollection : AbsCollection<SwitchRow>
	{
		[XmlElement("Case", typeof(SwitchRow))]
		public List<SwitchRow> Children { get { return _children; } }

		[XmlAttribute("Tag")]
		public string Tag { get; set; }

		[XmlAttribute("StopAtFirst")]
		public bool StopAtFirst { get; set; } = false;

		protected SwitchCollection() { }

		public override void Generation(ref GenerationResult result)
		{
			// Init Switch Rows
			foreach (var item in _children)
			{
				item.Tag = Tag;
			}

			// Do Generation
			foreach (var item in _children)
			{
				item.Generation(ref result);
				if (StopAtFirst)
				{
					continue;
				}
			}
		}
	}
}
