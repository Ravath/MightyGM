using CinqAnneaux.JdrCore;
using Core;
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
	/// Logique d'interaction pour FicheHonneur.xaml
	/// </summary>
	public partial class FicheHonneur : UserControl, IFicheCandidate {
		private IGlobalContext _context;

		public FicheHonneur() {
			InitializeComponent();
			int r;
			foreach(GainHonneur gh in GainHonneur.Tableau) {
				xGainHonneurGrid.RowDefinitions.Add(new RowDefinition());
				TextBlock ta = new TextBlock() { Text = gh.Acte };
				r = xGainHonneurGrid.RowDefinitions.Count-1;
				TextBlock t0 = new TextBlock() { Text = gh.Gain0.ToString(), TextAlignment = TextAlignment.Center };
				TextBlock t1 = new TextBlock() { Text = gh.Gain1.ToString(), TextAlignment = TextAlignment.Center };
				TextBlock t2 = new TextBlock() { Text = gh.Gain2.ToString(), TextAlignment = TextAlignment.Center };
				TextBlock t3 = new TextBlock() { Text = gh.Gain3.ToString(), TextAlignment = TextAlignment.Center };
				TextBlock t4 = new TextBlock() { Text = gh.Gain4.ToString(), TextAlignment = TextAlignment.Center };
				TextBlock t5 = new TextBlock() { Text = gh.Gain5.ToString(), TextAlignment = TextAlignment.Center };
				//add in hierarchy
				if(r % 3 == 0) {
					Border ba = new Border() { Child = ta, BorderThickness = new Thickness() { Bottom = 1 }, BorderBrush=Brushes.Black };
					Border b0 = new Border() { Child = t0, BorderThickness = new Thickness() { Bottom = 1 }, BorderBrush=Brushes.Black };
					Border b1 = new Border() { Child = t1, BorderThickness = new Thickness() { Bottom = 1 }, BorderBrush=Brushes.Black };
					Border b2 = new Border() { Child = t2, BorderThickness = new Thickness() { Bottom = 1 }, BorderBrush=Brushes.Black };
					Border b3 = new Border() { Child = t3, BorderThickness = new Thickness() { Bottom = 1 }, BorderBrush=Brushes.Black };
					Border b4 = new Border() { Child = t4, BorderThickness = new Thickness() { Bottom = 1 }, BorderBrush=Brushes.Black };
					Border b5 = new Border() { Child = t5, BorderThickness = new Thickness() { Bottom = 1 }, BorderBrush=Brushes.Black };
					Grid.SetColumn(b0, 0);
					Grid.SetColumn(b1, 1);
					Grid.SetColumn(b2, 2);
					Grid.SetColumn(b3, 3);
					Grid.SetColumn(b4, 4);
					Grid.SetColumn(b5, 5);
					Grid.SetRow(b0, r);
					Grid.SetRow(b1, r);
					Grid.SetRow(b2, r);
					Grid.SetRow(b3, r);
					Grid.SetRow(b4, r);
					Grid.SetRow(b5, r);
					xGainHonneurGrid.Children.Add(b0);
					xGainHonneurGrid.Children.Add(b1);
					xGainHonneurGrid.Children.Add(b2);
					xGainHonneurGrid.Children.Add(b3);
					xGainHonneurGrid.Children.Add(b4);
					xGainHonneurGrid.Children.Add(b5);
					xGainHonneurActe.Children.Add(ba);
				} else {
					Grid.SetColumn(t0, 0);
					Grid.SetColumn(t1, 1);
					Grid.SetColumn(t2, 2);
					Grid.SetColumn(t3, 3);
					Grid.SetColumn(t4, 4);
					Grid.SetColumn(t5, 5);
					Grid.SetRow(t0, r);
					Grid.SetRow(t1, r);
					Grid.SetRow(t2, r);
					Grid.SetRow(t3, r);
					Grid.SetRow(t4, r);
					Grid.SetRow(t5, r);
					xGainHonneurGrid.Children.Add(t0);
					xGainHonneurGrid.Children.Add(t1);
					xGainHonneurGrid.Children.Add(t2);
					xGainHonneurGrid.Children.Add(t3);
					xGainHonneurGrid.Children.Add(t4);
					xGainHonneurGrid.Children.Add(t5);
					xGainHonneurActe.Children.Add(ta);
				}
			}
		}

		public UserControl Control {
			get { return this; }
		}

		public string FicheName {
			get { return "Honneur"; }
		}

		public void Afficher( IGlobalContext c ) {
			_context = c;
        }
	}
}
