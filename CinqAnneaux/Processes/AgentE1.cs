using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.JdrCore.Ecoles;
using Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.Processes
{
	/// <summary>
	/// Choose a Clan, a Familly and school.
	/// </summary>
	public class AgentE1 : IProcessStep
	{
		#region Members
		private ClanModel _selectedClan;
		private PersonnageProcess _pross;
		#endregion

		#region Properties
		public IEnumerable<ClanModel> SelectableClan { get; private set; }
		public ClanModel SelectedClan
		{
			get
			{
				return _selectedClan;
			}
			set
			{
				if (_selectedClan != value)
				{
					_selectedClan = value;
					//Reset dependant
					SelectedFamily = null;
					SelectedSchool = null;
				}
			}
		}
		public IEnumerable<FamilleModel> SelectableFamily { get; private set; }
		public FamilleModel SelectedFamily { get; set; }
		public IEnumerable<EcoleModel> SelectableSchool { get; private set; }
		public EcoleModel SelectedSchool { get; set; }
		private Personnage Personnage { get { return _pross.Personnage; } }
		public PersonnageParameters Params { get { return (PersonnageParameters)_pross.Parameters; } }
		#endregion

		public bool CanProgress(out string errorMessageTag)
		{
			bool error = false;
			errorMessageTag = "";
			if (SelectedClan == null)
			{
				errorMessageTag = "You must choose a Clan";
				error = true;
			}
			if (SelectedFamily == null)
			{
				errorMessageTag = "You must choose a Family";
				error = true;
			}
			if (SelectedSchool == null)
			{
				errorMessageTag = "You must choose a School";
				error = true;
			}
			return !error;
		}

		public void Init(IProcess process)
		{
			_pross = (PersonnageProcess)process;

			SelectedClan = null;
			SelectedFamily = null;
			SelectedSchool = null;

			//Clan filters
			SelectableClan = process.Data.GetTable<ClanModel>()
				.Where(c=> c.Tag != "CLN0009" || Params.SpiderClanAllowed)
				.Where(c => c.Tag == "CLN0009" || c.TypeClan != TypeClan.Majeur || Params.MajorClanAllowed)
				.Where(c => c.TypeClan != TypeClan.Mineur || Params.MinorClanAllowed)
				.Where(c => c.TypeClan != TypeClan.Confrerie || Params.MonkAllowed)
				.Where(c => c.Tag != "CLN0000" || Params.RoninAllowed)
				.Where(c => c.Tag != "CLN0010" || Params.ImperialClanAllowed)
				.OrderBy(c => c.Tag);
			SelectableSchool = process.Data.GetTable<EcoleModel>()
				.Where(s => s.Devotion == null || Params.MonkAllowed)
				.Where(s => (s.Balise != BaliseEcole.Bushi && s.Balise != BaliseEcole.Ninja) || Params.BushiAllowed)
				.Where(s => (s.Balise != BaliseEcole.Courtisan && s.Balise != BaliseEcole.Artisan) || Params.CourtierAllowed)
				.Where(s => s.Devotion != null || (s.Balise != BaliseEcole.Shugenja && s.Balise != BaliseEcole.Moine) || Params.ShugenjaAllowed)
				.OrderBy(n => n.Name);
			SelectableFamily = process.Data.GetTable<FamilleModel>().OrderBy(n => n.Name);
		}

		public void Reset(){ /* Nothing */ }

		public void PreprossNext()
		{
			//clan
			Personnage.Clan.SetModel(SelectedClan);
			//famille
			Personnage.Famille.SetModel(SelectedFamily);
			Personnage.Attributs.GetAttribut(Personnage.Famille.BonusTrait).BaseValue++;
			//ecole
			Ecole e = new Ecole();
			e.SetModel(SelectedSchool);
			Personnage.Ecoles.AddEcole(e, 1);
			Personnage.Attributs.GetAttribut(e.BonusTrait).BaseValue++;
			//TODO Argent
			// gloire, status et honneur
			Personnage.Status.SetRank(1, 0);
			Personnage.Gloire.SetRank(1, 0);
			Personnage.Souillure.SetRank(0, 0);
			Personnage.Honneur.SetRank(e.HonneurInitial);
		}

		public void PreprossReset(){ /* Nothing to do */ }
	}
}
