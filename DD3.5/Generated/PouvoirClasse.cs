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
	[Table(Schema = "dd35",Name = "pouvoirclassemodel")]
	[CoreData]
	public partial class PouvoirClasseModel : DataModel {

		private PouvoirClasseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirClasseDescription> id = GetModelReferencer<PouvoirClasseDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirClasseDescription();
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

		private int _niveau;
		[Column(Storage = "Niveau",Name = "niveau")]
		public int Niveau{
			get{ return _niveau;}
			set{_niveau = value;}
		}

		private int _classeId;
		[Column(Storage = "ClasseId",Name = "fk_absclassemodel_classe")]
		[HiddenProperty]
		public int ClasseId{
			get{ return _classeId;}
			set{_classeId = value;}
		}

		private AbsClasseModel _classe;
		public AbsClasseModel Classe{
			get {
				if(_classe == null) {
					_classe = LoadById<AbsClasseModel>(ClasseId);
			       }
				return _classe;
			} set {
				if(value == _classe) { return; }
				_classe = value;
				if(_classe != null) {
					_classeId = _classe.Id;
				} else {
					_classeId = 0;
				}
			}
		}
	}
	[Table(Schema = "dd35",Name = "pouvoirclassedescription")]
	public partial class PouvoirClasseDescription : DataDescription<PouvoirClasseModel> {
	}
	[Table(Schema = "dd35",Name = "pouvoirclasseexemplar")]
	public partial class PouvoirClasseExemplar : DataExemplaire<PouvoirClasseModel> {
	}
}
