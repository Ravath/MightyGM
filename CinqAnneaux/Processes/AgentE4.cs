using Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.Processes
{
	/// <summary>
	/// Spend XP within limits if PJ.
	///		Specific from usal XP spending : 
	///			- 40 at start (can change with parameters).
	///			- Can buy Avantages or desavantages, or Ancesters if allowed.
	///			- Specific limits on objects.
	///	Else, wathever if MJ/Monster
	///		-	Powers and capacities if monster.
	/// </summary>
	public class AgentE4 : IProcessStep
	{
		public bool CanProgress(out string ErrorMessageTag)
		{
			throw new NotImplementedException();
		}

		public void Init(IProcess process)
		{
			throw new NotImplementedException();
			////init attributes
			//foreach (var item in _params.Personnage.Attributs.AllAttributs)
			//{
			//	item.BaseValue = 2;
			//}
			//_params.Personnage.Attributs.MaxVide.BaseValue = 2;
			////set data
			//fiche.SetData(_params.Data);
		}

		public void PreprossNext()
		{
			throw new NotImplementedException();
		}

		public void PreprossReset()
		{
			throw new NotImplementedException();
		}

		public void Reset()
		{
			throw new NotImplementedException();
		}
	}
}
