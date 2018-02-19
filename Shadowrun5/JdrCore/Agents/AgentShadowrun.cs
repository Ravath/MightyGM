using Core.Engine;
using Shadowrun5.JdrCore.Traits;
using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shadowrun5.JdrCore.Attributs;
using Shadowrun5.JdrCore.Sorts;
using Shadowrun5.JdrCore.FormesComplexes;
using Shadowrun5.JdrCore.Competences;

namespace Shadowrun5.JdrCore.Agents {
	/// <summary>
	/// Creature evoluant dans le monde réel de shadowrun.
	/// </summary>
	public abstract class ShadowrunAgent : IAgent {

		private static Magicien TraitsMage = new Magicien();

		#region Members
		private PratiquantMagie _pratiquant;
		private SpecialiteMage? _specialite;
		private List<Sort> _sorts = new List<Sort>();
		private List<FormeComplexe> _complexes = new List<FormeComplexe>();
		#endregion

		#region Properties
		public string Name { get; set; }
		public Caracteristiques Caracteristiques { get; }
		public TraitCollection<ShadowrunAgent, TraitShadowrun> DefaultTraits { get; }
		public CompetencesCollection Competences { get; }
		/// <summary>
		/// Les points de pouvoir des adeptes.
		/// </summary>
		public Value Pouvoir { get; }
		public Value Allonge { get; }
		public Value Armure { get; }
		public Value ModificateurCoutVie { get; }
		public PratiquantMagie Pratiquant {
			get { return _pratiquant; }
			set {
				if(_pratiquant == PratiquantMagie.Magicien || _pratiquant == PratiquantMagie.MageSpecialise) {
					if(value != PratiquantMagie.Magicien || _pratiquant != PratiquantMagie.MageSpecialise)
                        DefaultTraits.RemoveTrait(ShadowrunAgent.TraitsMage);
				} else if(value == PratiquantMagie.Magicien || _pratiquant == PratiquantMagie.MageSpecialise) {
					DefaultTraits.AddTrait(ShadowrunAgent.TraitsMage);
				}
				_pratiquant = value;
			}
		}
		public SpecialiteMage? SpecialiteMage {
			get {
				if(Pratiquant != PratiquantMagie.MageSpecialise)
					return null;
				return _specialite;
			}
			set { _specialite = value; }
		}
		public BoolCapacity PerceptionAstrale { get; }
		public BoolCapacity VisionNocturne { get; }
		public BoolCapacity VisionInfrarouge { get; }
		#endregion

		#region Valeurs Derivées
		public int MagieBase { get { return !UseMagic ? 0 : Pouvoir.BaseValue; } }
		public int MagieTotale { get { return !UseMagic ? 0 : Pouvoir.TotalValue; } }
		public int ResonanceBase { get { return UseResonance ? Pouvoir.BaseValue : 0; } }
		public int ResonanceTotale { get { return UseResonance ? Pouvoir.TotalValue : 0; } }
		public bool UseResonance { get { return Pratiquant == PratiquantMagie.Technomancien; } }
		public bool UseMagic { get { return Pratiquant != PratiquantMagie.Technomancien && Pratiquant != PratiquantMagie.Non; } }
		#endregion

		#region Resistances
		public Value ResistanceToxines { get; }
		public Value ResistanceFeu { get; }
		public Value ResistanceFroid { get; }
		public Value ResistanceElectrique { get; }
		public Value ResistanceAcide { get; }
		#endregion

		#region Init
		public ShadowrunAgent() {
			Caracteristiques = new Caracteristiques(this);
			DefaultTraits = new TraitCollection<ShadowrunAgent, TraitShadowrun>(this);
			Competences = new CompetencesCollection(this);
            Pouvoir = new Value() { Label = "Pouvoir" };
			Allonge = new Value() { Label = "Allonge" };
			Armure = new Value() { Label = "Armure" };
			ModificateurCoutVie = new Value() { Label = "Mod Cour de la vie" };
			Pratiquant = PratiquantMagie.Non;
			PerceptionAstrale = new BoolCapacity();
			VisionInfrarouge = new BoolCapacity();
			VisionNocturne = new BoolCapacity();
			ResistanceToxines = new Value();
			ResistanceFeu = new Value();
			ResistanceFroid = new Value();
			ResistanceElectrique = new Value();
			ResistanceAcide = new Value();
		}
		protected void setCharacterModelStep( CharacterModel c ) {
			if(c == null) { ResetExemplar(); ResetModel(); return; }
			Name = c.Name;
			Caracteristiques.SetModel(c);
			DefaultTraits.Clear();
            foreach(var item in c.Qualities) {
				//TODO : Add Qualities to DefaultTraits, or use a Qualities collection?
			}
			Competences.Clear();
			foreach(SkillExemplar ske in c.Skills) {
				Competences.AddCompetence(new Competence(ske));
			}
            if(c?.Magic > 0) {
				Pratiquant = c.MagicUserType;
				if(c.MagicSpeciality != null) {
					SpecialiteMage = c.MagicSpeciality;
				}
			}
		}
		protected void setCharacterExemplarStep( CharacterExemplar ce ) {
			if(ce == null) { ResetExemplar(); return; }
			Caracteristiques.SetExemplaire(ce);
		}
		protected virtual void ResetModel() {
			Name = "";
			Caracteristiques.ResetModel();
			DefaultTraits.Clear();
			Competences.Clear();
			Pratiquant = PratiquantMagie.Non;
        }
		protected virtual void ResetExemplar() {
			Caracteristiques.ResetExemplaire();
		}
		#endregion

		#region Metatype
		private Metatype _metatype;
		public Metatype Metatype {
			get { return _metatype; }
			set {
				if(value == _metatype)
					return;
				if(_metatype != null)
					_metatype.UnaffectPersonnage(this);
				_metatype = value;
				if( _metatype != null)
					_metatype.AffectPersonnage(this);
			}
		}
		#endregion
		public void AddSpell( Sort sort ) {
			_sorts.Add(sort);
		}
		public void ClearSpellList() {
			_sorts.Clear();
		}
		public IEnumerable<Sort> Sorts {
			get { return _sorts; }
		}
		public void AddFormeComplexe( FormeComplexe fc ) {
			_complexes.Add(fc);
		}
		public void ClearFormeComplexeList() {
			_complexes.Clear();
		}
		public IEnumerable<FormeComplexe> FormesComplexes {
			get { return _complexes; }
		}

		public TargetType TargetType {
			get {
				throw new NotImplementedException();
			}
		}

		public bool IsDead {
			get { return Caracteristiques.MoniteurPhysique.Full; }
		}
	}

}
