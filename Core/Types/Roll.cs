using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dice {
	public static class Roll {
		/// <summary>
		/// Lance les dés et en fait la somme.
		/// </summary>
		/// <param name="dice">Pool de dés à lancer.</param>
		/// <returns>La somme du lancer.</returns>
		public static int Sum( Pool dice ) {
			//Contract.Requires<ArgumentNullException>(dice != null);
			dice.Roll();
			int res = 0;
			foreach(int r in dice.Results) {
				res += r;
			}
			return res;
		}
		/// <summary>
		/// Lance les dés et compte le nombre de succès. Il y a succès si un dés effectue une valeur supérieure ou égale au seuil.
		/// </summary>
		/// <param name="dice">Pool de dés à lancer.</param>
		/// <param name="floor">Valeur miminum pour obtenir un succès.</param>
		/// <returns>Le nombre de succès du lancer.</returns>
		public static int Succes( Pool dice, int floor ) {
			//Contract.Requires<ArgumentNullException>(dice != null);
			dice.Roll();
			int res = 0;
			foreach(int r in dice.Results) {
				if(r >= floor)
					res++;
			}
			return res;
		}
		/// <summary>
		/// Lance les dés et fait la somme des meilleurs résultats.
		/// </summary>
		/// <param name="dice">Pool de dés à lancer.</param>
		/// <param name="keep">Nombre de meilleurs dé à conserver dans la somme finale.</param>
		/// <returns>La somme du lancer.</returns>
		public static int RollAndKeep( Pool dice, int keep ) {
			//Contract.Requires<ArgumentNullException>(dice != null);
			dice.Roll();
			dice.SortDecreasing();
			int res = 0;
			for(int i = 0; i < dice.Number && i<keep; i++) {
				res += dice.Results.ElementAt(i);
			}
			return res;
		}
	}
}
