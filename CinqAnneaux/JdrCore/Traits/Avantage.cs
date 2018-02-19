using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Traits {
	public class Avantage : GeneralTrait {

		public int RankMax { get; private set; }
		public int Cout { get; private set; }
		public bool Desavantage { get; private set; }

		public void SetPouvoirModel( AbsAvantageModel model ) {
			Name = model.Name;
			if(model.Groupe != null) {
				Description = model.Groupe.Description.Description +"\n"+ model.Description.Description;
			} else
				Description = model.Description.Description;
			RankMax = model.RangMax;
			Delegate = AvantageImplementation.GetImplementation(model.Tag);
			Desavantage = model is DesavantageModel;
			Cout = model.Cout;
        }
	}
}
