using Core.Engine;
using Shadowrun5.Data;
using Shadowrun5.JdrCore.Attributs;
using Shadowrun5.JdrCore.Competences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Agents {
	/// <summary>
	/// Esprit Evoluant dans le monde réel.
	/// </summary>
	public class Esprit : ShadowrunAgent {

		private AsservedSpirit _asserved;

		/// <summary>
		/// Le facteur de puissance de l'esprit.
		/// </summary>
		public Value PuissanceEsprit { get; }

		public Esprit() {
			PuissanceEsprit = new Value(1) { Label = "Puissance" };
			Caracteristiques.Constitution.AddModifier(PuissanceEsprit);
			Caracteristiques.Agilite.AddModifier(PuissanceEsprit);
			Caracteristiques.Reaction.AddModifier(PuissanceEsprit);
			Caracteristiques.Force.AddModifier(PuissanceEsprit);
			Caracteristiques.Volonte.AddModifier(PuissanceEsprit);
			Caracteristiques.Logique.AddModifier(PuissanceEsprit);
			Caracteristiques.Intuition.AddModifier(PuissanceEsprit);
			Caracteristiques.Charisme.AddModifier(PuissanceEsprit);
			Caracteristiques.Essence.AddModifier(PuissanceEsprit);
			Caracteristiques.Puissance.AddModifier(PuissanceEsprit);
			Caracteristiques.MaxChance.AddModifier(PuissanceEsprit);
			Pratiquant = PratiquantMagie.Magicien;
		}
		protected void setSpiritModelStep( SpiritModel s ) {
			if(s == null) { ResetExemplar(); ResetModel(); return; }
			setCharacterModelStep(s);
			/* remove modifier from old skills */
			foreach(Competence cp in Competences.Competences) {
				cp.Rang.RemoveModifier(PuissanceEsprit);
			}
			/* add modifier to new ones */
			foreach(Competence cp in Competences.Competences) {
				cp.Rang.BaseValue = 0;
				cp.Rang.AddModifier(PuissanceEsprit);
			}
		}

		protected void setSpiritExemplarStep( SpiritExemplar se ) {
			if(se == null) { ResetExemplar(); return; }
			setCharacterExemplarStep(se);
			PuissanceEsprit.BaseValue = se.Power;
			if(!se.Free) {
				if(_asserved!=null)
					Caracteristiques.MaxChance.RemoveModifier(_asserved);
				_asserved = new AsservedSpirit(Caracteristiques.MaxChance);
                Caracteristiques.MaxChance.AddModifier(_asserved);
			}
		}

		public virtual void SetModel( SpiritModel s ) {
			setSpiritModelStep(s);
		}

		public virtual void SetExemplaire( SpiritExemplar se ) {
			setSpiritModelStep((SpiritModel)se.Model);
			setSpiritExemplarStep(se);
		}

		protected override void ResetExemplar() {
			base.ResetExemplar();
			PuissanceEsprit.BaseValue = 0;
			if(_asserved != null)
				Caracteristiques.MaxChance.RemoveModifier(_asserved);
		}
		protected override void ResetModel() {
			base.ResetModel();
			/* remove modifier from old skills */
			foreach(Competence cp in Competences.Competences) {
				cp.Rang.RemoveModifier(PuissanceEsprit);
			}
		}
	}
	/// <summary>
	/// Modificateur divisant par 2 la chance de l'esprit.
   /// Doit être utilisé si celui-ci est asservi.
	/// </summary>
	public class AsservedSpirit : DerivedValue {

		private Value _chance;

		public AsservedSpirit( Value chance ) : base(chance) {
			_chance = chance;
			Label = "Asservi";
        }

		public override int BaseValue {
			get {
				return  - _chance.BaseValue / 2;
			}
		}
	}
}
