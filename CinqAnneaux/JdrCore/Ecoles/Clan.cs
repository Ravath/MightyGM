using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Ecoles {
	public class Clan : INamed {
		public string Tag { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }

		public void SetModel( ClanModel model ) {
			Tag = model.Tag;
			Name = model.Name;
			Description = model.Description.Description;
		}
	}
}
