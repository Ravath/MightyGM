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
	[Table(Schema = "starwars",Name = "specialitemodel")]
	[CoreData]
	public partial class SpecialiteModel : DataModel {

		private SpecialiteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpecialiteDescription> id = GetModelReferencer<SpecialiteDescription>();
					if(id.Count() == 0) {
						_obj = new SpecialiteDescription();
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

		private string _sousTitre;
		[Column(Storage = "SousTitre",Name = "soustitre")]
		public string SousTitre{
			get{ return _sousTitre;}
			set{_sousTitre = value;}
		}

		private IEnumerable<SpecialiteModelToCompetenceModel> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "SpecialiteModelId")]
		public IEnumerable <SpecialiteModelToCompetenceModel> Competences{
			get{
				if( _competences == null ){
					_competences = LoadByForeignKey<SpecialiteModelToCompetenceModel>(p => p.SpecialiteModelId, Id);
				}
				return _competences;
			}
			set{
				foreach( SpecialiteModelToCompetenceModel item in _competences ){
					item.SpecialiteModel = null;
				}
				_competences = value;
				foreach( SpecialiteModelToCompetenceModel item in value ){
					item.SpecialiteModel = this;
				}
			}
		}

		private int _carriereId;
		[Column(Storage = "CarriereId",Name = "fk_carrieremodel")]
		[HiddenProperty]
		public int CarriereId{
			get{ return _carriereId;}
			set{_carriereId = value;}
		}

		private CarriereModel _carriere;
		public CarriereModel Carriere{
			get {
				if(_carriere == null) {
					_carriere = LoadById<CarriereModel>(CarriereId);
			       }
				return _carriere;
			} set {
				if(value == _carriere) { return; }
				_carriere = value;
				if(_carriere != null) {
					_carriereId = _carriere.Id;
				} else {
					_carriereId = 0;
				}
			}
		}

		private int _arborescenceId;
		[Column(Storage = "ArborescenceId",Name = "fk_arborescencedespecialite")]
		[HiddenProperty]
		public int ArborescenceId{
			get{ return _arborescenceId;}
			set{_arborescenceId = value;}
		}

		private ArborescenceDeSpecialite _arborescence;
		public ArborescenceDeSpecialite Arborescence{
			get {
				if(_arborescence == null) {
					_arborescence = LoadById<ArborescenceDeSpecialite>(ArborescenceId);
			       }
				return _arborescence;
			} set {
				if(value == _arborescence) { return; }
				_arborescence = value;
				if(_arborescence != null) {
					_arborescenceId = _arborescence.Id;
				} else {
					_arborescenceId = 0;
				}
			}
		}
	}
	[Table(Schema = "starwars",Name = "specialitedescription")]
	public partial class SpecialiteDescription : DataDescription<SpecialiteModel> {
	}
	[Table(Schema = "starwars",Name = "specialiteexemplar")]
	public partial class SpecialiteExemplar : DataExemplaire<SpecialiteModel> {
	}
}
