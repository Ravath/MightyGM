using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	/// <summary>
	/// A specialized sequence node associated with conditions.
	/// </summary>
	public class NodeRandomizer : NodeSequence
	{
		[XmlAttribute("Min")]
		public int Min { get; set; }
		[XmlAttribute("Max")]
		public int Max { get; set; }

		public NodeRandomizer() {}
		public NodeRandomizer(int min, int max)
		{
			Min = min;
			Max = max;
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
