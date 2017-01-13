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
	[Table(Schema = "starwars",Name = "pouvoirforcemodel")]
	[CoreData]
	public partial class PouvoirForceModel : DataModel {

		private PouvoirForceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirForceDescription> id = GetModelReferencer<PouvoirForceDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirForceDescription();
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

		private int _arborescenceId;
		[Column(Storage = "ArborescenceId",Name = "fk_arborescencedeforce")]
		[HiddenProperty]
		public int ArborescenceId{
			get{ return _arborescenceId;}
			set{_arborescenceId = value;}
		}

		private ArborescenceDeForce _arborescence;
		public ArborescenceDeForce Arborescence{
			get {
				if(_arborescence == null) {
					_arborescence = LoadById<ArborescenceDeForce>(ArborescenceId);
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
	[Table(Schema = "starwars",Name = "pouvoirforcedescription")]
	public partial class PouvoirForceDescription : DataDescription<PouvoirForceModel> {

		private string _pouvoirDeBase;
		[LargeText]
		[Column(Storage = "PouvoirDeBase",Name = "pouvoirdebase")]
		public string PouvoirDeBase{
			get{ return _pouvoirDeBase;}
			set{_pouvoirDeBase = value;}
		}

		private IEnumerable<PouvoirForceDescriptionToAmeliorationDeControle> _controles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Controles",OtherKey = "PouvoirForceDescriptionId")]
		public IEnumerable <PouvoirForceDescriptionToAmeliorationDeControle> Controles{
			get{
				if( _controles == null ){
					_controles = LoadByForeignKey<PouvoirForceDescriptionToAmeliorationDeControle>(p => p.PouvoirForceDescriptionId, Id);
				}
				return _controles;
			}
			set{
				foreach( PouvoirForceDescriptionToAmeliorationDeControle item in _controles ){
					item.PouvoirForceDescription = null;
				}
				_controles = value;
				foreach( PouvoirForceDescriptionToAmeliorationDeControle item in value ){
					item.PouvoirForceDescription = this;
				}
			}
		}

		private string _ameliorationDePuissance;
		[LargeText]
		[Column(Storage = "AmeliorationDePuissance",Name = "ameliorationdepuissance")]
		public string AmeliorationDePuissance{
			get{ return _ameliorationDePuissance;}
			set{_ameliorationDePuissance = value;}
		}

		private string _ameliorationDeDuree;
		[LargeText]
		[Column(Storage = "AmeliorationDeDuree",Name = "ameliorationdeduree")]
		public string AmeliorationDeDuree{
			get{ return _ameliorationDeDuree;}
			set{_ameliorationDeDuree = value;}
		}

		private string _ameliorationDePortee;
		[LargeText]
		[Column(Storage = "AmeliorationDePortee",Name = "ameliorationdeportee")]
		public string AmeliorationDePortee{
			get{ return _ameliorationDePortee;}
			set{_ameliorationDePortee = value;}
		}

		private string _ameliorationDeAmplitude;
		[LargeText]
		[Column(Storage = "AmeliorationDeAmplitude",Name = "ameliorationdeamplitude")]
		public string AmeliorationDeAmplitude{
			get{ return _ameliorationDeAmplitude;}
			set{_ameliorationDeAmplitude = value;}
		}
	}
	[Table(Schema = "starwars",Name = "pouvoirforceexemplar")]
	public partial class PouvoirForceExemplar : DataExemplaire<PouvoirForceModel> {
	}
}
