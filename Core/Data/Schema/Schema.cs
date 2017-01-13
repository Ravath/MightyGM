using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Schema {
	public class Schema {
		public string Nom { get; set; }

		public Schema(string nom) {
			Nom = nom;
		}
	}
}
