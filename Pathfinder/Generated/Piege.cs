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
	[Table(Schema = "pathfinder",Name = "piegemodel")]
	[CoreData]
	public partial class PiegeModel : DataModel {

		private PiegeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PiegeDescription> id = GetModelReferencer<PiegeDescription>();
					if(id.Count() == 0) {
						_obj = new PiegeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _fP;
		[Column(Storage = "FP",Name = "fp")]
		public int FP{
			get{ return _fP;}
			set{_fP = value;}
		}

		private TypePiege _type;
		[Column(Storage = "Type",Name = "type")]
		public TypePiege Type{
			get{ return _type;}
			set{_type = value;}
		}

		private DeclencheurPiege _declencheur;
		[Column(Storage = "Declencheur",Name = "declencheur")]
		public DeclencheurPiege Declencheur{
			get{ return _declencheur;}
			set{_declencheur = value;}
		}

		private RemisePiege _remise;
		[Column(Storage = "Remise",Name = "remise")]
		public RemisePiege Remise{
			get{ return _remise;}
			set{_remise = value;}
		}

		private Desarmement _desarmement;
		[Column(Storage = "Desarmement",Name = "desarmement")]
		public Desarmement Desarmement{
			get{ return _desarmement;}
			set{_desarmement = value;}
		}

		private int _dDFouille;
		[Column(Storage = "DDFouille",Name = "ddfouille")]
		public int DDFouille{
			get{ return _dDFouille;}
			set{_dDFouille = value;}
		}

		private int _dDDesamorcage;
		[Column(Storage = "DDDesamorcage",Name = "dddesamorcage")]
		public int DDDesamorcage{
			get{ return _dDDesamorcage;}
			set{_dDDesamorcage = value;}
		}

		private int _prix;
		[Column(Storage = "Prix",Name = "prix")]
		public int Prix{
			get{ return _prix;}
			set{_prix = value;}
		}

		private int _duree;
		[Column(Storage = "Duree",Name = "duree")]
		public int Duree{
			get{ return _duree;}
			set{_duree = value;}
		}

		private bool _fosse;
		[Column(Storage = "Fosse",Name = "fosse")]
		public bool Fosse{
			get{ return _fosse;}
			set{_fosse = value;}
		}

		private bool _liquide;
		[Column(Storage = "Liquide",Name = "liquide")]
		public bool Liquide{
			get{ return _liquide;}
			set{_liquide = value;}
		}

		private bool _gaz;
		[Column(Storage = "Gaz",Name = "gaz")]
		public bool Gaz{
			get{ return _gaz;}
			set{_gaz = value;}
		}

		private bool _neRateJamais;
		[Column(Storage = "NeRateJamais",Name = "neratejamais")]
		public bool NeRateJamais{
			get{ return _neRateJamais;}
			set{_neRateJamais = value;}
		}

		private bool _ciblesMultiples;
		[Column(Storage = "CiblesMultiples",Name = "ciblesmultiples")]
		public bool CiblesMultiples{
			get{ return _ciblesMultiples;}
			set{_ciblesMultiples = value;}
		}

		private int _retardement;
		[Column(Storage = "Retardement",Name = "retardement")]
		public int Retardement{
			get{ return _retardement;}
			set{_retardement = value;}
		}

		private bool _pieux;
		[Column(Storage = "Pieux",Name = "pieux")]
		public bool Pieux{
			get{ return _pieux;}
			set{_pieux = value;}
		}

		private int _attaqueId;
		[Column(Storage = "AttaqueId",Name = "fk_attaquepiege_attaque")]
		[HiddenProperty]
		public int AttaqueId{
			get{ return _attaqueId;}
			set{_attaqueId = value;}
		}

		private AttaquePiege _attaque;
		public AttaquePiege Attaque{
			get{
				if( _attaque == null)
					_attaque = LoadById<AttaquePiege>(AttaqueId);
				return _attaque;
			} set {
				if(_attaque == value){return;}
				_attaque = value;
				if( value != null)
					AttaqueId = value.Id;
			}
		}

		private int _afflictionId;
		[Column(Storage = "AfflictionId",Name = "fk_afflictionmodel_affliction")]
		[HiddenProperty]
		public int AfflictionId{
			get{ return _afflictionId;}
			set{_afflictionId = value;}
		}

		private AfflictionModel _affliction;
		public AfflictionModel Affliction{
			get{
				if( _affliction == null)
					_affliction = LoadById<AfflictionModel>(AfflictionId);
				return _affliction;
			} set {
				if(_affliction == value){return;}
				_affliction = value;
				if( value != null)
					AfflictionId = value.Id;
			}
		}

		private int _sortId;
		[Column(Storage = "SortId",Name = "fk_sortexemplar_sort")]
		[HiddenProperty]
		public int SortId{
			get{ return _sortId;}
			set{_sortId = value;}
		}

		private SortExemplar _sort;
		public SortExemplar Sort{
			get{
				if( _sort == null)
					_sort = LoadById<SortExemplar>(SortId);
				return _sort;
			} set {
				if(_sort == value){return;}
				_sort = value;
				if( value != null)
					SortId = value.Id;
			}
		}

		private int _nLS;
		[Column(Storage = "NLS",Name = "nls")]
		public int NLS{
			get{ return _nLS;}
			set{_nLS = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "piegedescription")]
	public partial class PiegeDescription : DataDescription<PiegeModel> {
	}
	[Table(Schema = "pathfinder",Name = "piegeexemplar")]
	public partial class PiegeExemplar : DataExemplaire<PiegeModel> {
	}
}
