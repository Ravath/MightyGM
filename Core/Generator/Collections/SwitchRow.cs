using System;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public class SwitchRow : ConditionalNode
	{
		/// <summary>
		/// Make every children perform generation in order.
		/// </summary>
		/// <param name="result"></param>
		public override void Generation(ref GenerationResult result)
		{
			if (IsConditionTrue(result))
				base.Generation(ref result);
		}
	}
}