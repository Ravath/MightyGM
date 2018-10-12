using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	/// <summary>
	/// An action Node, introducing random behavior in the generation.
	/// At generation, Rolls the dice a given number of time, and dispatch generation to matching children.
	/// </summary>
	public class ActionRandomizer : AbsAction
	{
		private List<NodeRandomizer> _children = new List<NodeRandomizer>();

		[XmlElement("Row", typeof(NodeRandomizer))]
		public List<NodeRandomizer> Children { get { return _children; } }

		[XmlIgnore]
		public IRoll Roll { get; set; }
		[XmlIgnore]
		public IRoll NumberOfRolls { get; set; }

		[XmlAttribute("Roll")]
		public string MacroRoll
		{
			get{ return Roll.ToMacro(); }
			set{ Roll = Dice.Procedures.Parse(value); }
		}
		[XmlAttribute("Number")]
		public string MacroNumberOfRolls
		{
			get { return NumberOfRolls.ToMacro(); }
			set { NumberOfRolls = Dice.Procedures.Parse(value); }
		}

		public ActionRandomizer() {}
		public ActionRandomizer(IRoll roll, int number) : this(roll, new Intervalle(number, number)) {}
		public ActionRandomizer(IRoll roll, IRoll number)
		{
			Roll = roll;
			NumberOfRolls = number;
		}

		public override void Generation(ref GenerationResult result)
		{
			//The number of time we need to roll.
			NumberOfRolls.Roll();
			int nbr = NumberOfRolls.NetResult;
			for(int i = 0; i<nbr; i++)
			{
				// Roll
				Roll.Roll();
				int randomResult = Roll.NetResult;
				//Find compatible node
				foreach (var item in _children)
				{
					if (item.IsValid(randomResult))
					{
						//Generate
						item.Generation(ref result);
					}
				}
			}
		}

		public void AddChild(NodeRandomizer newChild)
		{
			_children.Add(newChild);
		}

		public void AddChild(params NodeRandomizer[] newChildren)
		{
			foreach (var item in newChildren)
			{
				AddChild(item);
			}
		}
	}
}
