using Core.Engine;
using Shadowrun5.JdrCore.Agents;
using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Traits {
	public class AttributExceptionnel : TraitShadowrun, BooleanTrigger {
		private Attribut _attribut;

		public AttributExceptionnel( Attribut a ) {
			_attribut = a;
        }
		public override void AffectAgent( ShadowrunAgent p ) {
			p.Caracteristiques.GetAttribut(_attribut).AttributExceptionnel.AddProvider(this);
        }

		public override void UnaffectAgent( ShadowrunAgent p ) {
			p.Caracteristiques.GetAttribut(_attribut).AttributExceptionnel.AddProvider(this);
		}
	}
	public class Chanceux : AttributExceptionnel {
		private IValue _chanceux = new Value(1);
		public Chanceux() : base(Attribut.Edge) {

		}
		public override void AffectAgent( ShadowrunAgent p ) {
			p.Caracteristiques.MaxChance.AddModifier(_chanceux);
        }

		public override void UnaffectAgent( ShadowrunAgent p ) {
			p.Caracteristiques.MaxChance.RemoveModifier(_chanceux);
		}
	}
}
