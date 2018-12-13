using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public class ActionSelector : AbsAction
	{
		private List<NodeSelector> _children = new List<NodeSelector>();

		[XmlElement("Row", typeof(NodeSelector))]
		public List<NodeSelector> Children { get { return _children; } }
		
		[XmlIgnore]
		public IRoll NumberOfRolls { get; set; }

		[XmlAttribute("Number")]
		public string MacroNumberOfRolls
		{
			get { return NumberOfRolls.ToMacro(); }
			set { NumberOfRolls = Dice.Procedures.Parse(value); }
		}

		public ActionSelector() { }
		public ActionSelector(IRoll number)
		{
			NumberOfRolls = number;
		}

		public override void Generation(ref GenerationResult result)
		{
			//The total ponderation
			int sum = _children.Sum(t => t.Ponderation);

			//The number of time we need to roll.
			NumberOfRolls.Roll();
			int nbr = NumberOfRolls.NetResult;
			for (int i = 0; i < nbr; i++)
			{
				// Roll
				int randomResult = Roll.RollD(sum);
				//Find compatible node
				foreach (var item in _children)
				{
					if (randomResult <= item.Ponderation)
					{
						//Generate
						item.Generation(ref result);
						break;
					}
					else
					{
						randomResult -= item.Ponderation;
					}
				}
			}
		}

		public void AddChild(NodeSelector newChild)
		{
			_children.Add(newChild);
		}

		public void AddChild(params NodeSelector[] newChildren)
		{
			foreach (var item in newChildren)
			{
				AddChild(item);
			}
		}
	}
}
