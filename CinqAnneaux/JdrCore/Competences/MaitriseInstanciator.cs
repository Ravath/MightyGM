using CinqAnneaux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Competences {
	public static class MaitriseInstanciator {

		public static Maitrise Instanciate(MaitriseModel model ) {
			switch(model.Tag) {
				default:
				return new DefaultMaitrise(model);
			}
		}

	}
}
