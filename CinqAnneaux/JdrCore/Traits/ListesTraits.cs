using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Traits {
	public class ListeAvantages : TraitCollection<Agent.Agent,Avantage> {
		public ListeAvantages(Agent.Agent agent) : base(agent) { }

		public IEnumerable<Avantage> Avantages { get { return base.Traits.Where(a => a.Desavantage == false); } }
		public IEnumerable<Avantage> Desavantages { get { return base.Traits.Where(a => a.Desavantage == true); } }
	}

	public class ListeTraitsCreature : TraitCollection<Agent.Agent, TraitCreature> {
		public ListeTraitsCreature( Agent.Agent agent ) : base(agent) { }
	}

	public class ListeTechniques : TraitCollection<Agent.Agent, Technique> {
		public ListeTechniques( Agent.Agent agent ) : base(agent) { }
	}

	public class ListePouvoirsOutremonde : TraitCollection<Agent.Agent, PouvoirOutremonde> {
		public ListePouvoirsOutremonde( Agent.Agent agent ) : base(agent) { }
	}
}
