using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Capacites {

	public class Kata : AbsElementalCapacity {
		#region Properties
		public override double Range {
			get { return 0; }
		}
		public override bool CanAffectMultipleTargets {
			get { return false; }
		}
		public override TargetType TargetType {
			get { return TargetType.Self; }
		}
		#endregion

		public void SetKataModel( KataModel model ) {
			Name = model.Name;
			Anneau = model.Anneau;
			Rank = model.Maitrise;
			Delegate = KataImplementer.GetImplementation(model.Tag);
		}
	}
}
