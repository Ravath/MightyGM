using Core.Engine;
using Core.Gestion;
using Shadowrun5.JdrCore.Traits;
using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shadowrun5.JdrCore.Attributs;

namespace Shadowrun5.JdrCore.Agents {
	public class Personnage : ShadowrunAgent {


		public Joueur Joueur { get; set; }
		public Jauge Karma { get; }
		public Value Rumeur { get; }
		public Value Renommee { get; }
		public Credibilite Credibilite { get; }
		public TraitCollection<ShadowrunAgent, Avantage> Avantages { get; }
		//private Metatype _metatype;
		//public Metatype Metatype {
		//	get {
		//		return _metatype;
		//	}
		//	set {
		//		_metatype = value;
		//		Allonge.BaseValue = value.Reach.BaseValue;
		//		Armure.BaseValue = value.Armor.BaseValue;
		//		ModificateurCoutVie.BaseValue = value.LifeStyleMod.BaseValue;
		//	}
		//}

		public Personnage() : base() {
			Karma = new Jauge(0, 0);
			Avantages = new TraitCollection<ShadowrunAgent, Avantage>(this);
			Rumeur = new Value();
			Renommee = new Value();
			Credibilite = new Credibilite(Karma);
        }
	}
	/// <summary>
	/// Creature Evoluant dans la matrice.
	/// </summary>
	public class EntiteInformatique : IAgent {
		public bool IsDead {
			get {
				throw new NotImplementedException();
			}
		}

		public TargetType TargetType {
			get {
				throw new NotImplementedException();
			}
		}
	}
	/// <summary>
	/// Machine evoluant dans le monde réel.
	/// </summary>
	public class Drone : IAgent {
		public bool IsDead {
			get {
				throw new NotImplementedException();
			}
		}

		public TargetType TargetType {
			get {
				throw new NotImplementedException();
			}
		}
	}
}
