using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.JdrCore;
using CinqAnneaux.Data;

namespace CinqAnneaux.JdrCore.Objets {

	public class Arme : IWearable {
		public RollAndKeep Degats { get; private set; }
		public TypeArme Type { get; private set; }
		public string Name { get; private set; }
		public TailleArme Taille { get; private set; }
		public bool Brisee { get; set; }

		public bool ArmePaysan { get; private set; }
		public bool ArmeSamurai { get; private set; }

		private List<ObjectSpecial> _specs = new List<ObjectSpecial>();
		public IEnumerable<ObjectSpecial> Specials
		{
			get { return _specs; }
		}

		#region Special Distance
		public decimal Portee { get; private set; }
		public int Force { get; private set; }
		public int ForceRequise { get; private set; }
		public bool ArmeADistance { get { return Portee > 0; } }
		#endregion

		public Arme( ArmeModel model ) {
			Name = model.Name;
			Degats = new RollAndKeep(model.RollVD, model.KeepVD);
			Type = model.Type;
			Taille = model.Taille;
			ArmeSamurai = model.Samurai;
			ArmePaysan = model.Paysan;
			Brisee = false;
			//get specials
			foreach (SpecialObjetExemplar sp in model.Special)
			{
				_specs.Add(SpecialImplementation.Instanciate(sp));
			}
		}

		public void Equiper( IAgent personnage ) {
			throw new NotImplementedException();
		}

		public void Desequiper( IAgent personnage ) {
			throw new NotImplementedException();
		}
	}
}
