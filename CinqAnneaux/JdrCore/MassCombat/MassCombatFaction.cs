using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using System.Collections.Generic;

namespace CinqAnneaux.JdrCore.MassCombat
{
	public class MassCombatFaction
	{
		/// <summary>
		/// The name of the faction.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Number of men in this faction.
		/// </summary>
		public int Size { get; set; }
		/// <summary>
		/// The strategy leader of the faction.
		/// </summary>
		public Personnage General { get; set; }
		public int ArtDelaGuerreRank {
			get{ return General.Competences.GetCompetenceByTag(MassCombatCtrl.ArtDelaGuerreTag).Rang; }
			set { General.Competences.GetCompetenceByTag(MassCombatCtrl.ArtDelaGuerreTag).Rang = value; }
		}
		/// <summary>
		/// The characters fighting for this faction.
		/// </summary>
		public IEnumerable<MassCombatFighter> Fighters { get { return _fighters; } }
		/// <summary>
		/// The result of the general last strategy test.
		/// </summary>
		public int StrategyResult { get; set; }
		/// <summary>
		/// A bonus the faction has on her strategy tests.
		/// </summary>
		public int StrategyAdvantage { get; set; }
		/// <summary>
		/// Indicates the faction avantage as a result of the strategy test this turn.
		/// </summary>
		public TurnAvantage TurnResult { get; set; }

		private List<MassCombatFighter> _fighters = new List<MassCombatFighter>();

		public MassCombatFighter AddFighter(Personnage fighter)
		{
			MassCombatFighter nmf = new MassCombatFighter(fighter);
			_fighters.Add(nmf);
			return nmf;
		}

		public void RollStrategyTest()
		{
			//test d'art de la guerre(combat de masse)
			RollAndKeep test = General.Competences.GetPool(TraitCompetence.Perception, MassCombatCtrl.ArtDelaGuerreTag, "SPC0068");
			test.Roll();
			StrategyResult = test.NetResult + StrategyAdvantage;
		}
	}
}