using Core;
using Core.Contexts;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CoreWpf.UI {
	/// <summary>
	/// Affiche une liste d'éléments, et affiche l'élément sélectionné dans un afficheur du type donné.
	/// Est aussi une fiche utilisée par le contexte local.
	/// </summary>
	/// <typeparam name="M"></typeparam>
	/// <typeparam name="F"></typeparam>
	public class FicheLecture<M,F> : UserControl, IFicheCandidate
		where M : DataModel
		where F :IFiche, new() {

		#region Members
		private IGlobalContext _globalContext;
		private ListeFiche<M> _grunt;
		private IEnumerable<M> _gruntList;
		private string _name;
		private F _fiche;
		#endregion

		public FicheLecture( string name) {
			_name = name;
			_fiche = new F();
			_grunt = new ListeFiche<M>();
			_grunt.Afficheur = _fiche;
			this.Content = _grunt;
			this.KeyDown += FicheLecture_KeyDown;
		}

		private void FicheLecture_KeyDown( object sender, System.Windows.Input.KeyEventArgs e ) {
			if(e.Key == System.Windows.Input.Key.F5) {
				Refresh(_globalContext);
			}
		}

		public F Fiche {
			get { return _fiche; }
		}

		public UserControl Control {
			get { return this; }
		}

		public void Afficher( IGlobalContext c ) {
			_globalContext = c;
			if(_gruntList == null)
				Refresh(c);
			if(AfficherEvent != null)
				AfficherEvent(this, c);
        }
		/// <summary>
		/// Recharge les données depuis la DB.
		/// </summary>
		/// <param name="c"></param>
		public void Refresh( IGlobalContext c ) {
			_gruntList = c.Data.GetTable<M>();
			_grunt.SetDataSource(_gruntList);
		}

		public AfficherEventHandler AfficherEvent;
		public delegate void AfficherEventHandler( FicheLecture<M,F> sender, IGlobalContext context );

		string IFicheCandidate.FicheName {
			get { return _name; }
		}
	}
}
