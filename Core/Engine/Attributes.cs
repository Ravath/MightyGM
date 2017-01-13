using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Engine {
	public class Attributes {

		#region Init
		/// <summary>
		/// Initialise les attributs avec une valeur par défaut.
		/// </summary>
		/// <param name="enumType">Le type de l'attribut</param>
		/// <param name="defaultValue"></param>
		public Attributes( Type enumType, int defaultValue ) {
			if(!enumType.IsEnum)
				throw new ArgumentException("Attribute class expects an enumerable type.");
			_enumType = enumType;
            foreach(Enum item in Enum.GetValues(enumType)) {
				_atts.Add(item, defaultValue);
			}
		}
		#endregion

		#region members
		private Type _enumType;
		private Dictionary<Enum, int> _atts = new Dictionary<Enum, int>();
		#endregion

		#region Properties
		/// <summary>
		/// Accès aux attributs avec l'Enum associée.
		/// </summary>
		/// <param name="index">L'attribut désiré.</param>
		/// <returns>La valeur de l'attribut.</returns>
		public int this[Enum index] {
			get { return _atts[index]; }
			set { _atts[index] = value; }
		}
		/// <summary>
		/// Le type de l'Enum utilisée pour ces attributs.
		/// </summary>
		public Type EnumType { get { return _enumType; } }
		#endregion

	}
}
