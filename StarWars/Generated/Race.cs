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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "racemodel")]
	[CoreData]
	public partial class RaceModel : DataModel {

		private RaceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RaceDescription> id = GetModelReferencer<RaceDescription>();
					if(id.Count() == 0) {
						_obj = new RaceDescription();
						_obj.Model = this;
						_obj.SaveObject();
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private int _vigueur;
		[Column(Storage = "Vigueur",Name = "vigueur")]
		public int Vigueur{
			get{ return _vigueur;}
			set{_vigueur = value;}
		}

		private int _agilite;
		[Column(Storage = "Agilite",Name = "agilite")]
		public int Agilite{
			get{ return _agilite;}
			set{_agilite = value;}
		}

		private int _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int _ruse;
		[Column(Storage = "Ruse",Name = "ruse")]
		public int Ruse{
			get{ return _ruse;}
			set{_ruse = value;}
		}

		private int _volonte;
		[Column(Storage = "Volonte",Name = "volonte")]
		public int Volonte{
			get{ return _volonte;}
			set{_volonte = value;}
		}

		private int _presence;
		[Column(Storage = "Presence",Name = "presence")]
		public int Presence{
			get{ return _presence;}
			set{_presence = value;}
		}

		private int _b_blessure;
		[Column(Storage = "b_blessure",Name = "b_blessure")]
		public int b_blessure{
			get{ return _b_blessure;}
			set{_b_blessure = value;}
		}

		private int _b_stress;
		[Column(Storage = "b_stress",Name = "b_stress")]
		public int b_stress{
			get{ return _b_stress;}
			set{_b_stress = value;}
		}

		private int _xp_depart;
		[Column(Storage = "xp_depart",Name = "xp_depart")]
		public int xp_depart{
			get{ return _xp_depart;}
			set{_xp_depart = value;}
		}

		private IEnumerable<CapaciteModel> _capacites;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Capacites",OtherKey = "RaceModelId")]
		public IEnumerable <CapaciteModel> Capacites{
			get{
				if( _capacites == null ){
					_capacites = LoadFromJointure<CapaciteModel,RaceModelToCapaciteModel>(false);
				}
				return _capacites;
			}
			set{
				SaveToJointure<CapaciteModel, RaceModelToCapaciteModel> (_capacites, value,false);
				_capacites = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<RaceModel,RaceModelToCapaciteModel>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "starwars",Name = "racedescription")]
	public partial class RaceDescription : DataDescription<RaceModel> {

		private string _psychologie = "";
		[LargeText]
		[Column(Storage = "Psychologie",Name = "psychologie")]
		public string Psychologie{
			get{ return _psychologie;}
			set{_psychologie = value;}
		}

		private string _societe = "";
		[LargeText]
		[Column(Storage = "Societe",Name = "societe")]
		public string Societe{
			get{ return _societe;}
			set{_societe = value;}
		}

		private string _mondeNatal = "";
		[LargeText]
		[Column(Storage = "MondeNatal",Name = "mondenatal")]
		public string MondeNatal{
			get{ return _mondeNatal;}
			set{_mondeNatal = value;}
		}

		private string _langue = "";
		[LargeText]
		[Column(Storage = "Langue",Name = "langue")]
		public string Langue{
			get{ return _langue;}
			set{_langue = value;}
		}

		private string _campagne = "";
		[LargeText]
		[Column(Storage = "Campagne",Name = "campagne")]
		public string Campagne{
			get{ return _campagne;}
			set{_campagne = value;}
		}
	}
	[Table(Schema = "starwars",Name = "raceexemplar")]
	public partial class RaceExemplar : DataExemplaire<RaceModel> {
	}
}
