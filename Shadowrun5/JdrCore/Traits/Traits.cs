using Core.Engine;
using Shadowrun5.JdrCore.Agents;
using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Traits {
	public abstract class TraitShadowrun : ITrait<ShadowrunAgent> {

		public virtual string Name { get; protected set; }
		
		public abstract void AffectAgent( ShadowrunAgent p );
		public abstract void UnaffectAgent( ShadowrunAgent p );

		public override string ToString() {
			return Name;
		}
	}

	public class Avantage : TraitShadowrun {

		public int Cout { get; private set; }

		public Avantage( PositiveQualityModel pqm ) {
			Name = pqm.Name;
			Cout = pqm.Cost;
		}
		public Avantage( NegativeQualityModel pqm ) {
			Name = pqm.Name;
			Cout = -pqm.Cost;
		}

		public override void AffectAgent( ShadowrunAgent p ) { }

		public override void UnaffectAgent( ShadowrunAgent p ) { }
	}
}
