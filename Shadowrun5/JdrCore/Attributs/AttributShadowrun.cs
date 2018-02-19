using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Attributs {
	/// <summary>
	/// Un attribut Shadowrun pour les 8 caractéristiques principales, qui ne peuvent pas descendre en dessous de 0.
	/// </summary>
	public class BaseAttributShadowrun : AttributShadowrun {
		public override int TotalValue {
			get {
				return Math.Max(1, base.TotalValue);
			}
		}
	}

	public class AttributShadowrun : Value {
		private BoolCapacity _exceptAttribute;

		public AttributShadowrun() : base( ){
			AttributExceptionnel = new BoolCapacity();
        }

		public BoolCapacity AttributExceptionnel {
			get { return _exceptAttribute; }
			set { _exceptAttribute = value; }
		}

		public int MaximumBaseAttribut {
			get {
				return AttributExceptionnel.Accessible ? 6 : 7;
            }
		}
		/// <summary>
		/// retourne la somme des modifieurs du type donné.
		/// </summary>
		/// <param name="tm">Si pas de type (car pas des Modifiers Shadowrun), considéré comme défault.</param>
		/// <returns></returns>
		public int GetSumFromModifierType( TypeModifier tm ) {
			if(tm == TypeModifier.Default) {
				return Modifiers.OfType<ModifierShadowrun>().Where(ms => ms.Type == tm).Sum(m => m.TotalValue)
					+ Modifiers.Except(Modifiers.OfType<ModifierShadowrun>()).Sum(m => m.TotalValue);
			}
			return Modifiers.OfType<ModifierShadowrun>().Where(ms => ms.Type == tm ).Sum(m=>m.TotalValue);
		}
	}

	public class ModifierShadowrun : Value {
		public TypeModifier Type { get; set; }

		public ModifierShadowrun() : base(){ }

		public override string Label {
			get {
				return Type.ToString();
			}
		}

	}

	public enum TypeModifier {
		Default=0, Racial, Cybernetique, Drogue, Magie, Pouvoir/*adepte*/
	}
}
