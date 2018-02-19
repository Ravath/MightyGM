using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.Data;

namespace CinqAnneaux.JdrCore.Traits {

	public class Technique : GeneralTrait {

		public int Rank { get; private set; }

		public void SetModel( TechniqueModel model ) {
			Name = model.Name;
			Rank = model.Rang;
			Description = model.Description.Description;
			Delegate = TechniqueImplementation.GetImplementation(model.Tag);
		}
	}
}
