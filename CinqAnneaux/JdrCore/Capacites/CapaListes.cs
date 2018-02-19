using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Capacites {
	public class ListeKatas : CapaciteCollection<Agent.Agent, Kata> {
		public ListeKatas( Agent.Agent agent) : base(agent) { }
	}
	public class ListeSorts : CapaciteCollection<Agent.Agent, Sort> {
		public ListeSorts( Agent.Agent agent ) : base(agent) { }
	}
	public class ListeKihos : CapaciteCollection<Agent.Agent, Kiho> {
		public ListeKihos( Agent.Agent agent ) : base(agent) { }
	}
}
