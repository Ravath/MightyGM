using CinqAnneaux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Competences {
	/// <summary>
	/// Une specialisation de compétence.
	/// </summary>
	public class Specialisation {
		/// <summary>
		/// Le nom de la spécailisation.
		/// </summary>
		public string Nom { get; set; }
		public bool Degradante { get; set; }
		public bool Noble { get; set; }
		public TraitCompetence? Trait { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		public void SetSpecialisation( Data.Specialisation model ) {
			Nom = model.Nom;
			Degradante = model.Degradante;
			Noble = false;
			Trait = null;
        }
		public void SetSousType( Data.SousTypeGlobal model ) {
			Nom = model.Nom;
			Degradante = model.Degradante;
			Noble = model.Noble;
			Trait = model.TraitAssocie;
		}
	}
}
