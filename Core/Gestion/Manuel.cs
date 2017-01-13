using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Gestion {
	/// <summary>
	/// Un manuel de Jeu de Rôle.
	/// </summary>
	[Table(Name = "manuel")]
	public class Manuel {
		[PrimaryKey, Identity, Column(Name = "id"), SequenceName("livre_id_seq")]
		public int Id { get; set; }

		[Column(Name = "nom")]
		public string Nom { get; set; }

		[Column(Name ="fk_jdr")]
		[HiddenProperty]
		public int JdrId { get; set; }

		public override string ToString() {
			return Nom;
		}
	}
}
