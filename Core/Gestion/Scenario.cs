using Core.Data;
using Core.Data.Schema;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Gestion {
	[Table(Name = "scenario")]
	public class Scenario {
		[PrimaryKey, Identity, Column(Name = "id"), SequenceName("scenario_id_seq")]
		public int Id { get; set; }

		[Column(Name = "name")]
		public string Nom { get; set; }

		[Column(Name = "synopsis")]
		[LargeText]
		public string Synopsis { get; set; }

		[Column(Name ="fk_joueur_gm")]
		[HiddenProperty]
        public int GmId { get; set; }
		private Joueur _gm;
		public Joueur Gm {
			get {
				if(_gm == null) {
					var q = from s in Database.GlobalDataBase.GetTable<Joueur>()
							where s.Id == GmId
							select s;
					_gm = q.SingleOrDefault();
				}
				return _gm;
			}
			set {
				_gm = value;
				if(value == null)
					GmId = 0;
				else
					GmId = value.Id;
			}
		}

		public IEnumerable<Joueur> GetJoueurs() {
			var q = from c in Database.GlobalDataBase.GetTable<ScenarioToJoueur>()
					where c.ScenarioId == Id
					join j in Database.GlobalDataBase.GetTable<Joueur>() on c.JoueurId equals j.Id
					select j;
			return q;
        }

		public void AddJoueur( Joueur joueur ) {
			ScenarioToJoueur sj = new ScenarioToJoueur();
			sj.JoueurId = joueur.Id;
			sj.ScenarioId = Id;
			Database.GlobalDataBase.Insert<ScenarioToJoueur>(sj);
        }

		public void RemoveJoueur( Joueur joueur ) {
			var q = from c in Database.GlobalDataBase.GetTable<ScenarioToJoueur>()
					where c.ScenarioId == Id && joueur.Id == c.JoueurId
					select c;
			foreach(ScenarioToJoueur sj in q.ToList()) {
				Database.GlobalDataBase.Delete<ScenarioToJoueur>(sj);
			}
        }

		public override string ToString() {
			return Nom;
		}

		public IEnumerable<Sceance> GetSceances() {
			return from s in Database.GlobalDataBase.GetTable<Sceance>()
				   where s.ScenarioId == Id
				   select s;
		}

		[Column(Name = "fk_jdr")]
		[HiddenProperty]
		public int JdrId { get; set; }
		private Jdr _jdr;
		public Jdr Jdr {
			get {
				if(_jdr == null) {
					var q = from s in Database.GlobalDataBase.GetTable<Jdr>()
							where s.Id == JdrId
							select s;
					_jdr = q.SingleOrDefault();
				}
				return _jdr;
			}
			set {
				_jdr = value;
				if(value == null)
					JdrId = 0;
				else
					JdrId = value.Id;
			}
		}

		public void Delete() {
			foreach(Sceance sc in GetSceances().ToList())
				Database.GlobalDataBase.Delete<Sceance>(sc);
			var q = from s in Database.GlobalDataBase.GetTable<ScenarioToJoueur>()
					where s.ScenarioId == Id
					select s;
			foreach(ScenarioToJoueur sj in q.ToList()) {
				Database.GlobalDataBase.Delete<ScenarioToJoueur>(sj);
			}
			Database.GlobalDataBase.Delete<Scenario>(this);
		}
	}
}
