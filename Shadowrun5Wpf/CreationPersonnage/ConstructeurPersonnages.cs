using Core.Data;
using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5Wpf.CreationPersonnage {
	public class ConstructeurPersonnages : StepsWindow {
		public ConstructeurPersonnages( Database dt ) : base(GetSteps(), new ParametresCreationPJ(dt)) {

		}

		private static IEnumerable<Step> GetSteps() {
			List<Step> _steps = new List<Step>();
			_steps.Add(new InitStep());
			_steps.Add(new StepTableDesPriorites());
            _steps.Add(new StepAttributs());
            _steps.Add(new StepMagie());
            _steps.Add(new StepAvantages());
            _steps.Add(new StepCompetences());
            _steps.Add(new StepInventaire());
            _steps.Add(new StepKarma());

			return _steps;
		}
	}
}
