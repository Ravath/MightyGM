using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace CinqAnneaux.Data {
	[CoreData]
	[Table(Schema = "cinqanneaux",Name = "abssort_model")]
	public partial class AbsSortModel : DataModel {

		private ElementSort _Element;
		[Column(Storage = "Element",Name = "element")]
		public ElementSort Element{
			get{ return _Element;}
			set{_Element = value;}
		}

		private int _maitrise;
		[Column(Storage = "maitrise",Name = "maitrise")]
		public int maitrise{
			get{ return _maitrise;}
			set{_maitrise = value;}
		}

		private Portee _Portee;
		[Column(Storage = "Portee",Name = "portee")]
		public Portee Portee{
			get{ return _Portee;}
			set{_Portee = value;}
		}

		private decimal _facteurPortee;
		[Column(Storage = "facteurPortee",Name = "facteurportee")]
		public decimal facteurPortee{
			get{ return _facteurPortee;}
			set{_facteurPortee = value;}
		}

		private ZoneEffet _ZoneEffet;
		[Column(Storage = "ZoneEffet",Name = "zoneeffet")]
		public ZoneEffet ZoneEffet{
			get{ return _ZoneEffet;}
			set{_ZoneEffet = value;}
		}

		private decimal _facteurZone;
		[Column(Storage = "facteurZone",Name = "facteurzone")]
		public decimal facteurZone{
			get{ return _facteurZone;}
			set{_facteurZone = value;}
		}

		private Duree _Duree;
		[Column(Storage = "Duree",Name = "duree")]
		public Duree Duree{
			get{ return _Duree;}
			set{_Duree = value;}
		}

		private decimal _facteurDuree;
		[Column(Storage = "facteurDuree",Name = "facteurduree")]
		public decimal facteurDuree{
			get{ return _facteurDuree;}
			set{_facteurDuree = value;}
		}

		private IEnumerable<AbsSortModelToAugmentationSortModel> _Augmentations;
		public IEnumerable<AbsSortModelToAugmentationSortModel> Augmentations{
			get {
				if(_Augmentations == null) {
					_Augmentations = LoadByForeignKey<AbsSortModelToAugmentationSortModel>(p => p.AbsSortModelId, Id);
			    }
				return _Augmentations;
			}
			set {
				foreach(AbsSortModelToAugmentationSortModel item in _Augmentations) {
					item.AbsSortModel = null;
				}
				_Augmentations = value;
				foreach(AbsSortModelToAugmentationSortModel item in value) {
					item.AbsSortModel = this;
				}
			}
		}


		private IEnumerable<motClefsFromAbsSortModel> _motClefs;
		[Association(ThisKey = "Id",CanBeNull = "true",Storage = "motClefs",OtherKey = "AbsSort")]
		public IEnumerable<motClefsFromAbsSortModel> motClefs{
			get {
				if(_motClefs == null) {
					_motClefs = LoadByForeignKey<motClefsFromAbsSortModel>(p => p.AbsSortModelId, Id);
			    }
				return _motClefs;
			}
			set {
				foreach(motClefsFromAbsSortModel item in _motClefs) {
					item.AbsSortModel = null;
				}
				_motClefs = value;
				foreach(motClefsFromAbsSortModel item in value) {
					item.AbsSortModel = this;
				}
			}
		}

	}
	[Table(Schema = "cinqanneaux",Name = "abssort_exemplar")]
	public partial class AbsSortExemplar : DataExemplaire<AbsSortModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "abssort_description")]
	public partial class AbsSortDescription : DataDescription<AbsSortModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "motclefsfromabssortmodel")]
	public class motClefsFromAbsSortModel : DataObject {

		private MotClefSort _motClefs;
		[Column(Storage = "motClefs",Name = "motclefs")]
		public MotClefSort motClefs{
			get{ return _motClefs;}
			set{_motClefs = value;}
		}

		private int _absSortId;
		[Column(Storage = "AbsSortId",Name = "fk_abssort")]
		public int AbsSortId{
			get{ return _absSortId}
			set{_absSortId = value;}
		}

		private AbsSortModel _absSortModel;
		[Association(ThisKey = "AbsSortId",CanBeNull = "false",Storage = "AbsSortModel",OtherKey = "Id")]
		public AbsSortModel AbsSortModel{
			get {
				if(_absSortModel == null) {
					_absSortModel = LoadById<AbsSortModel>(AbsSortModelId);
			       }
				return _absSortModel;
			} set {
				if(value == _absSortModel) { return; }
				_absSortModel = value;
				if(_absSortModel != null) {
					_absSortModelId = _absSortModel.Id;
				} else {
					_absSortModelId = 0;
				}
			}
		}
	}
}
