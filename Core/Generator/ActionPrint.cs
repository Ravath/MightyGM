using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	/// <summary>
	/// Basic action printing the given text.
	/// </summary>
	public class ActionPrint : AbsAction
	{
		/// <summary>
		/// The added text.
		/// </summary>
		[XmlAttribute("Text")]
		public string Value { get; set; }

		public ActionPrint() {}
		public ActionPrint(string value)
		{
			Value = value;
		}

		/// <summary>
		/// Add the text to the generation.
		/// </summary>
		/// <param name="result"></param>
		public override void Generation(ref GenerationResult result)
		{
			result.AddText(Core.Dice.Procedures.ParseFromText(Value));
		}
	}
}
