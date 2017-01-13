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
	[Table(Schema = "cinqanneaux",Name = "arme_model")]
	public partial class ArmeModel : AbsObjetModel {

		private TypeArme _Type;
		[Column(Storage = "Type",Name = "type")]
		public TypeArme Type{
			get{ return _Type;}
			set{_Type = value;}
		}

		private int _keepVD;
		[Column(Storage = "KeepVD",Name = "keepvd")]
		public int KeepVD{
			get{ return _keepVD;}
			set{_keepVD = value;}
		}

		private int _rollVD;
		[Column(Storage = "RollVD",Name = "rollvd")]
		public int RollVD{
			get{ return _rollVD;}
			set{_rollVD = value;}
		}

		private IEnumerable<MotsClefFromArmeModel> _MotsClef;
		[Association(ThisKey = "Id",CanBeNull = "true",Storage = "MotsClef",OtherKey = "Arme")]
		public IEnumerable<MotsClefFromArmeModel> MotsClef{
			get {
				if(_MotsClef == null) {
					_MotsClef = LoadByForeignKey<MotsClefFromArmeModel>(p => p.ArmeModelId, Id);
			    }
				return _MotsClef;
			}
			set {
				foreach(MotsClefFromArmeModel item in _MotsClef) {
					item.ArmeModel = null;
				}
				_MotsClef = value;
				foreach(MotsClefFromArmeModel item in value) {
					item.ArmeModel = this;
				}
			}
		}


		private int? _force;
		[Column(Storage = "Force",Name = "force")]
		public int? Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int? _portee;
		[Column(Storage = "Portee",Name = "portee")]
		public int? Portee{
			get{ return _portee;}
			set{_portee = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "arme_exemplar")]
	public partial class ArmeExemplar : AbsObjetExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "arme_description")]
	public partial class ArmeDescription : AbsObjetDescription {

		private IEnumerable<SpecialFromArmeDescription> _Special;
		[Association(ThisKey = "Id",CanBeNull = "true",Storage = "Special",OtherKey = "Arme")]
		public IEnumerable<SpecialFromArmeDescription> Special{
			get {
				if(_Special == null) {
					_Special = LoadByForeignKey<SpecialFromArmeDescription>(p => p.ArmeDescriptionId, Id);
			    }
				return _Special;
			}
			set {
				foreach(SpecialFromArmeDescription item in _Special) {
					item.ArmeDescription = null;
				}
				_Special = value;
				foreach(SpecialFromArmeDescription item in value) {
					item.ArmeDescription = this;
				}
			}
		}

	}
	[Table(Schema = "cinqanneaux",Name = "motscleffromarmemodel")]
	public class MotsClefFromArmeModel : DataObject {

		private MotClefArme _MotsClef;
		[Column(Storage = "MotsClef",Name = "motsclef")]
		public MotClefArme MotsClef{
			get{ return _MotsClef;}
			set{_MotsClef = value;}
		}

		private int _armeId;
		[Column(Storage = "ArmeId",Name = "fk_arme")]
		public int ArmeId{
			get{ return _armeId}
			set{_armeId = value;}
		}

		private ArmeModel _armeModel;
		[Association(ThisKey = "ArmeId",CanBeNull = "false",Storage = "ArmeModel",OtherKey = "Id")]
		public ArmeModel ArmeModel{
			get {
				if(_armeModel == null) {
					_armeModel = LoadById<ArmeModel>(ArmeModelId);
			       }
				return _armeModel;
			} set {
				if(value == _armeModel) { return; }
				_armeModel = value;
				if(_armeModel != null) {
					_armeModelId = _armeModel.Id;
				} else {
					_armeModelId = 0;
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "specialfromarmedescription")]
	public class SpecialFromArmeDescription : DataObject {

		private string _special;
		[LargeText]
		[Column(Storage = "Special",Name = "special")]
		public string Special{
			get{ return _special;}
			set{_special = value;}
		}

		private int _armeId;
		[Column(Storage = "ArmeId",Name = "fk_arme")]
		public int ArmeId{
			get{ return _armeId}
			set{_armeId = value;}
		}

		private ArmeDescription _armeDescription;
		[Association(ThisKey = "ArmeId",CanBeNull = "false",Storage = "ArmeDescription",OtherKey = "Id")]
		public ArmeDescription ArmeDescription{
			get {
				if(_armeDescription == null) {
					_armeDescription = LoadById<ArmeDescription>(ArmeDescriptionId);
			       }
				return _armeDescription;
			} set {
				if(value == _armeDescription) { return; }
				_armeDescription = value;
				if(_armeDescription != null) {
					_armeDescriptionId = _armeDescription.Id;
				} else {
					_armeDescriptionId = 0;
				}
			}
		}
	}
}
