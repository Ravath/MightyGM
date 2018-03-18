using CinqAnneaux.Data;
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
		private ClanModel _selectedClan;
		private AgentProcess _pross;
		private AgentParameters _params;

		public IEnumerable<ClanModel> SelectableClan { get; private set; }
		public ClanModel SelectedClan{
			get
			{
				return _selectedClan;
			}
			set
			{
				if(_selectedClan != value)
				{
					_selectedClan = value;
					//Reset dependant selectables
					SelectableFamily = _selectedClan?.Familles;
					SelectableSchool = _selectedClan?.Ecoles;
					SelectedFamily = null;
					SelectableSchool = null;
				}
			}
		}
		public IEnumerable<FamilleModel> SelectableFamily { get; private set; }
		public FamilleModel SelectedFamily{ get; set; }
		public IEnumerable<EcoleModel> SelectableSchool { get; private set; }
		public EcoleModel SelectedEcole{ get; set; }

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
			if (SelectedEcole == null)
			{
				errorMessageTag = "You must choose a School";
				error = true;
			}
			return !error;
		}

		public void Init(IProcess process, IProcessParameters parameters)
		{
			_pross = (AgentProcess)process;
			_params = (AgentParameters)parameters;

			SelectedClan = null;
			SelectedFamily = null;
			SelectableSchool = null;
			////init attributes
			//foreach (var item in _params.Personnage.Attributs.AllAttributs)
			//{
			//	item.BaseValue = 2;
			//}
			//_params.Personnage.Attributs.MaxVide.BaseValue = 2;
			////set data
			//fiche.SetData(_params.Data);
			////todo : filter with creation parameters (ronin, monk, minor clan,...)
		}

		public void Reset()
		{
			/* Nothing */
		}

		public void PreprossNext()
		{
			////clan
			//personnage.Clan.SetModel(fiche.SelectedClan);
			////famille
			//personnage.Famille.SetModel(fiche.SelectedFamille);
			//personnage.Attributs.GetAttribut(personnage.Famille.BonusTrait).BaseValue++;
			////ecole
			//Ecole e = new Ecole();
			//e.SetModel(fiche.SelectedEcole);
			//personnage.Ecoles.AddEcole(e, 1);
			//personnage.Attributs.GetAttribut(e.BonusTrait).BaseValue++;
			////TODO Compétences
			////TODO Equipement
			////TODO Argent
			//// gloire, status et honneur
			//personnage.Status.SetRank(1, 0);
			//personnage.Gloire.SetRank(1, 0);
			//personnage.Souillure.SetRank(0, 0);
			//personnage.Honneur.SetRank(e.HonneurInitial);
		}

		public void PreprossReset()
		{
			throw new NotImplementedException();
		}
	}
}
