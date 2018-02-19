using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Agent {
	/// <summary>
	/// Seuil a partir duquel un PJ est hors de combat.
	/// </summary>
	public class PJOutThreshold : DerivedValue {
		private Attributs.Anneau _terre;
		internal int FacteurSeuil { get; set; }
        public override int BaseValue {
			get {
				return _terre.TotalValue * (5 + 6 * FacteurSeuil);
			}
		}
		public PJOutThreshold( Attributs.Anneau terre ) : base(terre) {
			_terre = terre;
			FacteurSeuil = 2;
			Label = "Blessures Max";
		}
	}
	/// <summary>
	/// Gestion des seuils de points de vie.
	/// </summary>
	public abstract class SeuilVie {
		#region Members
		private Value _degats = new Value() { Label = "Degats" };
		private IValue _outThreshold = new Value() { Label = "DeathThreshold" };
		private Agent _agent;
		#endregion

		#region Properties
		public int Degats {
			get { return _degats.BaseValue; }
			set { _degats.BaseValue = value; }
		}
		public Value DegatsValue { get { return _degats; } }
		public abstract int Malus { get; }
		/// <summary>
		/// True if the agent if dead(Creature)/Hors de combat(PJ)
		/// </summary>
		public bool HorsCombat {
			get { return Degats > OutThreshold; }
		}
		public abstract bool IsDead { get; }
		/// <summary>
		/// An array with the associations Threshold-Malus.
		/// </summary>
		public abstract IEnumerable<Tuple<int,int>> Seuils { get; }
		/// <summary>
		/// The Death/Hors-Combat Threshold.
		/// </summary>
		public int OutThreshold { get { return _outThreshold.BaseValue; } }
		public IValue DeathThresholdValue {
			get { return _outThreshold; }
			internal set { _outThreshold = value; }
		}
		public Agent Agent { get { return _agent; } }
		#endregion

		#region init
		/// <summary>
		/// The agent whow the Heal Points are monitored.
		/// </summary>
		/// <param name="agent"></param>
		internal SeuilVie( Agent agent ) {
			_agent = agent;
		}
		#endregion
	}

	public class SeuilVieCreature : SeuilVie {

		public int _s5;
		public int _s10;
		public int _s15;
		public Value _sMort = new Value() { Label = "Blessures Max" };

		public override bool IsDead {
			get { return HorsCombat; }
		}

		public override int Malus {
			get {
				if(HorsCombat)
					return -1;
				if(_s15 > 0 && Degats >= _s15) 
					return 15;
				if(_s10 > 0 && Degats >= _s10)
					return 10;
				if(_s5 > 0 && Degats >= _s5)
					return 5;
				return 0;
			}
		}

		public override IEnumerable<Tuple<int, int>> Seuils {
			get {
				if(_s5 > 0)
					yield return new Tuple<int, int>(_s5, 5);
				if(_s10 > 0)
					yield return new Tuple<int, int>(_s10, 10);
				if(_s15 > 0)
					yield return new Tuple<int, int>(_s15, 15);
			}
		}

		/// <summary>
		/// Compteur de blessures utilisé par les créatures qui n'utilisent pas le même compteur que les PJs.
		/// </summary>
		/// <param name="agent"></param>
		/// <param name="creature"></param>
		public SeuilVieCreature( Agent agent, CreatureModel creature ) : base(agent) {
			_sMort.BaseValue = creature.VieMax;
			DeathThresholdValue = _sMort;
			_s15 = creature.Bless15;
			_s10 = creature.Bless10;
			_s5 = creature.Bless5;
		}
	}

	public class SeuilViePJ : SeuilVie {
		#region Members
		private int _facteur;
		private static int[] malus = { 0, 3, 5, 10, 15, 20, 40 };
		private PJOutThreshold _threshold;
		#endregion

		#region Properties
		/// <summary>
		/// Valeur comprise entre 2 et 5 et définissant la taille des seuils de malus de blessure.
		/// </summary>
		public int FacteurSeuil {
			get { return _facteur; }
			set {
				_facteur = value;
				_threshold.FacteurSeuil = value;
            }
		}

		public override int Malus {
			get {
				if(HorsCombat)
					return -1;
				int T = Agent.Attributs.Terre.TotalValue;
				if(Degats <= 5 * T)
					return 0;
				return malus[ ( (Degats - 5 * T -1) / (FacteurSeuil * T) ) + 1];
			}
		}

		public override bool IsDead {
			get { return Degats >= (OutThreshold + FacteurSeuil*Agent.Attributs.Terre.TotalValue); }
		}

		public override IEnumerable<Tuple<int, int>> Seuils {
			get {
				int T = Agent.Attributs.Terre.TotalValue;
				for(int i=0; i < malus.Length; i++) {
					yield return new Tuple<int, int>(5 * T + (i * FacteurSeuil * T), malus[i]);
				}
			}
		}
		#endregion

		public SeuilViePJ( Agent agent ) : base(agent) {
			_threshold = new PJOutThreshold(agent.Attributs.Terre);
			DeathThresholdValue = _threshold;
			FacteurSeuil = 2;
		}

	}
}
