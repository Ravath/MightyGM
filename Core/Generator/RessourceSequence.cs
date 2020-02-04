using Core.Generator.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public class RessourceSequence : AbsRessource
	{
		public SequenceCollection Sequence { get; set; }

		public RessourceSequence()
		{

		}

		public RessourceSequence(string name)
		{
			Name = name;
		}

		public override void Generation(ref GenerationResult result)
		{
			if(Sequence != null)
			{
				Sequence.Generation(ref result);
			}
		}

		public override void StartGeneration()
		{
			Sequence.StartGeneration();
		}

		public override void EndGeneration()
		{
			Sequence.EndGeneration();
		}
	}
}
