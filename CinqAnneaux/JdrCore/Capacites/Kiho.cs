using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Capacites {
	public class Kiho : AbsElementalCapacity {
		#region Properties
		public bool Atemi { get; private set; }
		public TypeKiho Type { get; private set; }
		public override double Range {
			get { return 0; }
		}
		public override bool CanAffectMultipleTargets {
			get { return false; }
		}
		public override TargetType TargetType {
			get {
				if(Atemi)
					return TargetType.Agent;
				return TargetType.Self;
			}
		}
		#endregion

		public void SetKihoModel( KihoModel model ) {
			Name = model.Name;
			Anneau = model.Anneau;
			Rank = model.Maitrise;
			Atemi = model.UseAtemi;
			Type = model.Type;
			Delegate = KihoImplementer.GetImplementation(model.Tag);
        }
	}
}
