using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Capacites {
	internal static class SortImplementer {
		internal static IImplementedCapacity GetImplementation( string tag ) {
			switch(tag) {
				default:
				return null;
			}
		}
	}
}
