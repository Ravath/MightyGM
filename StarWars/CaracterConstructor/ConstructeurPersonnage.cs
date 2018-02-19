using Core.Data;
using Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.CaracterConstructor {
	public class ConstructeurPersonnage : StepsWindow {

		public ConstructeurPersonnage( Database dt ) : base(GetSteps(), new StarwarsPJConstructionArguments(dt)) {

		}

		private static IEnumerable<Step> GetSteps() {
			List<Step> _steps = new List<Step>();
			_steps.Add(new InitStep());
			_steps.Add(new ObligationStep());
			_steps.Add(new ChoixRace());
			_steps.Add(new ChoixCarriere());
			_steps.Add(new ChoixSpecialite());
			_steps.Add(new EditionEtatCivil());

			return _steps;
		}
	}
}
