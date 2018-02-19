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
		public RKPool Degats { get; private set; }
		public TypeArme Type { get; private set; }
		public string Name { get; private set; }
		public TailleArme Taille { get; private set; }
		public bool Brisee { get; set; }

		public bool ArmePaysan { get; private set; }
		public bool ArmeSamurai { get; private set; }

		#region Arcs
		public decimal Portee { get; private set; }
		public int Force { get; private set; }
		public int ForceRequise { get; private set; }
		public bool ArmeADistance { get { return Portee > 0; } }
		#endregion

		public Arme( ArmeModel model ) {
			Name = model.Name;
			Degats = new RKPool();
			Degats.Number = model.RollVD;
			Degats.Keep = model.KeepVD;
			Type = model.Type;
			Taille = model.Taille;
			ArmeSamurai = model.Samurai;
			ArmePaysan = model.Paysan;
			Brisee = false;
			/* arcs */
			Portee = model.Portee ?? -1;
			Force = model.Force ?? -1;
			ForceRequise = model.ForceRequise;
			/* add weapon category special features */
			switch(model.Type) {
				// Todo add weapon category special features
				case TypeArme.Fleche:
				break;
				case TypeArme.Arc:
				break;
				case TypeArme.Chaine:
				break;
				case TypeArme.Hast:
				break;
				case TypeArme.Ninjutsu:
				break;
				case TypeArme.Lourde:
				break;
				case TypeArme.Baton:
				break;
				case TypeArme.Couteau:
				Portee = 6;
				break;
				case TypeArme.Eventail:
				break;
				case TypeArme.Lance:
				break;
				case TypeArme.Sabre:
				break;
				default:
				break;
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
