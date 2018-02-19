using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Attributs {
	public class RecuperationRate : DerivedValue {
		private Attribut _con;
		public override int BaseValue {
			get {
				return _con.TotalValue *2;
			}
		}

		public RecuperationRate( Attribut constitution ) : base(constitution) {
			_con = constitution;
        }
	}
}
