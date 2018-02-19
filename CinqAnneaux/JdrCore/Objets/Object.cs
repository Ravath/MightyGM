using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Objets {
	public class Object : IObject {
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public ValeurMonetaire Valeur { get; protected set; }

		public void SetObject( AbsObjetModel model ) {
			Name = model.Name;
			Description = model.Description.Description;
			Valeur.Value = model.Cout;
			Valeur.Unity = model.Monnaie;
		}
	}
}
