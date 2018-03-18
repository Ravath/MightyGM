using Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.Processes
{
	/// <summary>
	/// Selection of spells if shugenja, ot Kihos if monk.
	/// else, nothing.
	/// </summary>
	public class AgentE3 : IProcessStep
	{
		public bool CanProgress(out string ErrorMessageTag)
		{
			throw new NotImplementedException();
		}

		public void Init(IProcess process, IProcessParameters parameters)
		{
			throw new NotImplementedException();
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
