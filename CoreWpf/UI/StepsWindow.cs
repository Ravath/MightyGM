using Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CoreWpf.UI {
	/// <summary>
	/// Tag implementation for UserControls used for steps of a process.
	/// </summary>
	public interface IProcessStepWpf
	{
		/// <summary>
		/// Initialize the User Control at start of the step.
		/// </summary>
		/// <param name="currentStep"></param>
		void InitStep(IProcessStep currentStep);
	}

	/// <summary>
	/// Manages a step by step process by controling the flow with Wpf userControls.
	/// </summary>
	public class StepsWindow : UserControl {

		#region Members
		private IProcess _process;
		private int _currentStep = 0;
		private IEnumerable<IProcessStepWpf> _stepControlers;

		private Button bNext;
		private Button bPrev;
		private Button bCancel;
		private UserControl us;
		#endregion

		#region Properties
		public bool IsAtLastStep
		{
			get
			{
				return _currentStep == _process.NbrSteps-1;
			}
		}

		public IProcessParameters Arguments
		{
			get { return _process.Parameters; }
		}

		public bool IsAtFirstStep
		{
			get { return _currentStep == 0; }
		}

		public IProcessStep CurrentStep
		{
			get
			{
				return _process.GetStep(_currentStep);
			}
		} 
		#endregion

		public StepsWindow( IProcess process, IEnumerable<IProcessStepWpf> stepControlers ) {
			if(process.NbrSteps != stepControlers.Count())
			{
				throw new ArgumentException("Windows arguments must have an interface Controler per Step.");
			}
			_process = process;
			_stepControlers = stepControlers;
			//buttons
			double fSize = 15;
			bNext = new Button() { Content = "_S>" };
			bPrev = new Button() { Content = "_Q<" };
			bPrev.Width = 50;
			bPrev.Height = 50;
			bNext.Width = 50;
			bNext.Height = 50;
			bNext.FontSize = fSize;
			bPrev.FontSize = fSize;
			bCancel = new Button() { Content = "Cancel" };
			bCancel.Width = 100;
			bCancel.FontSize = fSize;
            bNext.Click += BNext_Click;
			bPrev.Click += BPrev_Click;
			bCancel.Click += BCancel_Click;
			DockPanel dButs = new DockPanel();
			dButs.Children.Add(bCancel);
            DockPanel.SetDock(bCancel,Dock.Left);
			StackPanel spPrevNext = new StackPanel
			{
				HorizontalAlignment = HorizontalAlignment.Center,
				Orientation = Orientation.Horizontal
			};
			spPrevNext.Children.Add(bPrev);
			spPrevNext.Children.Add(bNext);
			dButs.Children.Add(spPrevNext);
			//control
			us = new UserControl();
			DockPanel dock = new DockPanel();
			dock.Children.Add(dButs);
			DockPanel.SetDock(dButs, Dock.Bottom);
			dock.Children.Add(us);
			this.Content = dock;
			//init
			InitSteps();
        }

		public void InitSteps() {
			SetStep(0);
			_process.InitializeProcess();
            CurrentStep.Init(_process);
		}

		/// <summary>
		/// Go to the designated step.
		/// </summary>
		/// <param name="num">Index of the step to reach.</param>
		private void SetStep( int num ) {
			//argument check (force to stay within range)
			if(_process.NbrSteps == 0)
				return;
			if(num < 0)
				num = 0;
			if(num >= _process.NbrSteps)
				num = _process.NbrSteps - 1;
			//Update states
			_currentStep = num;
			IProcessStepWpf stepUc = _stepControlers.ElementAt(num);
			us.Content = stepUc;
			stepUc.InitStep(CurrentStep);
			//Buttons management
			if(IsAtFirstStep) {
				bPrev.IsEnabled = false;
			} else {
				bPrev.IsEnabled = true;
			}
			if(IsAtLastStep) {
				bNext.Content = "_Done";
			} else {
				bNext.Content = "_S>";
			}
        }

		private void End(IProcessEndArguments endargs) {
			_process.FinalizeProcess(endargs);
		}

		private void Next()
		{
			CurrentStep.PreprossNext();
			SetStep(_currentStep + 1);
			CurrentStep.Init(_process);
		}

		private void Previous()
		{
			CurrentStep.Reset();
			SetStep(_currentStep - 1);
			CurrentStep.PreprossReset();
		}

		#region Buttons Events
		private void BCancel_Click(object sender, RoutedEventArgs e)
		{
			End(new IProcessEndArguments { FinishedState = FinishedState.Canceled });
		}

		private void BPrev_Click(object sender, RoutedEventArgs e)
		{
			Previous();
		}

		private void BNext_Click(object sender, RoutedEventArgs e)
		{
			if (!CurrentStep.CanProgress(out string errorMessage))
			{
				MessageBox.Show("Can't progress to next step: " + errorMessage);
				return;
			}
			if (IsAtLastStep)
			{
				CurrentStep.PreprossNext();
				End(new IProcessEndArguments { FinishedState = FinishedState.Done });
			}
			else
			{
				Next();
			}
		}
		#endregion
	}
}
