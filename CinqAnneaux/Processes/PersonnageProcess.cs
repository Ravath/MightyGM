using CinqAnneaux.JdrCore.Agent;
using Core.Data;
using Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.Processes
{
	public class PersonnageProcess : IProcess
	{
		private PersonnageParameters _parameters;
		private List<IProcessStep> _processes = new List<IProcessStep>();

		public event Action<IProcessEndArguments> EndOfProcess;

		public Personnage Personnage { get; private set; }
		public IProcessParameters Parameters { get { return _parameters; } set { _parameters = (PersonnageParameters)value; } }
		public int NbrSteps { get { return _processes.Count; } }
		public Database Data { get; private set; }

		public IProcessStep GetStep(int stepIndex) { return _processes[stepIndex]; }

		public PersonnageProcess(Database data, PersonnageParameters parameters)
		{
			_parameters = parameters;
			_processes.Add(new AgentE1());
			_processes.Add(new AgentE2());
			_processes.Add(new AgentE3());
			_processes.Add(new AgentE4());
			Data = data;
		}

		public void InitializeProcess()
		{
			Personnage = new Personnage();
		}

		public void FinalizeProcess(IProcessEndArguments endArgs)
		{
			if(endArgs.FinishedState == FinishedState.Done)
			{
				//TODO agent saving in DB
				//Agent.Save();
			}
			EndOfProcess?.Invoke(endArgs);
		}
	}
}
