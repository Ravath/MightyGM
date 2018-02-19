using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Engine {
	public interface IAgent : ITargetable{
		bool IsDead { get; }

		//todo : collection d'altérations d'état ( et de tickings )
		//TODO : mécanisme de rapport dans le chat
	}

	public abstract class AgentPart<C> where C : class, IAgent {
		private C _agent;

		public C Agent {
			get { return _agent; }
		}

		public AgentPart(C agent) {
			if(agent == null)
				throw new ArgumentNullException("Agent parameter can't be null.");
			_agent = agent;
		}
	}
}
