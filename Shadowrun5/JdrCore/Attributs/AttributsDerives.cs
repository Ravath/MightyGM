using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Attributs {
	#region Initiative
	public class Initiative : DerivedValue {
		private AttributShadowrun _att1;
		private AttributShadowrun att2;

		public Initiative( AttributShadowrun att1, AttributShadowrun att2 )
				: base(att1, att2) {
			_att1 = att1;
			this.att2 = att2;
		}

		public override int BaseValue { get { return _att1.TotalValue + att2.TotalValue; } }
	}
	#endregion

	#region Limites
	public class Limite : DerivedValue {
		private AttributShadowrun _a1, _a2, _b;
		/// <summary>
		/// A limite of test results.
		/// </summary>
		/// <param name="a1"></param>
		/// <param name="a2"></param>
		/// <param name="b">is the attribute used twice in the average sum.</param>
		public Limite( AttributShadowrun a1, AttributShadowrun a2, AttributShadowrun b ) : base(a1,a2,b) {
			_a1 = a1;
			_a2 = a2;
			_b = b;
		}

		public override int BaseValue {
			get {
				return (int)Math.Ceiling(
				 (double)(_a1.TotalValue + -_a2.TotalValue + _b.TotalValue * 2) / 3
			   );
			}
		}
	}
	#endregion

	#region Moniteurs
	public class MaxMoniteurValue : DerivedValue {
		AttributShadowrun _att;

		public MaxMoniteurValue( AttributShadowrun baseAttribute ) : base(baseAttribute) {
			_att = baseAttribute;
        }

		public override int BaseValue { get { return (int)Math.Ceiling((double)_att.TotalValue / 2) + 8; } }
	}
	public class Moniteur : CompositeJauge {
		public Moniteur( MaxMoniteurValue max ) : base(0, max, max.TotalValue){ }

	}
	#endregion

	public class Credibilite : DerivedValue {

		private IJauge _karma;

		public Credibilite( IJauge karma ) {
			_karma = karma;
			Label = "Credibilité";
        }

		public override int BaseValue {
			get {
				return _karma.MaxValue/10;//arrondi à l'inférieur
			}
		}
	}
}
