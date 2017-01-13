using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyGM.GUIcore {

	/// <summary>
	/// Classe faisant la liaison entre les valeurs utiles et affichées pour la combobox des Nullable Enum.
	/// </summary>
	public class NullEnumVal {
		/// <summary>
		/// Valeur Utile.
		/// </summary>
		public Enum Val { get; set; }
		/// <summary>
		/// Valeur affichée.
		/// </summary>
		public string Name { get; set; }
	}

	public static class NullableEnumExtensions {
		/// <summary>
		/// Vérifie si le type est un Nullable Enum.
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public static bool IsNullableEnum( this Type t ) {
			Type u = Nullable.GetUnderlyingType(t);
			return (u != null) && u.IsEnum;
		}
		/// <summary>
		/// Renvoie un tableau des associations (valeurs,etiquette) de l'énumeration + null.
		/// </summary>
		/// <param name="enumerationType">Enumeration dont on veut construire une liste compatible.</param>
		/// <returns>tableau des associations (valeurs,etiquette) de l'énumeration + null.</returns>
		public static NullEnumVal[] GetVals( this Enum enumeration ) {
			return GetVals(enumeration.GetType());
		}
		/// <summary>
		/// Construit un tableau des associations (valeurs,etiquette) de l'énumeration + null.
		/// </summary>
		/// <param name="enumerationType">Doit être un type d'énumération</param>
		/// <returns>tableau des associations (valeurs,etiquette) de l'énumeration + null.</returns>
		public static NullEnumVal[] GetVals( Type enumerationType ) {
			string[] enumVals = Enum.GetNames(Nullable.GetUnderlyingType(enumerationType));
			NullEnumVal[] vals = new NullEnumVal[enumVals.Length + 1];
			for(int i = 0; i < enumVals.Length; i++) {
				vals[i] = new NullEnumVal() {
					Val = (Enum)Enum.Parse(Nullable.GetUnderlyingType(enumerationType), enumVals[i]),
					Name = enumVals[i]
				};
			}
			vals[enumVals.Length] = new NullEnumVal() { Name = "Null", Val = null };
			return vals;
		}
	}
}
