using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Attaques;
using CinqAnneaux.JdrCore.Objets;
using CinqAnneaux.JdrCore.Traits;
using Core.Engine;

namespace CinqAnneaux.JdrCore.Agent {
	public class Figurant : Agent {
		private Value _initRoll = new Value(0) { Label = "Roll Initiative" };
		private Value _initKeep = new Value(0) { Label = "Keep Initiative" };

		public Figurant()
		{
			Initiative = new RollAndKeep(_initRoll, _initKeep);
		}
		public Figurant(FigurantModel model)
		{
			SetPersonnage(model);
		}

		public override void SetPersonnage(FigurantModel model) {
			/* set initiative */
			_initRoll.BaseValue = model.Initiative_r;
			_initKeep.BaseValue = model.Initiative_k;
			/* vie */
			if(model.VieHumaine)
				Vie = new SeuilViePJ(this);
			else
				Vie = new SeuilVieCreature(this, model);
			/* souillure */
			if(model.Souillure == null)
			{
				Souillure.SetRank(0, 0);
			}
			else
			{
				Souillure.SetRank(Decimal.ToInt32(model.Souillure.Value), (int)(10 * model.Souillure) % 10);
			}
			//attaques
			Armes.SetCreatureModel(model);
			//défense
			Armures.SetCreatureModel(model);
			//pouvoirs de créature
			TraitsCreature.Clear();
			foreach(var item in model.Pouvoirs) {
				PouvoirNaturel tc = new PouvoirNaturel();
				tc.SetExemplaire(item);
				TraitsCreature.AddTrait(tc);
            }
			/* clear all unused componants */
			//objets
			Armes.Clear();
			Inventaire.RemoveAll();
			//traits
			Techniques.Clear();
			PouvoirsOutremonde.Clear();
			Avantages.Clear();
			//capacités
			Katas.ClearCapacities();
			Kihos.ClearCapacities();
			Sorts.ClearCapacities();

			// base settings + event
			base.SetPersonnage(model);
		}

	}
}
