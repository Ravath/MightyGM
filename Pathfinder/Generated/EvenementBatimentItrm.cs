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
	[Table(Schema = "pathfinder",Name = "evenementbatimentitrmmodel")]
	[CoreData]
	public partial class EvenementBatimentItrmModel : AbsOddTableModel {

		private EvenementBatimentItrmDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EvenementBatimentItrmDescription> id = GetModelReferencer<EvenementBatimentItrmDescription>();
					if(id.Count() == 0) {
						_obj = new EvenementBatimentItrmDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _batimentId;
		[Column(Storage = "BatimentId",Name = "fk_batimentitrmmodel_batiment")]
		[HiddenProperty]
		public int BatimentId{
			get{ return _batimentId;}
			set{_batimentId = value;}
		}

		private BatimentItrmModel _batiment;
		public BatimentItrmModel Batiment{
			get{
				if( _batiment == null)
					_batiment = LoadById<BatimentItrmModel>(BatimentId);
				return _batiment;
			} set {
				if(_batiment == value){return;}
				_batiment = value;
				if( value != null)
					BatimentId = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "evenementbatimentitrmdescription")]
	public partial class EvenementBatimentItrmDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "evenementbatimentitrmexemplar")]
	public partial class EvenementBatimentItrmExemplar : AbsOddTableExemplar {
	}
}
