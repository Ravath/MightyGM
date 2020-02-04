using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public class StateRow : SequenceCollection
	{
		[XmlAttribute("Repeat")]
		public string RepeatString { get; set; } = "1";

		[XmlIgnore]
		public int Repeat { get; private set; }

		public StateRow() { }
		public StateRow(int repeat)
		{
			Repeat = repeat;
		}

		public void InitRow(GenerationResult result)
		{
			IRoll roll = result.GetRoll(RepeatString);
			roll.Roll();
			Repeat = Math.Max(0, roll.NetResult);
		}
	}
}
