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
		private Value _rank = new Value(0);
		private RollAndKeep _pool;
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
		public string Tag { get; set; }

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

		/// <summary>
		/// Used for competence tests.
		/// Don't forget to adapt reroll of 1 and 10 if the competence is trained or specialised.
		/// </summary>
		public RollAndKeep Pool { get { return _pool; } }

		public int Rang {
			get { return _rank.BaseValue; }
			set { _rank.BaseValue = value; }
		}

		public IEnumerable<Specialisation> Specialisations {
			get { return _specialite; }
		}
		/// <summary>
		/// Return the unlocked masteries.
		/// </summary>
		public IEnumerable<Maitrise> CurrentMaitrises {
			get { return _maitrise.Where(m => m.Rang <= _pool.RollValue.BaseValue); }
		}
		/// <summary>
		/// Return all the masteries.
		/// </summary>
		public IEnumerable<Maitrise> AllMaitrises {
			get { return _maitrise; }
		}
		#endregion

		#region Init
		public Competence() { _pool = new RollAndKeep(_rank, new Value(0)); }
		/// <summary>
		/// Set the attribute used for this competence.
		/// </summary>
		/// <param name="attribut"></param>
		public void SetAttribut( Attribut attribut ) {
			if(_att == attribut) { return; }
			/* remove former */
			if(_att != null) {
				_pool.KeepValue.RemoveModifier(_att);
				_pool.RollValue.RemoveModifier(_att);
			}
			/* set */
			_att = attribut;
			/* add new */
			if(attribut != null)
			{
				_pool.KeepValue.AddModifier(_att);
				_pool.RollValue.AddModifier(_att);
			}
		}

		public void SetAttribut( Attributs.Attributs attribut ) {
			SetAttribut(attribut.GetAttribut(Trait));
		}
		#endregion

		#region Model Setters
		private void SetCompetence( CompetenceModel model ) {
			/* val de base */
			if (model.Global != null)
			{
				Nom = model.Global.Name+"("+model.Name+")";
			}
			else
			{
				Nom = model.Name;
			}
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

		public bool HasSpeciality(string speTag)
		{
			foreach (var item in _specialite)
			{
				if(item.Tag == speTag) { return true; }
			}
			return false;
		}

		public void SetCompetence( CompetenceExemplar ex ) {
			SetCompetence(ex.Model);
			Rang = ex.Rang;
			_specialite.Clear();
			foreach (SpecialisationModel spmodel in ex.SpecialisationsChoisies)
			{
				_specialite.Add(new Specialisation(spmodel));
			}
		}
		public void SetCompetence(CompetenceStatus ex)
		{
			SetCompetence(ex.Competence);
			Rang = ex.Rang;
			_specialite.Clear();
			if(ex.Specialite!=null)
				_specialite.Add(new Specialisation(ex.Specialite));
		}
		#endregion

	}
}
