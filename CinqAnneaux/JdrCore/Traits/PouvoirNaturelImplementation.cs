using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Traits {
	public static class PouvoirNaturelImplementation {
		public static IAvantageImplementation GetImplementation( string tag ) {
			switch(tag) {
				default:
				return null;
			}
		}
	}
}
