using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
using Core.Gestion;
using Core.Engine;

namespace StarWars.Data {
	public partial class PJModel {
		public PJModel() { }

		#region Propriété Joueur
		private int _joueurId;
		[Column(Storage = "JoueurId", Name = "fk_joueurid")]
		[HiddenProperty]
		public int JoueurId {
			get { return _joueurId; }
			set { _joueurId = value; }
		}

		private Joueur _joueur;
		public Joueur Joueur {
			get {
				if(_joueur == null)
					_joueur = LoadById<Joueur>(JoueurId);
				return _joueur;
			}
			set {
				if(_joueur == value) { return; }
				_joueur = value;
				if(value != null)
					JoueurId = value.Id;
			}
		} 
		#endregion

		#region Obligations
		private List<ObligationsExemplar> _tempObligations = new List<ObligationsExemplar>();
		public void ClearObligations() {
			_tempObligations.Clear();
		}
		public void AddObligation( ObligationsExemplar oe ) {
			if(oe == null) { return; }
			_tempObligations.Add(oe);
		}
		#endregion

	}
	public partial class PJDescription {
	}
	public partial class PJExemplar {
	}
}
