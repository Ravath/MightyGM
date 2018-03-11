using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Attaques;
using CinqAnneaux.JdrCore.Objets;
using CinqAnneaux.JdrCore.Traits;

namespace CinqAnneaux.JdrCore.Agent {
	public class Creature : Agent {
		public TypeCreature TypeCreature { get; private set; }

		public Creature()
		{

		}
		public Creature(CreatureModel model)
		{
			SetPersonnage(model);
		}

		public override void SetPersonnage( CreatureModel model) {
			base.SetPersonnage(model);
			TypeCreature = model.TypeCreature;
			/* set initiative */
			Initiative = new RollAndKeep(model.xgInitiative, model.gxInitiative);
			/* vie */
			if(model.VieHumaine)
				Vie = new SeuilViePJ(this);
			else
				Vie = new SeuilVieCreature(this, model);
			/* souillure */
			Souillure.SetRank(model.Souillure ?? 0,0);
			//attaques
			ClearAttaques();
            foreach(Data.AttaqueCreature att in model.Attaques) {
				AddAttaque(new Attaques.AttaqueCreature(att));
			}
			//défense
			Armures.Clear();
			Armure arm = new Armure();
			arm.SetCreatureModel(model);
			Armures.Wear(arm);
			Armures.SetCreature();
			//pouvoirs de créature
			TraitsCreature.Clear();
			foreach(var item in model.Pouvoirs) {
				TraitCreature tc = new TraitCreature();
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
		}

	}
}
