using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.MassCombat
{
	public enum TurnOpportunity { NOTHING, DUEL, OPPORTUNITY }
	public enum TurnAvantage { WINNING=0, BALANCED = 1, LOSING = 2 }
	public enum FighterImplication { SOUTIEN=0, DESENGAGE=1, ENGAGE=2, PREMIERE_LIGNE=3 }
}
