using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public class SelectRow : SequenceCollection
	{
		[XmlAttribute("Weight")]
		public string WeightString { get; set; } = "1";

		[XmlIgnore]
		public int Weight { get; private set; }

		[XmlAttribute("PutBack")]
		public string PutBackString { get; set; } = "1";

		[XmlIgnore]
		public int PutBack { get; internal set; }

		public SelectRow() { }
		public SelectRow(int weight)
		{
			WeightString = weight.ToString();
		}

		public void InitRow(GenerationResult result)
		{
			IRoll roll = result.GetRoll(WeightString);
			roll.Roll();
			Weight = Math.Max(0,roll.NetResult);
			roll = result.GetRoll(PutBackString);
			roll.Roll();
			PutBack = Math.Max(0, roll.NetResult);
		}
	}
}
