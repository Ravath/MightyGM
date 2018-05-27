using CinqAnneaux.Processes;
using Core.Processes;
using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinqAnneauxWpf.CreationPersonnage
{
	/// <summary>
	/// Logique d'interaction pour StepExperience.xaml
	/// </summary>
	public partial class StepExperience : UserControl, IProcessStepWpf
	{
		private AgentE4 _step;

		public StepExperience()
		{
			InitializeComponent();
		}

		public void InitStep(IProcessStep currentStep)
		{
			_step = (AgentE4)currentStep;
			//TODO
		}
	}
}
