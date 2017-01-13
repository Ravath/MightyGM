using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Gestion {
	[Table(Name ="scenariotojoueur")]
	public class ScenarioToJoueur {
		[Column(Name = "fk_joueur", Storage ="JoueurId")]
		public int JoueurId { get; set; }
		[Column(Name = "fk_scenario", Storage = "ScenarioId")]
		public int ScenarioId { get; set; }
	}
}
