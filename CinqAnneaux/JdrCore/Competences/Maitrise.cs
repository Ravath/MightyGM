using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.JdrCore.Agent;

namespace CinqAnneaux.JdrCore.Competences {
	public abstract class Maitrise : ITrait<Agent.Agent> {
		public int Rang { get; set; }
		public string Description { get; set; }

		public string Name { get; private set; }

		public Maitrise( MaitriseModel model ) {
			SetMaitrise(model);
        }

		public void SetMaitrise( MaitriseModel model ) {
			Rang = model.RangRequis;
			Description = model.Description.Description;
			Name = model.Name;
        }

		public abstract void AffectAgent( Agent.Agent a );
		public abstract void UnaffectAgent( Agent.Agent a );
	}

	public class DefaultMaitrise : Maitrise {
		public DefaultMaitrise( MaitriseModel model ) : base(model) { }
		public override void AffectAgent( Agent.Agent a ) { }
		public override void UnaffectAgent( Agent.Agent a ) { }
	}
}