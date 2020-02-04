using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public class SelectCollection : AbsCollection<SelectRow>
	{

		[XmlElement("Row", typeof(SelectRow))]
		public List<SelectRow> Children { get { return _children; } }

		[XmlAttribute("Number")]
		public string NumberString { get; set; } = "1";

		[XmlAttribute("PutBack")]
		public bool PutBack { get; set; } = true;

		public SelectCollection() { }
		public SelectCollection(IRoll number)
		{
			NumberString = number.ToMacro();
		}

		public override void Generation(ref GenerationResult result)
		{
			List<SelectRow> list = _children;
			//Compute the generation on a copy
			if (!PutBack) { list = new List<SelectRow>(_children); }

			//The total weight
			foreach (var item in list) { item.InitRow(result); }
			int sum = list.Sum(t => t.Weight);
			if(sum == 0) { return; }

			//The number of time we need to do the selection.
			IRoll RollNumber = result.GetRoll(NumberString);
			RollNumber.Roll();
			int nbr = RollNumber.NetResult;

			//Do the selections
			for (int i = 0; i < nbr; i++)
			{
				//Roll
				int randomResult = Roll.RollD(sum);
				//Find compatible node
				foreach (var item in list)
				{
					if (randomResult <= item.Weight)
					{
						//Generate
						item.Generation(ref result);

						if (!PutBack)
						{
							if(item.PutBack == 1)
							{
								//have to remove item when drawn
								list.Remove(item);
								//recompute total weight
								sum -= item.Weight;
								if (sum == 0) { return; }
							} else if (item.PutBack > 1) { item.PutBack--; }
							//And if 0 (or less), will never be removed
						}
						break;
					}
					else
					{
						randomResult -= item.Weight;
					}
				}
			}
		}
	}
}
