using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.JdrCore.Competences;
using Core.Data;
using Core.Dice;

namespace CinqAnneaux.JdrCore.MassCombat
{
	public class MassCombatFighter
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="character"></param>
		public MassCombatFighter(Personnage character) {
			Fighter = character;
			Water = Fighter.Attributs.Eau.TotalValue;
			Competence artGuerre = Fighter.Competences.GetCompetenceByTag(MassCombatCtrl.ArtDelaGuerreTag);
			ArtGuerreRank = (artGuerre?.Rang ?? 0);
		}


		#region Properties
		public FighterImplication Implication { get; set; }
		public Personnage Fighter { get; }
		public int CombatTest { get; set; }
		public TurnResult Result { get; set; }
		public OpportuniteHeroiqueModel Opportunity { get; set; } 
		public int Water { get; set; }
		public int ArtGuerreRank { get; set; }
		#endregion

		public void RollCombatTest()
		{
			CombatTest = Roll.RollD(1, 10)
				+ ArtGuerreRank
				+ Water;
		}

		public void GetResult(TurnAvantage avantage)
		{
			Result = TurnResult.GetResult(CombatTest, Implication, avantage);
			Opportunity = null;
		}
	}
}