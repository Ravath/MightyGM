using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Gestion {
	[Table(Name ="sceance")]
	public class Sceance {

		public Sceance() {
			DateDebut = DateTime.Now;
		}

		[PrimaryKey, Identity, Column(Name = "id"), SequenceName("sceance_id_seq")]
		public int Id { get; set; }

		[Column(Name = "name")]
		public string Nom { get; set; }

		[Column(Name = "debut")]
		public DateTime DateDebut { get; set; }
		[Column(Name = "fin"), Nullable]
		public DateTime? DateFin { get; set; }

		private string _resume = "";
		[LargeText]
		[Column(Name = "resume")]
		public string Resume {
			get { return _resume; }
			set { _resume = value; }
		}

		private string _gmnotes = "";
		[LargeText]
		[Column(Name = "notes")]
		public string GMNotes {
			get { return _gmnotes; }
			set { _gmnotes = value; }
		}
		public override string ToString() {
			return Nom;
		}

		public void CloseSceance() {
			DateFin = DateTime.Now;
		}

		[Column(Name = "fk_scenario")]
		[HiddenProperty]
		public int ScenarioId { get; set; }

		private Scenario _scenario;
		public Scenario Scenario {
			get {
				if(_scenario == null) {
					var q = from s in Database.GlobalDataBase.GetTable<Scenario>()
							where s.Id == ScenarioId
							select s;
					_scenario = q.SingleOrDefault();
				}
				return _scenario;
			}
			set {
				_scenario = value;
				if(value == null)
					ScenarioId = 0;
				else
					ScenarioId = value.Id;
			}
		}
	}
}
