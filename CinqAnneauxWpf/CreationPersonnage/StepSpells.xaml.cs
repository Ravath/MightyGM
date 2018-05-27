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
	/// Logique d'interaction pour StepSpels.xaml
	/// </summary>
	public partial class StepSpells : UserControl, IProcessStepWpf
	{
		private AgentE3 _step;

		public StepSpells()
		{
			InitializeComponent();
		}
		public void InitStep(IProcessStep currentStep)
		{
			_step = (AgentE3)currentStep;
			//TODO
		}
	}
}
