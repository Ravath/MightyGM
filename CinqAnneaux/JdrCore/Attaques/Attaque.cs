using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Competences;
using CinqAnneaux.JdrCore.Objets;

namespace CinqAnneaux.JdrCore.Attaques {
	public interface IAttaque {
		AbsRKPool JetAttaque { get ;}
		AbsRKPool Degats { get; }
		Data.Action Action { get; }
		string Name { get; }
	}

	public class AttaqueCreature : IAttaque {

		public string Name { get; protected set; }
		public AbsRKPool JetAttaque { get; private set; }
		public AbsRKPool Degats { get; private set; }
		public Data.Action Action { get; private set; }

		public AttaqueCreature(Data.AttaqueCreature att) {
			JetAttaque = new RKPool();
			Degats = new RKPool();
			Degats.Keep = att.gxDegats;
			Degats.Number = att.xgDegats;
			JetAttaque.Keep = att.gxToucher;
			JetAttaque.Number = att.xgToucher;
			Action = att.Action;
			Name = att.Name;
        }

		public void SetAttaqueCreature( Data.AttaqueCreature att ) {
			JetAttaque = new RKPool();
			Degats = new RKPool();
			Degats.Keep = att.gxDegats;
			Degats.Number = att.xgDegats;
			JetAttaque.Keep = att.gxToucher;
			JetAttaque.Number = att.xgToucher;
			Action = att.Action;
			Name = att.Name;
		}
	}

	public class AttaqueArme : IAttaque {

		public Arme Arme { get; private set; }

		public string Name { get { return Arme.Name; } }
		public AbsRKPool JetAttaque { get; private set; }
		public AbsRKPool Degats { get { return Arme.Degats; } }
		public Data.Action Action { get; private set; }

		public AttaqueArme() { }

		public void SetArme( Arme arme , Agent.Agent agent ) {
			Arme = arme;
			Action = Data.Action.Complexe;
			/* find used compétence */
			Competence cpt = agent.Competences.GetCompetenceArme(arme.Type);
			JetAttaque = new CompositeRKPool(cpt.Pool);
			//TODO spécialisation compétence
		}
	}
}
