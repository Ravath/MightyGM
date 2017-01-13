using Core.Data;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Gestion {
	/// <summary>
	/// Une gamme de Jeu de rôle.
	/// </summary>
	[Table(Name ="jdr")]
	public class Jdr {
		[PrimaryKey, Identity, Column(Name = "id"), SequenceName("jdr_id_seq")]
		public int Id { get; set; }

		[Column(Name ="nom")]
		public string Nom { get; set; }

		public IEnumerable<Manuel> GetManuels() {
			var q = from c in Database.GlobalDataBase.GetTable<Manuel>()
					where c.JdrId == Id
					select c;
			return q;
		}

		public override string ToString() {
			return Nom;
		}
	}
}
