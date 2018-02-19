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
	/// Logique d'interaction pour FicheObjets.xaml
	/// </summary>
	public partial class FicheAllObjets : UserControl, IFicheCandidate {

		#region Members
		private Database _data;
		private IEnumerable<ArmeModel> _dataArme;
		private IEnumerable<ArmureModel> _dataArmure;
		private IEnumerable<ObjetModel> _dataObjet;
		#endregion

		#region Init
		public FicheAllObjets() {
			InitializeComponent();
		}
		#endregion

		#region Implementation Fiche Candidate
		public UserControl Control {
			get { return this; }
		}

		public string FicheName {
			get { return "Objets"; }
		}
		public void SetData( Database data ) {
			_data = data;
			_dataArme = _data.GetTable<ArmeModel>().OrderBy(n => n.Name);
			_dataArmure = _data.GetTable<ArmureModel>().OrderBy(n=>n.Tag);
			_dataObjet = _data.GetTable<ObjetModel>().OrderBy(n => n.Name);
			xArmures.Items = _dataArmure;
			xObjets.Items = _dataObjet;
			xArmes.Items = _dataArme;
        }
		public void Afficher( IGlobalContext c ) {
			SetData(c.Data);
		}
		#endregion
	}
}
