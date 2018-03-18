using CinqAnneaux.JdrCore.Agent;
using Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.Processes
{
	public class AgentProcess : IProcess
	{
		private List<IProcessStep> _processes = new List<IProcessStep>();

		public Agent Agent { get; private set; }

		public int NbrSteps { get { return _processes.Count; } }

		public AgentProcess()
		{
			_processes.Add(new AgentE1());
			_processes.Add(new AgentE2());
			_processes.Add(new AgentE3());
			_processes.Add(new AgentE4());
		}

		public IProcessStep GetStep(int stepIndex) { return _processes[stepIndex]; }

		public void InitializeProcess()
		{
			throw new NotImplementedException();
		}

		public void FinalizeProcess()
		{
			throw new NotImplementedException();
		}
	}
}
