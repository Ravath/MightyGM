using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Traits {

	public interface IAvantageImplementation {
		void Affect( Agent.Agent a );
		void Unaffect( Agent.Agent a );
	}

	public static class AvantageImplementation {
		public static IAvantageImplementation GetImplementation( string tag ) {
			switch(tag) {
				default:
				return null;
			}
		}
	}
}
