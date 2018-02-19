using Core.Engine;
using Shadowrun5.JdrCore.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Traits {

	public class BonusAllonge : TraitShadowrun {
		private IValue _modAllonge;
		public BonusAllonge( int bonus ) {
			_modAllonge = new Value() { BaseValue = bonus };
			Name = "Allonge+" + bonus.ToString();
        }
		public override void AffectAgent( ShadowrunAgent p ) {
			p.Allonge.AddModifier(_modAllonge);
		}
		public override void UnaffectAgent( ShadowrunAgent p ) {
			p.Allonge.RemoveModifier(_modAllonge);
		}
	}

	public class VisionThermique : TraitShadowrun, BooleanTrigger {
		public VisionThermique() {
			Name = "Vision Thermique";
		}
		public override void AffectAgent( ShadowrunAgent p ) {
			p.VisionInfrarouge.AddProvider(this);
		}
		public override void UnaffectAgent( ShadowrunAgent p ) {
			p.VisionInfrarouge.RemoveProvider(this);
		}
	}

	public class VisionNocturne : TraitShadowrun, BooleanTrigger {
		public VisionNocturne() {
			Name = "Vision Nocturne";
		}
		public override void AffectAgent( ShadowrunAgent p ) {
			p.VisionNocturne.AddProvider(this);
		}
		public override void UnaffectAgent( ShadowrunAgent p ) {
			p.VisionNocturne.RemoveProvider(this);
		}
	}

	public class ResistanceToxines : TraitShadowrun {

		private Value _bonus;
		public Value Bonus { get { return  _bonus; } }

		public ResistanceToxines( int bonus ) {
			_bonus = new Value(bonus);
        }

		public override void AffectAgent( ShadowrunAgent p ) {
			p.ResistanceToxines.AddModifier(_bonus);
		}

		public override void UnaffectAgent( ShadowrunAgent p ) {
			p.ResistanceToxines.RemoveModifier(_bonus);
		}
	}
}
