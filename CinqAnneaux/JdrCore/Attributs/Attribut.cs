using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Attributs {
	public class Attribut : Value {
		public Attribut() : base(2){ }
	}

	/// <summary>
	/// Un anneau élémentaire de L5R, sauf le vide.
	/// </summary>
	public class Anneau : DerivedValue {
		private Attribut _a1;
		private Attribut _a2;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="a1">attribut physique dont dépend l'anneau.</param>
		/// <param name="a2">attribut mental dont dépend l'anneau.</param>
		public Anneau( Attribut a1, Attribut a2 ) : base(a1, a2) {
			_a1 = a1;
			_a2 = a2;
		}

		public override int BaseValue {
			get {
				return Math.Min(_a1.BaseValue, _a2.BaseValue);
			}
		}
	}
}
