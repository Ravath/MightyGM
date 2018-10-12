using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Objets {
	public class Armure : IWearable {
		public string Name { get; private set; }
		public Value ND { get; private set; }
		public Value Reduction { get; private set; }

		public Armure() {
			ND = new Value(0) { Label = "Armure" };
			Reduction = new Value(0) { Label = "Armure" };
		}

		public void SetArmure( ArmureModel model ) {
			Name = model.Name;
			ND.BaseValue = model.BonusND;
			Reduction.BaseValue = model.Reduction;
			/* add specific effects */
			// todo : add armor specific effects
		}

		public void Desequiper( IAgent personnage ) {
			Agent.Agent p = (Agent.Agent)personnage;
			p.Armures.ND.RemoveModifier(ND);
			p.Armures.Reduction.RemoveModifier(Reduction);
		}

		public void Equiper( IAgent personnage ) {
			Agent.Agent p = (Agent.Agent)personnage;
			p.Armures.ND.AddModifier(ND);
			p.Armures.Reduction.AddModifier(Reduction);
		}
	}
}
