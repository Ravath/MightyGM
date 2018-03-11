using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Attributs;
using CinqAnneaux.JdrCore.Traits;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Ecoles {
	public class Ecole : INamed {
		public string Tag { get; private set; }
		public string Name { get; private set; }
		public BaliseEcole MotClef { get; private set; }
		public Affinite? Affinite { get; private set; }
		public Affinite? Deficience { get; private set; }
		public Devotion? Devotion { get; private set; }
		public string Description { get; private set; }
		public TraitCompetence BonusTrait { get; private set; }
		public List<Technique> Techniques { get; }
		private Value pointsHonneur = new Value();
		public RankedCarac HonneurInitial { get; }
		public Value Rank { get; set; }
		public int RokuInitial { get; private set; }
		public int BuInitial { get; private set; }
		public int ZeniInitial { get; private set; }

		public Ecole() {
			Techniques = new List<Technique>();
			HonneurInitial = new RankedCarac(pointsHonneur) { Label = "Honneur Initial" };
			Rank = new Value(1);
        }

		public void SetModel( EcoleModel model ) {
			Tag = model.Tag;
			Name = model.Name;
			Description = model.Description.Description;
			BonusTrait = model.BonusInitial;
			Techniques.Clear();
			pointsHonneur.BaseValue = (int)model.Honneur * 10;
			RokuInitial = (int)model.ArgentInitial;
			BuInitial = ((int)model.ArgentInitial * 10) % 10;
			ZeniInitial = ((int)model.ArgentInitial * 100) % 10;
			MotClef = model.Balise;
			Affinite = model.Affinite;
			Deficience = model.Deficience;
			Devotion = model.Devotion;
			foreach(var tech in model.Techniques.OrderBy(t=>t.Rang)) {
				Technique t = new Technique();
				t.SetModel(tech);
				Techniques.Add(t);
            }
        }
	}
}
