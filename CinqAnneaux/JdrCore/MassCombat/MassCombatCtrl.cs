using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using Core.Data;
using Core.Dice;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.MassCombat
{
	public class MassCombatCtrl
	{
		public readonly static string ArtDelaGuerreTag = "CPT0022";

		#region Members
		public int _currentTurn;
		private List<MassCombatFaction> _factions = new List<MassCombatFaction>();
		private Database _database;
		private IEnumerable<OpportuniteHeroiqueModel> _opportunities;
		#endregion

		#region Properties
		/// <summary>
		/// The number of participants to the battle.
		/// </summary>
		public int ParticipantsSize { get { return _factions.Sum(f => f.Size); } }
		/// <summary>
		/// The duration of the battle in number of battle turns.
		/// </summary>
		public int NumberOfTurns { get { return RpgMath.MinThreshold(ParticipantsSize / 250, 1); } }
		/// <summary>
		/// Flag true if this turn is the last.
		/// </summary>
		public bool IsLastTurn { get { return CurrentTurn == NumberOfTurns; } }
		/// <summary>
		/// The number of turn that have been fought.
		/// </summary>
		public int CurrentTurn
		{
			get { return _currentTurn; }
			set
			{
				_currentTurn = RpgMath.RangeThreshold(value, 0, NumberOfTurns);
			}
		}
		/// <summary>
		/// Every faction fighting in this battle.
		/// </summary>
		public IEnumerable<MassCombatFaction> Factions { get { return _factions; } }
		#endregion

		public MassCombatCtrl(Database db)
		{
			_database = db;
			_opportunities = _database.GetTable<OpportuniteHeroiqueModel>();
		}

		public OpportuniteHeroiqueModel GetRandomOpportunity()
		{
			int nbr = _opportunities.Count();
			int roll = Roll.RollD(nbr);
			return _opportunities.ElementAt(roll - 1);
		}

		public void AddFaction(MassCombatFaction faction)
		{
			_factions.Add(faction);
		}

		public void Clear()
		{
			_factions.Clear();
		}

		public void NextTurn()
		{
			if (!IsLastTurn)
			{
				CurrentTurn++;
				//Roll strategy tests
				RollStrategyTests();

				//Deduce battle turn result
				DeduceBattleResults();

				//Roll for fighters tests
				RollFighterTests();
			}
		}

		/// <summary>
		/// Roll a strategy test for each general.
		/// </summary>
		public void RollStrategyTests()
		{
			foreach (var faction in _factions)
			{
				faction.RollStrategyTest();
			}
		}

		/// <summary>
		/// Roll a Fight test for each fighter.
		/// </summary>
		public void RollFighterTests()
		{
			foreach (var faction in _factions)
			{
				TurnAvantage advantage = faction.TurnResult;
				foreach (var fighter in faction.Fighters)
				{
					fighter.RollCombatTest();
					fighter.GetResult(advantage);
					if (fighter.Result.Opportunity == TurnOpportunity.OPPORTUNITY)
					{
						fighter.Opportunity = GetRandomOpportunity();
					}
				}
			}
		}

		/// <summary>
		/// Deduce the result of the battle for the current turn.
		/// </summary>
		public void DeduceBattleResults()
		{
			int nbrFaction = Factions.Count();
			if (nbrFaction <= 0) { }
			else if (nbrFaction == 1)
			{
				_factions.ElementAt(0).TurnResult = TurnAvantage.WINNING;
			}
			else if (nbrFaction == 2)
			{
				MassCombatFaction f1 = _factions.ElementAt(0);
				MassCombatFaction f2 = _factions.ElementAt(1);
				if (f1.StrategyResult > f2.StrategyResult + 5)
				{
					f1.TurnResult = TurnAvantage.WINNING;
					f2.TurnResult = TurnAvantage.LOSING;
				}
				else if (f2.StrategyResult > f1.StrategyResult + 5)
				{
					f2.TurnResult = TurnAvantage.WINNING;
					f1.TurnResult = TurnAvantage.LOSING;
				}
				else
				{
					f2.TurnResult = TurnAvantage.BALANCED;
					f1.TurnResult = TurnAvantage.BALANCED;
				}
			}
			else
			{
				int max = 0, min = 0;
				double average = 0.0;
				foreach (var faction in _factions)
				{
					int res = faction.StrategyResult;
					if (res > max) { max = res; }
					if (res < min) { min = res; }
					average += res;
					faction.TurnResult = TurnAvantage.BALANCED;
				}
				average /= nbrFaction;
				foreach (var faction in _factions)
				{
					if (faction.StrategyResult > average + 2) { faction.TurnResult = TurnAvantage.WINNING; }
					if (faction.StrategyResult < average - 2) { faction.TurnResult = TurnAvantage.LOSING; }
				}
			}
		}
	}
}
