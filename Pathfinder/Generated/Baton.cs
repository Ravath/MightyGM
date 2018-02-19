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
	[Table(Schema = "pathfinder",Name = "batonmodel")]
	[CoreData]
	public partial class BatonModel : ObjectMagiqueModel {

		private BatonDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<BatonDescription> id = GetModelReferencer<BatonDescription>();
					if(id.Count() == 0) {
						_obj = new BatonDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<SortBaton> _sorts;
		public IEnumerable <SortBaton> Sorts{
			get{
				if( _sorts == null ){
					_sorts = LoadByForeignKey<SortBaton>(p => p.BatonId, Id);
				}
				return _sorts;
			}
			set{
				foreach( SortBaton item in _sorts ){
					item.Baton = null;

				}
				_sorts = value;
				foreach( SortBaton item in value ){
					item.Baton = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "batondescription")]
	public partial class BatonDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "pathfinder",Name = "batonexemplar")]
	public partial class BatonExemplar : ObjectMagiqueExemplar {

		private int _chargesRestantes;
		[Column(Storage = "ChargesRestantes",Name = "chargesrestantes")]
		public int ChargesRestantes{
			get{ return _chargesRestantes;}
			set{_chargesRestantes = value;}
		}
	}
}
