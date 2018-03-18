using Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.Processes
{
	public class AgentParameters : IProcessParameters
	{
		/* Clan restrictions */
		public bool MajorClanAllowed;
		public bool MinorClanAllowed;
		public bool ImperialClanAllowed;
		public bool SpiderClanAllowed;
		public bool MonkAllowed;
		public bool RoninAllowed;

		/* School Restrictions */
		public bool BushiAllowed;
		public bool CourtierAllowed;
		public bool ShugenjaAllowed;
		//Ninja : Bushi
		//Craftman : Courtier
		//If monk allowed, monks school are always allowed
		//Ronins are always bushi? / They seem to have SchoolKeywords too

		/* XP restrictions */
		public int StartXP = 40;
		public int MaxDesavantagePoints = 10;
		public int MaxAvantagePoints = 15;
		public bool AncestorsAllowed = false;

		//TODO Nezumi and other PJable monsters
	}
}
