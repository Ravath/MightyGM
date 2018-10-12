using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	/// <summary>
	/// Abstract Class for nodes collection of nodes. Works in a Composite pattern.
	/// </summary>
	public abstract class AbsNode : AbsComposite
	{
		private List<AbsComposite> _children = new List<AbsComposite>();

		[XmlElement("Print", typeof(ActionPrint))]
		[XmlElement("Tag", typeof(ActionTag))]
		[XmlElement("Randomizer", typeof(ActionRandomizer))]
		[XmlElement("If", typeof(NodeIf))]
		[XmlElement("Ressource", typeof(ActionRessource))]
		[XmlElement("Sequence", typeof(NodeSequence))]
		public List<AbsComposite> Children { get { return _children; } }

		public void AddChild(AbsComposite newChild)
		{
			_children.Add(newChild);
		}

		public void AddChild(params AbsComposite[] newChildren)
		{
			foreach (var item in newChildren)
			{
				_children.Add(item);
			}
		}
	}
}
