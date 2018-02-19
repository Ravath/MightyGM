using CinqAnneaux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.JdrCore.Competences;
using Core.Engine;
using CinqAnneaux.JdrCore.Attributs;
using CinqAnneaux.JdrCore.Attaques;
using CinqAnneaux.JdrCore.Objets;
using CinqAnneaux.JdrCore.Traits;
using CinqAnneaux.JdrCore.Capacites;

namespace CinqAnneaux.JdrCore.Agent {
	public class Agent : Core.Engine.IAgent {

		#region Members
		private List<IAttaque> _attaques = new List<IAttaque>();
		#endregion

		#region Properties : Composants
		public EtatCivilRokugan EtatCivil { get; private set; }
		public Attributs.Attributs Attributs { get; }
		public ListeCompetences Competences { get; }
		public SeuilVie Vie { get; protected set; }
		public IEnumerable<IAttaque> Attaques { get { return _attaques; } }
		#region Objects
		public Inventaire Inventaire { get; }
		public InventaireArmure Armures { get; }
		public InventaireArme Armes { get; }
		#endregion
		#region Traits
		public ListeAvantages Avantages { get; }
		public ListeTraitsCreature TraitsCreature { get; }
		public ListePouvoirsOutremonde PouvoirsOutremonde { get; }
		public ListeTechniques Techniques { get; }
		#endregion
		#region Capacites
		public ListeKatas Katas { get; }
		public ListeKihos Kihos { get; }
		public ListeSorts Sorts { get; }
		#endregion
		#endregion

		#region Properties : Caractéristiques
		public RKPool Initiative { get; }
		public RecuperationRate RecuperationRate { get; }
		private Value pointsSouillure = new Value(0);
		public RankedCarac Souillure { get; }
		public TargetType TargetType {
			get { return TargetType.Agent; }
		}

		public bool IsDead {
			get {
				return Vie.IsDead;
			}
		}
		#endregion

		#region Init
		public Agent() {
			//composants
			EtatCivil = new EtatCivilRokugan();
			Attributs = new Attributs.Attributs(this);
			Competences = new ListeCompetences(Attributs, this);
			//objects
			Inventaire = new Inventaire(this);
			Armes = new InventaireArme(this);
			Armures = new InventaireArmure(this);
			//traits
			Avantages = new ListeAvantages(this);
			TraitsCreature = new ListeTraitsCreature(this);
			PouvoirsOutremonde = new ListePouvoirsOutremonde(this);
			Techniques = new ListeTechniques(this);
			//capacités
			Katas = new ListeKatas(this);
			Kihos = new ListeKihos(this);
			Sorts = new ListeSorts(this);
			// caractéristiques
			Initiative = new RKPool();
			RecuperationRate = new RecuperationRate(Attributs.Constitution);
			Souillure = new RankedCarac(pointsSouillure) { Label = "Souillure" };
		}

		public virtual void SetPersonnage( PersonnageModel perso ) {
			Attributs.SetPersonnage(perso);
			Competences.SetPersonnage(perso);
        }
		#endregion

		#region Armes et attaques
		public void AddAttaque(IAttaque att ) {
			_attaques.Add(att);
		}
		public void RemoveAttaque( IAttaque att ) {
			_attaques.Remove(att);
		}
		public void ClearAttaques() {
			_attaques.Clear();
		}
		#endregion
	}
}
