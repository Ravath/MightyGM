using CinqAnneaux.Data;
using Core;
using Core.Data;
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
using CoreWpf;
using Core.Contexts;

namespace CinqAnneauxWpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheCandidateCapacites.xaml
	/// </summary>
	public partial class FicheCandidateCapacites : UserControl, IFicheCandidate {
		private Database _data;

		public FicheCandidateCapacites() {
			InitializeComponent();
		}

		public UserControl Control { get { return this; } }

		public string FicheName { get { return "Capacites"; } }

		public void Afficher( IGlobalContext c ) {
			_data = c.Data;
			xKatas.Items = _data.GetTable<KataModel>().OrderBy(n=>n.Name);
			xKihos.Items = _data.GetTable<KihoModel>().OrderBy(n=>n.Anneau).ThenBy(n => n.Name);
			xPouvoirs.Items = _data.GetTable<PouvoirOutremondeModel>().OrderBy(n=>n.TypePouvoir).ThenBy(n => n.Name);
		}
	}
}
