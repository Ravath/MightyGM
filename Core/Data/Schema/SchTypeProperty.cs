using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Schema {
	public class SchTypeProperty {
		public PropertyInfo PropertyInfo { get; set; }
		public SchTypeProperty( PropertyInfo pi ) {
			PropertyInfo = pi;
        }
	}
}
