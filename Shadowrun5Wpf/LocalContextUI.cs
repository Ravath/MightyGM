using System;
using System.Collections.Generic;
using Core;
using CoreWpf;
using CoreWpf.UI;
using Shadowrun5.Data;
using Shadowrun5Wpf.Fiches;
using Shadowrun5.JdrCore;
using Shadowrun5Wpf.CreationPersonnage;
using Core.Contexts;
using Shadowrun5Wpf.Langues;

namespace Shadowrun5Wpf
{
	public class LocalContextUI : DefaultJdrContextWPF, IJdrContextWPF
	{

		#region Members
		private IFicheCandidate FichePersonnage;
		private IFicheCandidate FicheEsprits;
		private IFicheCandidate FicheGrunts;
		#endregion

		#region Init
		public void InitFiches()
		{
			/* instanciate fiches */
			FichePersonnage = new FicheGestionPersonnage();
			FicheEsprits = new FicheLecture<SpiritModel, FicheEsprit>("Spirits");
			FicheLecture<GruntModel, FicheGrunt> fg = new FicheLecture<GruntModel, FicheGrunt>("Grunts");
			fg.AfficherEvent += AffichageGrunt_event;
			FicheGrunts = fg;
			AddFiche(FichePersonnage);
			AddFiche(FicheEsprits);
			AddFiche(FicheGrunts);
		}

		public LocalContextUI(IGlobalContext ctxt) : base(ctxt, Fr.ResourceManager) {
			InitFiches();
		}
		#endregion

		private void AffichageGrunt_event(FicheLecture<GruntModel, FicheGrunt> sender, IGlobalContext context)
		{
			/* set list of metatypes of the grunt fiche */
			List<Metatype> metas = new List<Metatype>();
			foreach (MetatypeModel mm in context.Data.GetTable<MetatypeModel>())
			{
				metas.Add(Instanciator.GetMetatype(mm));
			}
			sender.Fiche.Metatypes = metas;
		}
	}
}
