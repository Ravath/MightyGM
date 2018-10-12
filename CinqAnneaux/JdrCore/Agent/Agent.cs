using CinqAnneaux.Data;
using System;
using System.Collections.Generic;
using Core.Engine;
using CinqAnneaux.JdrCore.Competences;
using CinqAnneaux.JdrCore.Attributs;
using CinqAnneaux.JdrCore.Attaques;
using CinqAnneaux.JdrCore.Objets;
using CinqAnneaux.JdrCore.Traits;
using CinqAnneaux.JdrCore.Capacites;

namespace CinqAnneaux.JdrCore.Agent {
	public abstract class Agent : Core.Engine.IAgent
	{

		#region Members
		public delegate void ModelChanged(Agent agent);
		public event ModelChanged OnModelChanged;
		#endregion

		#region Properties : Composants
		public EtatCivilRokugan EtatCivil { get; private set; }
		public Attributs.Attributs Attributs { get; }
		public ListeCompetences Competences { get; }
		public SeuilVie Vie { get; protected set; }
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
		public RollAndKeep Initiative { get; protected set; }
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
			RecuperationRate = new RecuperationRate(Attributs.Constitution);
			Souillure = new RankedCarac(pointsSouillure) { Label = "Souillure" };
		}

		private void SetPersonnage(PersonnageModel perso)
		{
			Attributs.SetPersonnage(perso);
			Competences.SetPersonnage(perso);
			EtatCivil.SetPersonnage(perso);
			OnModelChanged?.Invoke(this);
		}

		public virtual void SetPersonnage(FigurantModel perso) { SetPersonnage((PersonnageModel)perso); }
		public virtual void SetPersonnage(PersonnageJoueurModel perso) { SetPersonnage((PersonnageModel)perso); }
		#endregion

	}
}
