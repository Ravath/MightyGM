using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processes
{
	/// <summary>
	/// A process, generaly of charracter creation, where every step is done one after another.
	/// </summary>
	public interface IProcess
	{
		/// <summary>
		/// Data access
		/// </summary>
		Database Data { get; }
		/// <summary>
		/// The creation options.
		/// </summary>
		IProcessParameters Parameters { get; }
		/// <summary>
		/// The total number of steps the process manages.
		/// </summary>
		int NbrSteps { get; }
		/// <summary>
		/// Get the Step Control by index.
		/// </summary>
		/// <param name="stepIndex">Index of the step to get.</param>
		/// <returns>A step of the process.</returns>
		IProcessStep GetStep(int stepIndex);
		/// <summary>
		/// Done at start of the process, before the first step.
		/// </summary>
		void InitializeProcess();
		/// <summary>
		/// Done at end of the process, after the last step.
		/// </summary>
		/// <param name="endArgs"></param>
		void FinalizeProcess(IProcessEndArguments endArgs);
		/// <summary>
		/// This event should be fired at end of FinalizeProcess.
		/// </summary>
		event Action<IProcessEndArguments> EndOfProcess;
	}
}
