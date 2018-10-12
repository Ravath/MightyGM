using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.Data;

namespace CinqAnneaux.JdrCore.Traits {
	public class PouvoirNaturel : GeneralTrait {
		public string Complement { get; set; }

		public void SetExemplaire( PouvoirNaturelExemplar item ) {
			PouvoirNaturelModel model = item.Model;
			Name = model.Name;
			Description = model.Description.Description;
			Complement = item.Complement;
			Delegate = PouvoirNaturelImplementation.GetImplementation(model.Tag);
        }
	}
}
