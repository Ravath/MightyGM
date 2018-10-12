using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generator
{
	public class RessourceSequence : AbsRessource
	{
		public NodeSequence Sequence { get; set; }

		public override void Generation(ref GenerationResult result)
		{
			if(Sequence == null)
			{
				result.ReportError(String.Format("The ressource {0} hasn't any sequence implemented", Name));
			}
			else
			{
				Sequence.Generation(ref result);
			}
		}

		public RessourceSequence()
		{

		}

		public RessourceSequence(string name)
		{
			Name = name;
		}
	}
}
