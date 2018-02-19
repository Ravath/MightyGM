using Core.Data;
using Core.Engine;
using Core.Gestion;
using StarWars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.CaracterConstructor {
	public class SWCaracterBuild {

		public SWCaracterBuild() {
			EtatCivil = new EtatCivil();
        }

		public Joueur Joueur { get; set; }
		public string Name {
			get { return EtatCivil.Name; }
			set { EtatCivil.Name = value; }
		}

		public EtatCivil EtatCivil { get; set; }

		#region Obligations
		private List<ObligationsExemplar> _obligations = new List<ObligationsExemplar>();
		public void ClearObligations() {
			_obligations.Clear();
        }
		public void AddObligation(ObligationsExemplar oe ) {
			if(oe == null) { return; }
			_obligations.Add(oe);
		}
		#endregion

		public RaceModel Race { get; set; }

		public CarriereModel Carriere { get; set; }

		public SpecialiteModel Specialite { get; set; }

		/// <summary>
		/// L'argent;
		/// </summary>
		public int Credits {
			get;
			set;
		}
		private XPaPoints _xp = new XPaPoints();
		public XPaPoints XP {
			get {
				return _xp;
            }
		}

		private List<CompetenceExemplar> _competences = new List<CompetenceExemplar>();

		public void AddCompetence( CompetenceExemplar newComp ) {
			_competences.Add(newComp);
        }

		public IEnumerable<CompetenceModel> GetCompetencesAccessibles() {
			return Specialite.Competences.Union(Carriere.Competences);
		}

		public PJModel CreateModel() {
			PJModel p = new PJModel();

			p.Name = Name;
			p.Joueur = Joueur;
			p.Obligations = _obligations;
			p.Race = Race;
			p.CarrierePrincipale = Carriere;
			p.SpecialitePrincipale = Specialite;
			p.Credits = Credits;
			p.TotalXp = XP.TotalXp;
			p.XpDepense = XP.XpDepense;
			PJDescription pd = p.Description as PJDescription;
			pd.Age = EtatCivil.Age;
			pd.Cheveux = EtatCivil.Cheveux;
			pd.Carrure = EtatCivil.Carrure;
			pd.Taille = EtatCivil.Taille;
			pd.Yeux = EtatCivil.Yeux;
			pd.SexeMasculin = EtatCivil.Male;

			return p;
		}
	}
}