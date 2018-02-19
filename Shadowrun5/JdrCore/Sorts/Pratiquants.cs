using Core.Engine;
using Shadowrun5.JdrCore.Agents;
using Shadowrun5.JdrCore.Traits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Sorts {

	public class Magicien : TraitShadowrun, BooleanTrigger {

		public new string Name {
			get {
				return "Magicien";
			}
		}

		public override void AffectAgent( ShadowrunAgent a ) {
			a.PerceptionAstrale.AddProvider(this);
		}

		public override void UnaffectAgent( ShadowrunAgent a ) {
			a.PerceptionAstrale.RemoveProvider(this);
		}
	}
}
