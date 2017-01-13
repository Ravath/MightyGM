using Core.Data;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Gestion {
	[Table(Name = "joueur")]
	public class Joueur : DataObject {
		[PrimaryKey, Identity, Column(Name = "id"), SequenceName("joueur_id_seq")]
		public new int Id { get; set; }

		[Column(Name = "nom")]
		public string Nom { get; set; }

		[Column(Name = "prenom")]
		public string Prenom { get; set; }

		[Column(Name = "pseudo")]
		public string Pseudo { get; set; }

		public override string ToString() {
			return Nom + " " + Prenom + " [" + Pseudo + "]";
		}
	}
}
