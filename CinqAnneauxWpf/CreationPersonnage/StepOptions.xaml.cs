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
using Core.Processes;
using CinqAnneaux.Processes;

namespace CinqAnneauxWpf.CreationPersonnage
{
	/// <summary>
	/// Logique d'interaction pour StepOptions.xaml
	/// </summary>
	public partial class StepOptions : UserControl, IProcessStepWpf
	{
		private AgentE2 _step;

		public StepOptions()
		{
			InitializeComponent();
		}

		public void InitStep(IProcessStep currentStep)
		{
			_step = (AgentE2)currentStep;
			//TODO
		}
	}
}
