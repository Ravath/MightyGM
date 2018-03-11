﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Competences;
using CinqAnneaux.JdrCore.Objets;

namespace CinqAnneaux.JdrCore.Attaques {
	public interface IAttaque {
		RollAndKeep JetAttaque { get ;}
		RollAndKeep Degats { get; }
		Data.Action Action { get; }
		string Name { get; }
	}

	public class AttaqueCreature : IAttaque {

		public string Name { get; protected set; }
		public RollAndKeep JetAttaque { get; private set; }
		public RollAndKeep Degats { get; private set; }
		public Data.Action Action { get; private set; }

		public AttaqueCreature(Data.AttaqueCreature att) {
			SetAttaqueCreature(att);
        }

		public void SetAttaqueCreature( Data.AttaqueCreature att )
		{
			JetAttaque = new RollAndKeep(att.gxToucher, att.xgToucher);
			Degats = new RollAndKeep(att.gxDegats, att.xgDegats);
			Action = att.Action;
			Name = att.Name;
		}
	}

	public class AttaqueArme : IAttaque {

		public Arme Arme { get; private set; }

		public string Name { get { return Arme.Name; } }
		public Competence Competence { get; set; }
		public RollAndKeep JetAttaque { get { return Competence.Pool; } }
		public RollAndKeep Degats { get { return Arme.Degats; } }
		public Data.Action Action { get; private set; }

		public AttaqueArme() { }

		public void SetArme( Arme arme , Agent.Agent agent ) {
			Arme = arme;
			Action = Data.Action.Complexe;
			/* find used compétence */
			Competence = agent.Competences.GetCompetenceArme(arme.Type);
			//TODO spécialisation compétence
		}
	}
}
