using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Attributs;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Gestion;
using CinqAnneaux.JdrCore.Ecoles;

namespace CinqAnneaux.JdrCore.Agent {
	public class Personnage : Agent {

		#region Members
		private Value pointsHonneur = new Value();
		private Value pointsGloire = new Value();
		private Value pointsStatus = new Value();
		#endregion

		#region Properties
		public Joueur Joueur { get; set; }
		public RangReputation Reputation { get; }
		public RankedCarac Honneur { get; }
		public RankedCarac Gloire { get; }
		public RankedCarac Status { get; }
		public Famille Famille { get;}
		public Clan Clan { get;}
		public ListeEcoles Ecoles { get; }
		#endregion

		#region Init
		public Personnage() {
			/* init les caractéristiques spécifiques */
			Reputation = new RangReputation(this);
			Honneur = new RankedCarac(pointsHonneur) { Label = "Honneur" };
			Gloire = new RankedCarac(pointsGloire) { Label = "Gloire" };
			Status = new RankedCarac(pointsStatus) { Label = "Status" };
			/* linker l'initiative */
			Initiative.KeepValue.AddModifier(Attributs.Reflexes);
			Initiative.NumberValue.AddModifier(Attributs.Reflexes);
			Initiative.NumberValue.AddModifier(Reputation);
			/* vie */
			Vie = new SeuilViePJ(this);
			//autres
			Famille = new Famille();
			Clan = new Clan();
			Ecoles = new ListeEcoles(this);
        }
		#endregion

		public override void SetPersonnage( PersonnageModel perso ) {
			base.SetPersonnage(perso);
			PJModel model = (PJModel)perso;
			//TODO : init set pj
			/* clear everything */
			ClearAttaques();
			Ecoles.ClearSchools();
			/* set values */
			Famille.SetModel(model.Famille);
			Clan.SetModel(model.Clan);
		}
	}
}
