using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public enum StateBehaviour
	{
		Quit, Loop, Stop
	}

	public class StateCollection : AbsCollection<StateRow>
	{
		[XmlElement("State", typeof(StateRow))]
		public List<StateRow> Children { get { return _children; } }

		[XmlAttribute("Behaviour")]
		public StateBehaviour Behaviour { get; set; } = StateBehaviour.Quit;

		public StateCollection() { }

		private int counter=1;
		private int incrementDirection = 1;
		private bool firstPassage = true;
		public override void Generation(ref GenerationResult result)
		{
			//Anti-infinite-loop check
			if(_children.Count == 0) { return; }

			//Init
			if (firstPassage)
			{
				foreach (var item in Children) { item.InitRow(result); }
				firstPassage = false;
			}
			int localCounter = counter;

			//find the current state
			foreach (var item in _children)
			{
				localCounter -= item.Repeat;
				if (localCounter <= 0)
				{
					item.Generation(ref result);
					counter += incrementDirection;
					return;
				}
			}

			//We can reach here only if didn't find any state
			switch (Behaviour)
			{
				case StateBehaviour.Quit:
					//Nothing
					break;
				case StateBehaviour.Loop:
					counter = 1;
					Generation(ref result);
					break;
				case StateBehaviour.Stop:
					incrementDirection = 0;
					counter--;
					Generation(ref result);
					break;
				default:
					break;
			}
		}

		public override void StartGeneration()
		{
			counter = 1;
			incrementDirection = 1;
			firstPassage = true;
			base.StartGeneration();
		}
	}
}
