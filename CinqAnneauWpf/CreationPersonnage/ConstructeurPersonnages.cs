using Core.Data;
using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneauxWpf.CreationPersonnage {
	public class ConstructeurPersonnages : StepsWindow {

		public ConstructeurPersonnages( Database dt ) : base(GetSteps(), new ParametresCreationPJ(dt)) {

		}

		private static IEnumerable<Step> GetSteps() {
			List<Step> _steps = new List<Step>();
			_steps.Add(new InitStep());
			_steps.Add(new StepClan());
			_steps.Add(new StepExperience());

			return _steps;
		}
	}
}
