using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore {
	public class GainHonneur {
		public string Acte { get; set; }
		public int Gain0 { get; set; }
		public int Gain1 { get; set; }
		public int Gain2 { get; set; }
		public int Gain3 { get; set; }
		public int Gain4 { get; set; }
		public int Gain5 { get; set; }
		public GainHonneur( int g0, int g1, int g2, int g3, int g4, int g5 ) {
			Gain0 = g0;
			Gain1 = g1;
			Gain2 = g2;
			Gain3 = g3;
			Gain4 = g4;
			Gain5 = g5;
		}
		private static List<GainHonneur> _table = new List<GainHonneur>();
		public static IEnumerable<GainHonneur> Tableau {
			get {
				return _table;
			}
		}
		static GainHonneur() {
			_table.Add(new GainHonneur(0, 0, -3, -4, -7, -8) { Acte = "Accepter un pot de vin" });
			_table.Add(new GainHonneur(8, 7, 6, 4, 3, 3) { Acte = "Accepter d'endosser la responsabilité d'un acte déshonorant commis par un supérieur" });
			_table.Add(new GainHonneur(5, 4, 4, 2, 2, 0) { Acte = "Reconnaitre la supériorité d'un adversaire" });
			_table.Add(new GainHonneur(9, 8, 6, 6, 5, 3) { Acte = "Venir en aide à un ennemi blessé" });
			_table.Add(new GainHonneur(-1, -4, -8, -12, -16, -20) { Acte = "Se rendre complice d'un crime odieux" });
			_table.Add(new GainHonneur(0, -1, -4, -4, -8, -8) { Acte = "Se rendre complice d'un crime mineur" });
			_table.Add(new GainHonneur(-1, -6, -10, -10, -16, -20) { Acte = "Manquement à l'Etiquette, blasphématoire" });
			_table.Add(new GainHonneur(0, -2, -2, -2, -6, -6) { Acte = "Manquement à l'Etiquette, majeur" });
			_table.Add(new GainHonneur(0, 0, -1, -2, -2, -2) { Acte = "Manquement à l'Etiquette, mineur" });
			_table.Add(new GainHonneur(0, -2, -6, -10, -14, -18) { Acte = "Se montrer déloyal envers son seigneur, son épouse, son supérieur" });
			_table.Add(new GainHonneur(-1, -4, -8, -12, -16, -18) { Acte = "Trompé à commettre un acte criminel" });
			_table.Add(new GainHonneur(0, -2, -4, -6, -10, -14) { Acte = "Trompé à commettre un acte déloyal" });
			_table.Add(new GainHonneur(0, -2, -4, -4, -6, -8) { Acte = "Trompé à commettre un acte stupide" });
			_table.Add(new GainHonneur(0, -2, -2, -6, -6, -10) { Acte = "Désobéir à un ordre de son seigneur" });
			_table.Add(new GainHonneur(0, -2, -4, -4, -6, -8) { Acte = "Ne pas réagir à une insulte envers un ancêtre" });
			_table.Add(new GainHonneur(2, 2, 2, 0, 0, 0) { Acte = "Ne pas réagir à une insulte envers soi-même" });
			_table.Add(new GainHonneur(0, 0, -2, -2, -4, -4) { Acte = "Ne pas réagir à une insulte envers sa famille ou son Clan" });
			_table.Add(new GainHonneur(8, 6, 5, 4, 3, 2) { Acte = "Affronter, au nom de sa famille, un adversaire supérieur" });
			_table.Add(new GainHonneur(0, -2, -4, -6, -8, -10) { Acte = "Fuir une bataille" });
			_table.Add(new GainHonneur(6, 4, 0, 0, -2, -4) { Acte = "Obéir à un ordre en dépit de réticences personnelles" });
			_table.Add(new GainHonneur(10, 8, 6, 4, 2, 0) { Acte = "Respecter une promesse en dépit de ce que cela peut coûter" });
			_table.Add(new GainHonneur(8, 6, 4, 2, 0, 0) { Acte = "Rapporter la vérité sur un fait en dépit de ce que cela peut vous coûter" });
			_table.Add(new GainHonneur(0, -2, -4, -6, -8, -10) { Acte = "Mentir pour améliorer sa réputation" });
			_table.Add(new GainHonneur(0, -2, -4, -6, -8, -10) { Acte = "Mentir à un individu pour le pousser à commettre un acte déshonorable" });
			_table.Add(new GainHonneur(3, 2, 0, 0, -2, -2) { Acte = "Ignorer poliment le comportement déshonorant d'un individu" });
			_table.Add(new GainHonneur(8, 8, 6, 6, 4, 2) { Acte = "Protéger les intérêts de son Clan/seigneur/famille face à de grands risques" });
			_table.Add(new GainHonneur(6, 6, 4, 4, 2, 2) { Acte = "Se montrer aimable avec un individu de moindre statut" });
			_table.Add(new GainHonneur(9, 7, 5, 2, 0, 0) { Acte = "Se montrer sincèrement courtois avec un ennemi ou un rival" });
			_table.Add(new GainHonneur(0, -1, -2, -3, -6, -9) { Acte = "Utiliser une Compétence Dégradante" });
			_table.Add(new GainHonneur(0, 0, -2, -6, -10, -10) { Acte = "Se montrer faussement courtois pour prendre l'avantage sur un ennemi" });
		}
	}

}
