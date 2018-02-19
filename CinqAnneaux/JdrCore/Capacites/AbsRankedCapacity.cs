using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.JdrCore.Agent;

namespace CinqAnneaux.JdrCore.Capacites {

	public interface IImplementedCapacity {
		void AffectSelf( Agent.Agent target );
		void AffectTarget( Agent.Agent caster, Agent.Agent target );
	}

	public class AbsRankedCapacity : ICapaciteActive<Agent.Agent> {
		#region Properties
		public string Name { get; protected set; }
		public int Rank { get; protected set; }

		public virtual TargetType TargetType { get; }
		public virtual double Range { get; }
		public virtual bool CanAffectMultipleTargets { get; }
		public IImplementedCapacity Delegate { get; internal set; }
		#endregion

		#region Init
		public AbsRankedCapacity() {}
		#endregion

		public void AffectSelf( Agent.Agent target ) {
			if(Delegate != null)
				Delegate.AffectSelf(target);
        }

		public void AffectTarget( Agent.Agent caster, Agent.Agent target ) {
			if(Delegate != null)
				Delegate.AffectTarget(caster, target);
		}

		public void AffectTargets( Agent.Agent caster, IEnumerable<Agent.Agent> targets ) {
			foreach(var item in targets) {
				AffectTarget(caster, item);
			}
		}
	}

	public class AbsElementalCapacity : AbsRankedCapacity {
		public Anneau Anneau { get; protected set; }
	}
}
