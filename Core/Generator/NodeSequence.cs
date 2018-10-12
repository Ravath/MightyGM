using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generator
{
	/// <summary>
	/// A simple collection of Generation Nodes.
	/// Make every children perform generation in order.
	/// </summary>
	public class NodeSequence : AbsNode
	{
		public NodeSequence() {}

		/// <summary>
		/// Make every children perform generation in order.
		/// </summary>
		/// <param name="result"></param>
		public override void Generation(ref GenerationResult result)
		{
			// Make every children perform generation in order.
			foreach (var item in Children)
			{
				item.Generation(ref result);
			}
		}
	}
}
