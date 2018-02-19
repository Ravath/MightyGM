using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Sorts {
	public class Sort {

		#region Members
		private SpellModel _model;
		#endregion

		#region Properties
		public string Name {
			get { return _model.Name; }
		}
		public bool AreaOfEffect {
			get { return _model.AreaOfEffect; }
		}
		public PowerType Type {
			get { return _model.Type; }
		}
		public int DrainModifier {
			get { return _model.DrainModifier; }
		}
		#endregion

		public Sort( SpellModel sp ) {
			_model = sp;
		}

		public override string ToString() {
			return Name;
		}
	}
}
