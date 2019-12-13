using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	/// <summary>
	/// Higher class, parent of the Generation Nodes in the composite pattern.
	/// </summary>
	public abstract class AbsNode
	{
		/// <summary>
		/// Abstract definition of the fonction called by generation.
		/// </summary>
		/// <param name="result">The result to perform the generation upon.</param>
		public abstract void Generation(ref GenerationResult result);

		/// <summary>
		/// Default definition of the fonction called before generation.
		/// </summary>
		public virtual void StartGeneration() { }

		/// <summary>
		/// Default definition of the fonction called after generation.
		/// </summary>
		public virtual void EndGeneration() { }
	}
}
