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
	/// A specialized sequence node associated with conditions.
	/// </summary>
	public class RandomRow : SequenceCollection
	{
		[XmlAttribute("Min")]
		public string MinString { get; set; }
		[XmlAttribute("Max")]
		public string MaxString { get; set; }

		[XmlIgnore]
		public int Min { get; private set; }
		[XmlIgnore]
		public int Max { get; private set; }

		[XmlAttribute("PutBack")]
		public string PutBackString { get; set; } = "1";

		[XmlIgnore]
		public int PutBack { get; internal set; }

		public RandomRow() {}
		public RandomRow(int min, int max)
		{
			Min = min;
			Max = max;
		}

		public void InitRow(GenerationResult result)
		{
			//Min
			IRoll roll = result.GetRoll(MinString);
			roll.Roll();
			Min = roll.NetResult;
			//Max
			roll = result.GetRoll(MaxString);
			roll.Roll();
			Max = roll.NetResult;
			//Number of putBacks
			roll = result.GetRoll(PutBackString);
			roll.Roll();
			PutBack = Math.Max(0, roll.NetResult);
		}

		/// <summary>
		/// Check if the given value matches the node conditions for generation.
		/// </summary>
		/// <param name="value">The value to compare.</param>
		/// <returns>True if conditions match.</returns>
		public Boolean IsValid(int value)
		{
			return value >= Min && value <= Max;
		}
	}
}
