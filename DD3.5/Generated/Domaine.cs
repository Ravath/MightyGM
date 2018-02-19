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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "domainemodel")]
	[CoreData]
	public partial class DomaineModel : DataModel {

		private DomaineDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DomaineDescription> id = GetModelReferencer<DomaineDescription>();
					if(id.Count() == 0) {
						_obj = new DomaineDescription();
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

		private int _pouvoirId;
		[Column(Storage = "PouvoirId",Name = "fk_pouvoirspecialmodel_pouvoir")]
		[HiddenProperty]
		public int PouvoirId{
			get{ return _pouvoirId;}
			set{_pouvoirId = value;}
		}

		private PouvoirSpecialModel _pouvoir;
		public PouvoirSpecialModel Pouvoir{
			get{
				if( _pouvoir == null)
					_pouvoir = LoadById<PouvoirSpecialModel>(PouvoirId);
				return _pouvoir;
			} set {
				if(_pouvoir == value){return;}
				_pouvoir = value;
				if( value != null)
					PouvoirId = value.Id;
			}
		}

		private int _sortIId;
		[Column(Storage = "SortIId",Name = "fk_sortmodel_sorti")]
		[HiddenProperty]
		public int SortIId{
			get{ return _sortIId;}
			set{_sortIId = value;}
		}

		private SortModel _sortI;
		public SortModel SortI{
			get{
				if( _sortI == null)
					_sortI = LoadById<SortModel>(SortIId);
				return _sortI;
			} set {
				if(_sortI == value){return;}
				_sortI = value;
				if( value != null)
					SortIId = value.Id;
			}
		}

		private int _sortIIId;
		[Column(Storage = "SortIIId",Name = "fk_sortmodel_sortii")]
		[HiddenProperty]
		public int SortIIId{
			get{ return _sortIIId;}
			set{_sortIIId = value;}
		}

		private SortModel _sortII;
		public SortModel SortII{
			get{
				if( _sortII == null)
					_sortII = LoadById<SortModel>(SortIIId);
				return _sortII;
			} set {
				if(_sortII == value){return;}
				_sortII = value;
				if( value != null)
					SortIIId = value.Id;
			}
		}

		private int _sortIIIId;
		[Column(Storage = "SortIIIId",Name = "fk_sortmodel_sortiii")]
		[HiddenProperty]
		public int SortIIIId{
			get{ return _sortIIIId;}
			set{_sortIIIId = value;}
		}

		private SortModel _sortIII;
		public SortModel SortIII{
			get{
				if( _sortIII == null)
					_sortIII = LoadById<SortModel>(SortIIIId);
				return _sortIII;
			} set {
				if(_sortIII == value){return;}
				_sortIII = value;
				if( value != null)
					SortIIIId = value.Id;
			}
		}

		private int _sortIVId;
		[Column(Storage = "SortIVId",Name = "fk_sortmodel_sortiv")]
		[HiddenProperty]
		public int SortIVId{
			get{ return _sortIVId;}
			set{_sortIVId = value;}
		}

		private SortModel _sortIV;
		public SortModel SortIV{
			get{
				if( _sortIV == null)
					_sortIV = LoadById<SortModel>(SortIVId);
				return _sortIV;
			} set {
				if(_sortIV == value){return;}
				_sortIV = value;
				if( value != null)
					SortIVId = value.Id;
			}
		}

		private int _sortVId;
		[Column(Storage = "SortVId",Name = "fk_sortmodel_sortv")]
		[HiddenProperty]
		public int SortVId{
			get{ return _sortVId;}
			set{_sortVId = value;}
		}

		private SortModel _sortV;
		public SortModel SortV{
			get{
				if( _sortV == null)
					_sortV = LoadById<SortModel>(SortVId);
				return _sortV;
			} set {
				if(_sortV == value){return;}
				_sortV = value;
				if( value != null)
					SortVId = value.Id;
			}
		}

		private int _sortVIId;
		[Column(Storage = "SortVIId",Name = "fk_sortmodel_sortvi")]
		[HiddenProperty]
		public int SortVIId{
			get{ return _sortVIId;}
			set{_sortVIId = value;}
		}

		private SortModel _sortVI;
		public SortModel SortVI{
			get{
				if( _sortVI == null)
					_sortVI = LoadById<SortModel>(SortVIId);
				return _sortVI;
			} set {
				if(_sortVI == value){return;}
				_sortVI = value;
				if( value != null)
					SortVIId = value.Id;
			}
		}

		private int _sortVIIId;
		[Column(Storage = "SortVIIId",Name = "fk_sortmodel_sortvii")]
		[HiddenProperty]
		public int SortVIIId{
			get{ return _sortVIIId;}
			set{_sortVIIId = value;}
		}

		private SortModel _sortVII;
		public SortModel SortVII{
			get{
				if( _sortVII == null)
					_sortVII = LoadById<SortModel>(SortVIIId);
				return _sortVII;
			} set {
				if(_sortVII == value){return;}
				_sortVII = value;
				if( value != null)
					SortVIIId = value.Id;
			}
		}

		private int _sortVIIIId;
		[Column(Storage = "SortVIIIId",Name = "fk_sortmodel_sortviii")]
		[HiddenProperty]
		public int SortVIIIId{
			get{ return _sortVIIIId;}
			set{_sortVIIIId = value;}
		}

		private SortModel _sortVIII;
		public SortModel SortVIII{
			get{
				if( _sortVIII == null)
					_sortVIII = LoadById<SortModel>(SortVIIIId);
				return _sortVIII;
			} set {
				if(_sortVIII == value){return;}
				_sortVIII = value;
				if( value != null)
					SortVIIIId = value.Id;
			}
		}

		private int _sortIXId;
		[Column(Storage = "SortIXId",Name = "fk_sortmodel_sortix")]
		[HiddenProperty]
		public int SortIXId{
			get{ return _sortIXId;}
			set{_sortIXId = value;}
		}

		private SortModel _sortIX;
		public SortModel SortIX{
			get{
				if( _sortIX == null)
					_sortIX = LoadById<SortModel>(SortIXId);
				return _sortIX;
			} set {
				if(_sortIX == value){return;}
				_sortIX = value;
				if( value != null)
					SortIXId = value.Id;
			}
		}
	}
	[Table(Schema = "dd35",Name = "domainedescription")]
	public partial class DomaineDescription : DataDescription<DomaineModel> {
	}
	[Table(Schema = "dd35",Name = "domaineexemplar")]
	public partial class DomaineExemplar : DataExemplaire<DomaineModel> {
	}
}
