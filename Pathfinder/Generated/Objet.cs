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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "objetmodel")]
	public abstract partial class ObjetModel : DataModel {

		private int _poids;
		[Column(Storage = "Poids",Name = "poids")]
		public int Poids{
			get{ return _poids;}
			set{_poids = value;}
		}

		private int _prix;
		[Column(Storage = "Prix",Name = "prix")]
		public int Prix{
			get{ return _prix;}
			set{_prix = value;}
		}

		private int _solidite;
		[Column(Storage = "Solidite",Name = "solidite")]
		public int Solidite{
			get{ return _solidite;}
			set{_solidite = value;}
		}

		private int _resistance;
		[Column(Storage = "Resistance",Name = "resistance")]
		public int Resistance{
			get{ return _resistance;}
			set{_resistance = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "objetdescription")]
	public abstract partial class ObjetDescription : DataDescription<ObjetModel> {
	}
	[Table(Schema = "pathfinder",Name = "objetexemplar")]
	public abstract partial class ObjetExemplar : DataExemplaire<ObjetModel> {

		private int _soliditeCourante;
		[Column(Storage = "SoliditeCourante",Name = "soliditecourante")]
		public int SoliditeCourante{
			get{ return _soliditeCourante;}
			set{_soliditeCourante = value;}
		}

		private CategorieTaille _taille;
		[Column(Storage = "Taille",Name = "taille")]
		public CategorieTaille Taille{
			get{ return _taille;}
			set{_taille = value;}
		}

		private int _matiereId;
		[Column(Storage = "MatiereId",Name = "fk_matiere_matiere")]
		[HiddenProperty]
		public int MatiereId{
			get{ return _matiereId;}
			set{_matiereId = value;}
		}

		private Matiere _matiere;
		public Matiere Matiere{
			get{
				if( _matiere == null)
					_matiere = LoadById<Matiere>(MatiereId);
				return _matiere;
			} set {
				if(_matiere == value){return;}
				_matiere = value;
				if( value != null)
					MatiereId = value.Id;
			}
		}
	}
}
