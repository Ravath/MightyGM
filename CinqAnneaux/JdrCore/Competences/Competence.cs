using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Attributs;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Competences {

	public class Competence {

		#region Members
		private string _nom;
		private RKPool _pool = new RKPool();
		private Attribut _att;
		private List<Specialisation> _specialite = new List<Specialisation>();
		private List<Maitrise> _maitrise = new List<Maitrise>();
		private GroupeCompetence _groupe;
		#endregion

		#region Properties
		public bool Degradante { get; protected set; }
		public bool Noble { get; protected set; }
		public bool Sociale { get; protected set; }
		public bool Martiale { get; protected set; }

		public string Nom {
			get { return _nom; }
			protected set {
				TextInfo info = CultureInfo.CurrentCulture.TextInfo;
				_nom = info.ToTitleCase(value);
			}
		}
		public string Description { get; set; }

		public GroupeCompetence Groupe {
			get { return _groupe; }
			set {
				_groupe = value;
				if(_groupe == GroupeCompetence.Noble)
					Noble = true;
				if(_groupe == GroupeCompetence.Degradante)
					Degradante = true;
			}
		}
		public TraitCompetence Trait { get; protected set; }
		public TraitCompetence? TraitAlternatif { get; protected set; }

		public RKPool Pool { get { return _pool; } }
		public int Rang {
			get { return _pool.NumberValue.BaseValue; }
			set { _pool.NumberValue.BaseValue = value; }
		}

		public IEnumerable<Specialisation> Specialisations {
			get { return _specialite; }
		}
		/// <summary>
		/// Return the unlocked masteries.
		/// </summary>
		public IEnumerable<Maitrise> CurrentMaitrises {
			get { return _maitrise.Where(m => m.Rang <= _pool.NumberValue.BaseValue); }
		}
		/// <summary>
		/// Return all the masteries.
		/// </summary>
		public IEnumerable<Maitrise> AllMaitrises {
			get { return _maitrise; }
		}

		public string Tag {
			get;
			private set;
		}
		#endregion

		#region Init
		public Competence() { }
		/// <summary>
		/// Set the attribute used for this competence.
		/// </summary>
		/// <param name="attribut"></param>
		public void SetAttribut( Attribut attribut ) {
			/* remove former */
			if(_att != null) {
				_pool.KeepValue.RemoveModifier(_att);
				_pool.NumberValue.RemoveModifier(_att);
			}
			/* set */
			_att = attribut;
			/* add new */
			if(attribut != null) {
				_pool.KeepValue.AddModifier(_att);
				_pool.NumberValue.AddModifier(_att);
			}
		}
		public void SetAttribut( Attributs.Attributs attribut ) {
			SetAttribut(attribut.GetAttribut(Trait));
		}
		#endregion
		#region Model Setters
		private void SetCompetence( CompetenceModel model ) {
			/* val de base */
			Nom = model.Name;
			Degradante = model.Degradante;
			Sociale = model.Sociale;
			Martiale = model.Martiale;
			Groupe = model.Groupe;
			Tag = model.Tag;
			Description = model.Description.Description;
			/* attributs */
			Trait = model.TraitAssocie;
			TraitAlternatif = model.TraitAlternatif;
			/* ajouter les maitrise */
			_maitrise.Clear();
            foreach(MaitriseModel maitrise in model.Maitrises.OrderBy(m=>m.RangRequis)) {
				_maitrise.Add(MaitriseInstanciator.Instanciate(maitrise));
            }
		}
		public void SetCompetence( CompetenceExemplar ex ) {
			SetCompetence(ex.Model);
			Rang = ex.Rang;
			_specialite.Clear();
			//foreach(Data.Specialisation spe in ex.Specialisation) {
			//TODO : Specialisations
			//Specialisation spe = new Specialisation();
			//spe.SetSpecialisation(ex.Specialisation);
			//_spe.Add(spe);
			//}
		}
		private void SetCompetenceGlobale( CompetenceGlobaleModel model ) {
			Nom = model.Name;
			Trait = model.TraitAssocie;
			Groupe = model.Groupe;
			Description = model.Description.Description;
			_specialite.Clear();
			_maitrise.Clear();
        }
		public void SetCompetenceGlobale( CompetenceGlobaleExemplar ex ) {
			SetCompetenceGlobale(ex.Model);
			Nom += string.Format("({0})", ex.Specialisation);
			Rang = ex.Rang;
			Degradante = ex.Specialisation.Degradante;
			Trait = ex.Specialisation.TraitAssocie;
			Tag = ex.Specialisation.Tag;
		}
		#endregion

	}
}
