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
	[Table(Schema = "pathfinder",Name = "lignageensorceleurmodel")]
	[CoreData]
	public partial class LignageEnsorceleurModel : PouvoirSpecialModel {

		private LignageEnsorceleurDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<LignageEnsorceleurDescription> id = GetModelReferencer<LignageEnsorceleurDescription>();
					if(id.Count() == 0) {
						_obj = new LignageEnsorceleurDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _competenceId;
		[Column(Storage = "CompetenceId",Name = "fk_competencemodel_competence")]
		[HiddenProperty]
		public int CompetenceId{
			get{ return _competenceId;}
			set{_competenceId = value;}
		}

		private CompetenceModel _competence;
		public CompetenceModel Competence{
			get{
				if( _competence == null)
					_competence = LoadById<CompetenceModel>(CompetenceId);
				return _competence;
			} set {
				if(_competence == value){return;}
				_competence = value;
				if( value != null)
					CompetenceId = value.Id;
			}
		}

		private int _arcaneId;
		[Column(Storage = "ArcaneId",Name = "fk_pouvoirspecialmodel_arcane")]
		[HiddenProperty]
		public int ArcaneId{
			get{ return _arcaneId;}
			set{_arcaneId = value;}
		}

		private PouvoirSpecialModel _arcane;
		public PouvoirSpecialModel Arcane{
			get{
				if( _arcane == null)
					_arcane = LoadById<PouvoirSpecialModel>(ArcaneId);
				return _arcane;
			} set {
				if(_arcane == value){return;}
				_arcane = value;
				if( value != null)
					ArcaneId = value.Id;
			}
		}

		private int _pouvoirLvl1Id;
		[Column(Storage = "PouvoirLvl1Id",Name = "fk_pouvoirspecialmodel_pouvoirlvl1")]
		[HiddenProperty]
		public int PouvoirLvl1Id{
			get{ return _pouvoirLvl1Id;}
			set{_pouvoirLvl1Id = value;}
		}

		private PouvoirSpecialModel _pouvoirLvl1;
		public PouvoirSpecialModel PouvoirLvl1{
			get{
				if( _pouvoirLvl1 == null)
					_pouvoirLvl1 = LoadById<PouvoirSpecialModel>(PouvoirLvl1Id);
				return _pouvoirLvl1;
			} set {
				if(_pouvoirLvl1 == value){return;}
				_pouvoirLvl1 = value;
				if( value != null)
					PouvoirLvl1Id = value.Id;
			}
		}

		private int _pouvoirLvl3Id;
		[Column(Storage = "PouvoirLvl3Id",Name = "fk_pouvoirspecialmodel_pouvoirlvl3")]
		[HiddenProperty]
		public int PouvoirLvl3Id{
			get{ return _pouvoirLvl3Id;}
			set{_pouvoirLvl3Id = value;}
		}

		private PouvoirSpecialModel _pouvoirLvl3;
		public PouvoirSpecialModel PouvoirLvl3{
			get{
				if( _pouvoirLvl3 == null)
					_pouvoirLvl3 = LoadById<PouvoirSpecialModel>(PouvoirLvl3Id);
				return _pouvoirLvl3;
			} set {
				if(_pouvoirLvl3 == value){return;}
				_pouvoirLvl3 = value;
				if( value != null)
					PouvoirLvl3Id = value.Id;
			}
		}

		private int _pouvoirLvl9Id;
		[Column(Storage = "PouvoirLvl9Id",Name = "fk_pouvoirspecialmodel_pouvoirlvl9")]
		[HiddenProperty]
		public int PouvoirLvl9Id{
			get{ return _pouvoirLvl9Id;}
			set{_pouvoirLvl9Id = value;}
		}

		private PouvoirSpecialModel _pouvoirLvl9;
		public PouvoirSpecialModel PouvoirLvl9{
			get{
				if( _pouvoirLvl9 == null)
					_pouvoirLvl9 = LoadById<PouvoirSpecialModel>(PouvoirLvl9Id);
				return _pouvoirLvl9;
			} set {
				if(_pouvoirLvl9 == value){return;}
				_pouvoirLvl9 = value;
				if( value != null)
					PouvoirLvl9Id = value.Id;
			}
		}

		private int _pouvoirLvl15Id;
		[Column(Storage = "PouvoirLvl15Id",Name = "fk_pouvoirspecialmodel_pouvoirlvl15")]
		[HiddenProperty]
		public int PouvoirLvl15Id{
			get{ return _pouvoirLvl15Id;}
			set{_pouvoirLvl15Id = value;}
		}

		private PouvoirSpecialModel _pouvoirLvl15;
		public PouvoirSpecialModel PouvoirLvl15{
			get{
				if( _pouvoirLvl15 == null)
					_pouvoirLvl15 = LoadById<PouvoirSpecialModel>(PouvoirLvl15Id);
				return _pouvoirLvl15;
			} set {
				if(_pouvoirLvl15 == value){return;}
				_pouvoirLvl15 = value;
				if( value != null)
					PouvoirLvl15Id = value.Id;
			}
		}

		private int _pouvoirLvl20Id;
		[Column(Storage = "PouvoirLvl20Id",Name = "fk_pouvoirspecialmodel_pouvoirlvl20")]
		[HiddenProperty]
		public int PouvoirLvl20Id{
			get{ return _pouvoirLvl20Id;}
			set{_pouvoirLvl20Id = value;}
		}

		private PouvoirSpecialModel _pouvoirLvl20;
		public PouvoirSpecialModel PouvoirLvl20{
			get{
				if( _pouvoirLvl20 == null)
					_pouvoirLvl20 = LoadById<PouvoirSpecialModel>(PouvoirLvl20Id);
				return _pouvoirLvl20;
			} set {
				if(_pouvoirLvl20 == value){return;}
				_pouvoirLvl20 = value;
				if( value != null)
					PouvoirLvl20Id = value.Id;
			}
		}

		private int _sortLvl3Id;
		[Column(Storage = "SortLvl3Id",Name = "fk_sortmodel_sortlvl3")]
		[HiddenProperty]
		public int SortLvl3Id{
			get{ return _sortLvl3Id;}
			set{_sortLvl3Id = value;}
		}

		private SortModel _sortLvl3;
		public SortModel SortLvl3{
			get{
				if( _sortLvl3 == null)
					_sortLvl3 = LoadById<SortModel>(SortLvl3Id);
				return _sortLvl3;
			} set {
				if(_sortLvl3 == value){return;}
				_sortLvl3 = value;
				if( value != null)
					SortLvl3Id = value.Id;
			}
		}

		private int _sortLvl5Id;
		[Column(Storage = "SortLvl5Id",Name = "fk_sortmodel_sortlvl5")]
		[HiddenProperty]
		public int SortLvl5Id{
			get{ return _sortLvl5Id;}
			set{_sortLvl5Id = value;}
		}

		private SortModel _sortLvl5;
		public SortModel SortLvl5{
			get{
				if( _sortLvl5 == null)
					_sortLvl5 = LoadById<SortModel>(SortLvl5Id);
				return _sortLvl5;
			} set {
				if(_sortLvl5 == value){return;}
				_sortLvl5 = value;
				if( value != null)
					SortLvl5Id = value.Id;
			}
		}

		private int _sortLvl7Id;
		[Column(Storage = "SortLvl7Id",Name = "fk_sortmodel_sortlvl7")]
		[HiddenProperty]
		public int SortLvl7Id{
			get{ return _sortLvl7Id;}
			set{_sortLvl7Id = value;}
		}

		private SortModel _sortLvl7;
		public SortModel SortLvl7{
			get{
				if( _sortLvl7 == null)
					_sortLvl7 = LoadById<SortModel>(SortLvl7Id);
				return _sortLvl7;
			} set {
				if(_sortLvl7 == value){return;}
				_sortLvl7 = value;
				if( value != null)
					SortLvl7Id = value.Id;
			}
		}

		private int _sortLvl9Id;
		[Column(Storage = "SortLvl9Id",Name = "fk_sortmodel_sortlvl9")]
		[HiddenProperty]
		public int SortLvl9Id{
			get{ return _sortLvl9Id;}
			set{_sortLvl9Id = value;}
		}

		private SortModel _sortLvl9;
		public SortModel SortLvl9{
			get{
				if( _sortLvl9 == null)
					_sortLvl9 = LoadById<SortModel>(SortLvl9Id);
				return _sortLvl9;
			} set {
				if(_sortLvl9 == value){return;}
				_sortLvl9 = value;
				if( value != null)
					SortLvl9Id = value.Id;
			}
		}

		private int _sortLvl11Id;
		[Column(Storage = "SortLvl11Id",Name = "fk_sortmodel_sortlvl11")]
		[HiddenProperty]
		public int SortLvl11Id{
			get{ return _sortLvl11Id;}
			set{_sortLvl11Id = value;}
		}

		private SortModel _sortLvl11;
		public SortModel SortLvl11{
			get{
				if( _sortLvl11 == null)
					_sortLvl11 = LoadById<SortModel>(SortLvl11Id);
				return _sortLvl11;
			} set {
				if(_sortLvl11 == value){return;}
				_sortLvl11 = value;
				if( value != null)
					SortLvl11Id = value.Id;
			}
		}

		private int _sortLvl13Id;
		[Column(Storage = "SortLvl13Id",Name = "fk_sortmodel_sortlvl13")]
		[HiddenProperty]
		public int SortLvl13Id{
			get{ return _sortLvl13Id;}
			set{_sortLvl13Id = value;}
		}

		private SortModel _sortLvl13;
		public SortModel SortLvl13{
			get{
				if( _sortLvl13 == null)
					_sortLvl13 = LoadById<SortModel>(SortLvl13Id);
				return _sortLvl13;
			} set {
				if(_sortLvl13 == value){return;}
				_sortLvl13 = value;
				if( value != null)
					SortLvl13Id = value.Id;
			}
		}

		private int _sortLvl15Id;
		[Column(Storage = "SortLvl15Id",Name = "fk_sortmodel_sortlvl15")]
		[HiddenProperty]
		public int SortLvl15Id{
			get{ return _sortLvl15Id;}
			set{_sortLvl15Id = value;}
		}

		private SortModel _sortLvl15;
		public SortModel SortLvl15{
			get{
				if( _sortLvl15 == null)
					_sortLvl15 = LoadById<SortModel>(SortLvl15Id);
				return _sortLvl15;
			} set {
				if(_sortLvl15 == value){return;}
				_sortLvl15 = value;
				if( value != null)
					SortLvl15Id = value.Id;
			}
		}

		private int _sortLvl17Id;
		[Column(Storage = "SortLvl17Id",Name = "fk_sortmodel_sortlvl17")]
		[HiddenProperty]
		public int SortLvl17Id{
			get{ return _sortLvl17Id;}
			set{_sortLvl17Id = value;}
		}

		private SortModel _sortLvl17;
		public SortModel SortLvl17{
			get{
				if( _sortLvl17 == null)
					_sortLvl17 = LoadById<SortModel>(SortLvl17Id);
				return _sortLvl17;
			} set {
				if(_sortLvl17 == value){return;}
				_sortLvl17 = value;
				if( value != null)
					SortLvl17Id = value.Id;
			}
		}

		private int _sortLvl19Id;
		[Column(Storage = "SortLvl19Id",Name = "fk_sortmodel_sortlvl19")]
		[HiddenProperty]
		public int SortLvl19Id{
			get{ return _sortLvl19Id;}
			set{_sortLvl19Id = value;}
		}

		private SortModel _sortLvl19;
		public SortModel SortLvl19{
			get{
				if( _sortLvl19 == null)
					_sortLvl19 = LoadById<SortModel>(SortLvl19Id);
				return _sortLvl19;
			} set {
				if(_sortLvl19 == value){return;}
				_sortLvl19 = value;
				if( value != null)
					SortLvl19Id = value.Id;
			}
		}

		private int _donsId;
		[Column(Storage = "DonsId",Name = "fk_donexemplar_dons")]
		[HiddenProperty]
		public int DonsId{
			get{ return _donsId;}
			set{_donsId = value;}
		}

		private DonExemplar _dons;
		public DonExemplar Dons{
			get{
				if( _dons == null)
					_dons = LoadById<DonExemplar>(DonsId);
				return _dons;
			} set {
				if(_dons == value){return;}
				_dons = value;
				if( value != null)
					DonsId = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "lignageensorceleurdescription")]
	public partial class LignageEnsorceleurDescription : PouvoirSpecialDescription {
	}
	[Table(Schema = "pathfinder",Name = "lignageensorceleurexemplar")]
	public partial class LignageEnsorceleurExemplar : PouvoirSpecialExemplar {
	}
}
