using Core.Engine;

namespace CinqAnneaux.JdrCore.MassCombat
{
	public class TurnResult
	{
		public int Wounds { get; }
		public int Glory { get; }
		public TurnOpportunity Opportunity { get; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="wounds"></param>
		/// <param name="glory"></param>
		/// <param name="opportunity"></param>
		private TurnResult(int wounds, int glory, TurnOpportunity opportunity)
		{
			Wounds = wounds;
			Glory = glory;
			Opportunity = opportunity;
		}

		/// <summary>
		/// Get the result from the battrel result table for the given combat test.
		/// </summary>
		/// <param name="testResult"></param>
		/// <param name="implication"></param>
		/// <param name="armyResult"></param>
		/// <returns></returns>
		public static TurnResult GetResult(int testResult, FighterImplication implication, TurnAvantage armyResult)
		{
			int row = RpgMath.RangeThreshold((testResult-1)/3, 0, 10);
			int col = (int)implication + (int)armyResult;
			return ResultsTab[row][col];
		}

		//TODO implement a 2DDataTable for this?
		private static readonly TurnResult[][] ResultsTab = new TurnResult[10][]
		{
			new TurnResult[6]{new TurnResult(1,0,TurnOpportunity.NOTHING),new TurnResult(2,0,TurnOpportunity.NOTHING	),new TurnResult(3,1,TurnOpportunity.NOTHING		),new TurnResult(4,1,TurnOpportunity.NOTHING		),new TurnResult(5,1,TurnOpportunity.DUEL			),new TurnResult(6,3,TurnOpportunity.OPPORTUNITY	)},
			new TurnResult[6]{new TurnResult(1,0,TurnOpportunity.NOTHING),new TurnResult(1,0,TurnOpportunity.NOTHING	),new TurnResult(3,1,TurnOpportunity.NOTHING		),new TurnResult(4,1,TurnOpportunity.NOTHING		),new TurnResult(5,1,TurnOpportunity.DUEL			),new TurnResult(5,2,TurnOpportunity.OPPORTUNITY	)},
			new TurnResult[6]{new TurnResult(1,0,TurnOpportunity.NOTHING),new TurnResult(0,0,TurnOpportunity.NOTHING	),new TurnResult(2,1,TurnOpportunity.NOTHING		),new TurnResult(3,1,TurnOpportunity.DUEL			),new TurnResult(4,1,TurnOpportunity.OPPORTUNITY	),new TurnResult(5,1,TurnOpportunity.DUEL			)},
			new TurnResult[6]{new TurnResult(0,0,TurnOpportunity.NOTHING),new TurnResult(0,0,TurnOpportunity.NOTHING	),new TurnResult(2,0,TurnOpportunity.DUEL			),new TurnResult(3,0,TurnOpportunity.OPPORTUNITY	),new TurnResult(4,1,TurnOpportunity.OPPORTUNITY	),new TurnResult(4,1,TurnOpportunity.DUEL			)},
			new TurnResult[6]{new TurnResult(0,1,TurnOpportunity.NOTHING),new TurnResult(0,1,TurnOpportunity.NOTHING	),new TurnResult(1,1,TurnOpportunity.NOTHING		),new TurnResult(2,1,TurnOpportunity.DUEL			),new TurnResult(3,1,TurnOpportunity.NOTHING		),new TurnResult(4,1,TurnOpportunity.OPPORTUNITY	)},
			new TurnResult[6]{new TurnResult(0,1,TurnOpportunity.NOTHING),new TurnResult(0,1,TurnOpportunity.DUEL		),new TurnResult(1,1,TurnOpportunity.NOTHING		),new TurnResult(2,1,TurnOpportunity.DUEL			),new TurnResult(3,2,TurnOpportunity.NOTHING		),new TurnResult(3,2,TurnOpportunity.OPPORTUNITY	)},
			new TurnResult[6]{new TurnResult(0,2,TurnOpportunity.NOTHING),new TurnResult(0,2,TurnOpportunity.NOTHING	),new TurnResult(1,2,TurnOpportunity.OPPORTUNITY	),new TurnResult(1,2,TurnOpportunity.NOTHING		),new TurnResult(3,2,TurnOpportunity.OPPORTUNITY	),new TurnResult(3,2,TurnOpportunity.DUEL			)},
			new TurnResult[6]{new TurnResult(0,2,TurnOpportunity.NOTHING),new TurnResult(0,2,TurnOpportunity.OPPORTUNITY),new TurnResult(0,2,TurnOpportunity.NOTHING		),new TurnResult(1,2,TurnOpportunity.OPPORTUNITY  ),new TurnResult(2,3,TurnOpportunity.NOTHING		),new TurnResult(3,3,TurnOpportunity.DUEL			)},
			new TurnResult[6]{new TurnResult(0,2,TurnOpportunity.NOTHING),new TurnResult(0,2,TurnOpportunity.NOTHING	),new TurnResult(0,3,TurnOpportunity.DUEL			),new TurnResult(1,3,TurnOpportunity.NOTHING		),new TurnResult(2,4,TurnOpportunity.OPPORTUNITY	),new TurnResult(3,4,TurnOpportunity.OPPORTUNITY	)},
			new TurnResult[6]{new TurnResult(0,3,TurnOpportunity.NOTHING),new TurnResult(0,3,TurnOpportunity.NOTHING	),new TurnResult(0,4,TurnOpportunity.OPPORTUNITY	),new TurnResult(1,4,TurnOpportunity.DUEL			),new TurnResult(2,5,TurnOpportunity.DUEL			),new TurnResult(3,5,TurnOpportunity.OPPORTUNITY	)}
		};
	}
}