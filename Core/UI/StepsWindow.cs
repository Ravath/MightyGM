using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Core.UI {

	public interface IStepsArgument {
		/// <summary>
		/// Init the arguments at the begining of the steps.
		/// </summary>
		void Init();
    }

	public abstract class Step : UserControl {
		protected static readonly string defaultErrorMessage = "";
		/// <summary>
		/// Cheks if it is possible to progress to the next step.
		/// </summary>
		/// <returns>true is ready</returns>
		public abstract bool CanProgress( out string errorMessage  );
		/// <summary>
		/// Undo modifications of the step if necessary, when returning backward.
		/// </summary>
		public abstract void GoBack();
		/// <summary>
		/// Fonction appellée lorsque le controleur arrive à cette étape.
		/// </summary>
		/// <param name="args"></param>
		/// <param name="personnage"></param>
		public abstract void Init( IStepsArgument args );
	}
	public enum FinishedState {
		Done, Canceled
	}
	public class StepsWindowsFinishedArguments {
		public FinishedState FinishedState { get; internal set; }
    }

	public class StepsWindow : UserControl {
		#region Events
		/// <summary>
		/// The operations to do when finished.
		/// </summary>
		public event StepsFinishedHandler StepsFinished;
		public delegate void StepsFinishedHandler( IStepsArgument arg, StepsWindowsFinishedArguments endargs ); 
		#endregion

		private IEnumerable<Step> _steps;
		private IStepsArgument _args;
		private int _currentStep = 0;

		private Button bNext;
		private Button bPrev;
		private Button bCancel;
		private UserControl us;

		public bool IsAtLastStep {
			get {
				return _currentStep == _steps.Count() - 1;
			}
		}

		public IStepsArgument Arguments {
			get { return _args; }
		}

		public bool IsAtFirstStep {
			get { return _currentStep == 0; }
		}

		public Step CurrentStep {
			get {
				return _steps.ElementAt(_currentStep);
            }
		}

		public StepsWindow( IEnumerable<Step> steps, IStepsArgument args ) {
			_steps = steps;
			_args = args;
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
			StackPanel spPrevNext = new StackPanel();
			spPrevNext.HorizontalAlignment = HorizontalAlignment.Center;
			spPrevNext.Orientation = Orientation.Horizontal;
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
			_args.Init();
            CurrentStep.Init(_args);
		}

		private void SetStep( int num ) {
			//vérifications valeur
			if(_steps.Count() == 0)
				return;
			if(num < 0)
				num = 0;
			if(num >= _steps.Count())
				num = _steps.Count() - 1;
			//nouvelle étape
			bool forward = num > _currentStep;
			_currentStep = num;
			Step st = _steps.ElementAt(num);
			if(forward)
				st.Init(_args);
            us.Content = st;
			//gestion boutons
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

		private void End( StepsWindowsFinishedArguments endargs ) {
			if(StepsFinished != null)
				StepsFinished(_args, endargs);
		}

		private void BCancel_Click( object sender, RoutedEventArgs e ) {
			End( new StepsWindowsFinishedArguments { FinishedState = FinishedState.Canceled } );
        }

		private void BPrev_Click( object sender, RoutedEventArgs e ) {
			CurrentStep.GoBack();
			SetStep(_currentStep - 1);
		}

		private void BNext_Click( object sender, RoutedEventArgs e ) {
			string errorMessage;
			if(!CurrentStep.CanProgress(out errorMessage)) {
				MessageBox.Show("Can't progress to next step: "+ errorMessage);
				return;
			}
			if(IsAtLastStep) {
				End(new StepsWindowsFinishedArguments { FinishedState = FinishedState.Done });
			} else {
				SetStep(_currentStep + 1);
			}
		}
	}
}
