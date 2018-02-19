using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.Data;

namespace CinqAnneaux.JdrCore.Traits {
	public class PouvoirOutremonde : GeneralTrait {

		public TypePouvoirOutremonde Type { get; private set; }

		public void SetPouvoirModel( PouvoirOutremondeModel model ) {
			Name = model.Name;
			Type = model.TypePouvoir;
			Description = model.Description.Description;
			Delegate = PouvoirOutremondeImplementation.GetImplementation(model.Tag);
        }
	}
}
