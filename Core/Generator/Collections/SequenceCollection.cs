using Core.Generator.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	/// <summary>
	/// A simple collection of Generation Nodes.
	/// Make every children perform generation in order.
	/// </summary>
	public class SequenceCollection : AbsCollection<AbsNode>
	{
		[XmlElement("Print", typeof(ActionPrint))]
		[XmlElement("Tag", typeof(ActionTag))]
		[XmlElement("If", typeof(IfNode))]
		[XmlElement("While", typeof(WhileNode))]
		[XmlElement("Ressource", typeof(ActionRessource))]
		[XmlElement("Randomizer", typeof(RandomCollection))]
		[XmlElement("Selector", typeof(SelectCollection))]
		[XmlElement("Automaton", typeof(StateCollection))]
		[XmlElement("Switch", typeof(SwitchCollection))]
		[XmlElement("Sequence", typeof(SequenceCollection))]
		public List<AbsNode> Children { get { return _children; } }

		public SequenceCollection() {}

		/// <summary>
		/// Make every children perform generation in order.
		/// </summary>
		/// <param name="result"></param>
		public override void Generation(ref GenerationResult result)
		{
			// Make every children perform generation in order.
			foreach (var item in Children)
			{
				item.Generation(ref result);
			}
		}
	}
}
