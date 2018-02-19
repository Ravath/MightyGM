using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Traits {
	public class GeneralTrait : ITrait<Agent.Agent> {
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public IAvantageImplementation Delegate { get; protected set; }

		public void AffectAgent( Agent.Agent a ) {
			if(Delegate != null)
				Delegate.Affect(a);
		}

		public void UnaffectAgent( Agent.Agent a ) {
			if(Delegate != null)
				Delegate.Unaffect(a);
		}

	}
}
