using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shadowrun5.JdrCore;
using Shadowrun5.JdrCore.Agents;

namespace Shadowrun5Wpf.CreationPersonnage {
	public class StepKarma : Step {

		#region Members
		private ParametresCreationPJ _args;
		#endregion

		#region Step Implementation
		public override bool CanProgress( out string errorMessage ) {
			errorMessage = "";
			bool errors = false;
			//début tests

			//fin tests
			if(!errors)
				GoNext(_args.Personnage);
			return !errors;
		}

		private void GoNext( Personnage p ) {
			return;
		}

		public override void GoBack() { /*nothing*/ }

		public override void Init( IStepsArgument args ) {
			_args = (ParametresCreationPJ)args;
		}
		#endregion
	}
}
