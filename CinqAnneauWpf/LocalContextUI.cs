using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using CoreWpf;
using CoreWpf.UI;
using CinqAnneaux.Data;
using CinqAnneauxWpf.CreationPersonnage;
using CinqAnneauxWpf.Fiches;
using Core.Contexts;
using System.Resources;
using CinqAnneauxWpf.Langues;

namespace CinqAnneauxWpf
{
	public class LocalContextUI : DefaultJdrContextWPF, IJdrContextWPF
	{
		#region Members
		private IFicheCandidate FicheAgent;
		private IFicheCandidate FicheGestionPersonnage;
		private IFicheCandidate FicheClanFamilleEcole;
		private IFicheCandidate FicheAvantages;
		private IFicheCandidate FicheObjets;
		private IFicheCandidate FicheSorts;
		private IFicheCandidate FicheRangsHonneur;
		private IFicheCandidate FicheCapacites;
		private IFicheCandidate FicheCompetences;
		private IFicheCandidate FicheMassCombat;
		private IFicheCandidate FicheAncetres;
		#endregion

		#region Init
		public void InitFiches()
		{
			/* instanciate fiches */
			FicheAgent = new FicheLecture<CreatureModel, FicheAgent>("Creatures");
			FicheGestionPersonnage = new FicheGestionPersonnage();
			FicheClanFamilleEcole = new FicheCandidateClanFamilleEcole();
			FicheAvantages = new FicheAvantageDesavantage();
			FicheObjets = new FicheAllObjets();
			FicheSorts = new CandidateSortsMahou();
			FicheRangsHonneur = new FicheHonneur();
			FicheCapacites = new FicheCandidateCapacites();
			FicheCompetences = new FicheCandidateCompetences();
			FicheMassCombat = new FicheMassCombat();
			FicheAncetres = new FicheListeAncetres();
			AddFiche(FicheClanFamilleEcole);
			AddFiche(FicheAvantages);
			AddFiche(FicheObjets);
			AddFiche(FicheSorts);
			AddFiche(FicheCapacites);
			AddFiche(FicheRangsHonneur);
			AddFiche(FicheCompetences);
			AddFiche(FicheGestionPersonnage);
			AddFiche(FicheAgent);
			AddFiche(FicheMassCombat);
			AddFiche(FicheAncetres);

		}

		public LocalContextUI(IGlobalContext ctxt) : base(ctxt, Fr.ResourceManager) {
			InitFiches();
		}
		#endregion
		
	}
}
