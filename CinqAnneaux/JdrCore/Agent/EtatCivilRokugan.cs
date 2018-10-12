using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.Data;

namespace CinqAnneaux.JdrCore.Agent {
	public class EtatCivilRokugan : EtatCivil {

		public void SetPersonnage(PersonnageModel perso)
		{
			Name = perso.Name;
			Description = perso.Description.Description;
		}
	}
}
