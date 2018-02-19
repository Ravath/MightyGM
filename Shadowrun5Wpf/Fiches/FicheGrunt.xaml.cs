using Core.Data;
using CoreWpf.UI;
using Shadowrun5.Data;
using Shadowrun5.JdrCore;
using Shadowrun5.JdrCore.Agents;
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

namespace Shadowrun5Wpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheGrunt.xaml
	/// </summary>
	public partial class FicheGrunt : UserControl, IFiche {

		private Grunt _grunt;
		private List<Metatype> _metatypes = new List<Metatype>();

		public IEnumerable<Metatype> Metatypes {
			get {
				return _metatypes;
			}
			set {
				_metatypes.Clear();
                _metatypes.AddRange(value);
				xgMetatype.ItemsSource = _metatypes;
				xlMetatype.ItemsSource = _metatypes;
				xgMetatype.SelectedItem = _metatypes[0];
				xlMetatype.SelectedItem = _metatypes[0];
			}
		}

		public FicheGrunt() {
			InitializeComponent();
        }

		public Grunt Grunt {
			get { return _grunt; }
			set {
				_grunt = value;
				SetAffichage(value);
			}
		}

		private void SetAffichage( Grunt es ) {
			xgName.Text = string.Format("{0} (Prof {1})", es.Name, es.Professionalism.TotalValue);
			xlName.Text = string.Format("{0} (Prof {1})", es.Alter.Name, es.Alter.Professionalism.TotalValue);
			es.Metatype = (Metatype)xgMetatype?.SelectedItem;
			es.Alter.Metatype = (Metatype)xlMetatype?.SelectedItem;
		}

		public object SelectedObject {
			get {
				return _grunt;
			}
			set {
				if(value is Grunt)
					Grunt = (Grunt)value;
				else {
					if(Grunt == null)
						Grunt = new Grunt();
					if(value is GruntModel) {
						Grunt.SetModel((GruntModel)value);
						LieutenantModel lm = ((GruntModel)value).Lieutenant;
						if(lm!=null)
							Grunt.Alter.SetModel(lm);
					} else if(value is GruntExemplar) {
						Grunt.SetExemplaire((GruntExemplar)value);
						GruntModel gm = (GruntModel)((GruntExemplar)value).Model;
						if(gm.Lieutenant!=null)
							Grunt.Alter.SetModel(gm.Lieutenant);
					} else if(value is LieutenantModel) {
						Grunt.Alter.SetModel(((LieutenantModel)value));
						GruntModel gm = ((LieutenantModel)value).Grunt;
						if(gm != null)
							Grunt.SetModel(gm);
					} else if(value is LieutenantExemplar) {
						Grunt.Alter.SetExemplaire((LieutenantExemplar)value);
						LieutenantModel lm = (LieutenantModel)((LieutenantExemplar)value).Model;
						if(lm.Grunt != null)
							Grunt.SetModel(lm.Grunt);
					}
					SetAffichage(Grunt);
				}
				/* affichage modules grunt */
				if(cfgAttributs.SelectedObject == null)
					cfgAttributs.SelectedObject = Grunt.Caracteristiques;
				cfgCompetences.SelectedObject = null;
				cfgCompetences.SelectedObject = Grunt.Competences;
				/* affichage modules lieutenant */
				if(cflAttributs.SelectedObject == null)
					cflAttributs.SelectedObject = Grunt.Alter.Caracteristiques;
				cflCompetences.SelectedObject = null;
				cflCompetences.SelectedObject = Grunt.Alter.Competences;
			}
		}

		private void xgMetatype_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			if(_grunt != null) {
				Grunt.Metatype = (Metatype)xgMetatype?.SelectedItem;
			}
		}

		private void xlMetatype_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			if(_grunt != null) {
				Grunt.Alter.Metatype = (Metatype)xlMetatype?.SelectedItem;
			}
		}
	}
}
