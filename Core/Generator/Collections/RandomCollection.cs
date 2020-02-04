using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	/// <summary>
	/// An action Node, introducing random behavior in the generation.
	/// At generation, Rolls the dice a given number of time, and dispatch generation to matching children.
	/// </summary>
	public class RandomCollection : AbsCollection<RandomRow>
	{
		[XmlElement("Row", typeof(RandomRow))]
		public List<RandomRow> Children { get { return _children; } }

		[XmlAttribute("Roll")]
		public string RollString { get; set; } = "1:100";

		[XmlAttribute("Number")]
		public string NumberString { get; set; } = "1";

		[XmlAttribute("PutBack")]
		public bool PutBack { get; set; } = true;

		[XmlAttribute("Compulsory")]
		public bool Compulsory { get; set; } = false;

		[XmlAttribute("StopAtFirst")]
		public bool StopAtFirst { get; set; } = false;

		public RandomCollection() { }
		public RandomCollection(IRoll roll, int number) : this(roll, new Intervalle(number, number)) { }
		public RandomCollection(IRoll roll, IRoll number)
		{
			RollString = roll.ToMacro();
			NumberString = number.ToMacro();
		}

		public override void Generation(ref GenerationResult result)
		{
			List<RandomRow> list = _children;
			List<RandomRow> toRemove = new List<RandomRow>();
			//Compute the generation on a copy
			if (!PutBack) { list = new List<RandomRow>(_children); }

			//Init row values
			foreach (var item in list) { item.InitRow(result); }

			//The number of time we need to roll.
			IRoll Number = result.GetRoll(NumberString);
			IRoll Roll = result.GetRoll(RollString);

			//Roll number of times to roll the dice
			Number.Roll();
			int nbr = Number.NetResult;

			// Roll the dice
			for (int i = 0; i < nbr; i++)
			{
				bool foundResult = false;

				// Roll
				Roll.Roll();
				int randomResult = Roll.NetResult;
				//Find compatible node
				foreach (var item in list)
				{
					if (item.IsValid(randomResult))
					{
						foundResult = true;
						//Generate
						item.Generation(ref result);

						if (!PutBack)
						{
							if (item.PutBack == 1)
							{
								//have to remove item when drawn
								toRemove.Add(item);
							}
							else if (item.PutBack > 1) { item.PutBack--; }
							//And if 0 (or less), will never be removed
						}
						if (StopAtFirst)
						{
							continue;
						}
					}
				}

				//Remove used items
				foreach (var item in toRemove)
				{
					list.Remove(item);
				}
				toRemove.Clear();

				//check compulsory results
				if (Compulsory)
				{
					//force exit if needed (not necessary if not compulsory)
					if (list.Count == 0) { return; }

					if (!foundResult)
					{
						//redo until found
						i--;
					}
				}
			}
		}
	}
}
