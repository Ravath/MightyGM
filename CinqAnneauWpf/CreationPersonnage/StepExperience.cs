using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinqAnneauxWpf.CreationPersonnage {
	public class StepExperience : Step {

		#region Members
		private ParametresCreationPJ _params;
		#endregion

		#region Step Implementation
		public override bool CanProgress( out string errorMessage ) {
			StackPanel spModules = new StackPanel();
			AddChild(spModules);
			throw new NotImplementedException();
		}

		public override void GoBack() {/* nothing */}

		public override void Init( IStepsArgument args ) {
			_params = (ParametresCreationPJ)args;
		}
		#endregion
	}
}
