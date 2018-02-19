using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.FormesComplexes {
	public class FormeComplexe {

		#region Members
		private ComplexFormModel _model;
		#endregion

		#region Properties
		public string Name {
			get { return _model.Name; }
		}
		#endregion

		public FormeComplexe( ComplexFormModel cfm ) {
			_model = cfm;
		}
	}
}
