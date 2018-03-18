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
	/// Logique d'interaction pour CandidateSortsMahou.xaml
	/// </summary>
	public partial class CandidateSortsMahou : UserControl, IFicheCandidate {

		private Database _data;
		private IEnumerable<SortModel> _sorts;
		private IEnumerable<MahouModel> _mahous;

		public CandidateSortsMahou() {
			InitializeComponent();
		}

		public UserControl Control {
			get { return this; }
		}

		public string FicheName {
			get { return "Sorts"; }
		}

		public void Afficher( IGlobalContext c ) {
			_data = c.Data;
			_sorts = _data.GetTable<SortModel>();
			_mahous = _data.GetTable<MahouModel>();
			xMahou.Items = _mahous;
			xUniv.Items = _sorts.Where(s => s.Element == ElementSort.Universel).OrderBy(n => n.Name);
			xFeu.Items = _sorts.Where(s => s.Element == ElementSort.Feu).OrderBy(n => n.Maitrise).ThenBy(n => n.Name);
			xAir.Items = _sorts.Where(s => s.Element == ElementSort.Air).OrderBy(n => n.Maitrise).ThenBy(n => n.Name);
			xTerre.Items = _sorts.Where(s => s.Element == ElementSort.Terre).OrderBy(n => n.Maitrise).ThenBy(n => n.Name);
			xEau.Items = _sorts.Where(s => s.Element == ElementSort.Eau).OrderBy(n => n.Maitrise).ThenBy(n => n.Name);
		}
	}
}
