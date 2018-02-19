using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Schema {
	public class SchType {
		public Type Type { get; set; }
		public SchType(Type t) {
			Type = t;
		}
	}
}
