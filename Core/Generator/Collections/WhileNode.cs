using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public class WhileNode : ConditionalNode
	{
		public WhileNode() : base() {}
		public WhileNode(string tag, string value) : base(tag, value) { }

		/// <summary>
		/// Make every children perform generation in order.
		/// </summary>
		/// <param name="result"></param>
		public override void Generation(ref GenerationResult result)
		{
			while (IsConditionTrue(result))
				base.Generation(ref result);
		}
	}
}
