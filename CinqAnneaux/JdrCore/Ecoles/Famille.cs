using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Ecoles {
	public class Famille : INamed {
		public string Tag { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public TraitCompetence BonusTrait { get; private set; }

		public void SetModel( FamilleModel model ) {
			Tag = model.Tag;
			Name = model.Name;
			Description = model.Description.Description;
			BonusTrait = model.BonusInitial;
		}
	}
}
