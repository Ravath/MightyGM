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
	[Table(Schema = "pathfinder",Name = "sallebatimentitrmmodel")]
	[CoreData]
	public partial class SalleBatimentItrmModel : LucratifItrmModel {

		private SalleBatimentItrmDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SalleBatimentItrmDescription> id = GetModelReferencer<SalleBatimentItrmDescription>();
					if(id.Count() == 0) {
						_obj = new SalleBatimentItrmDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _extension;
		[Column(Storage = "Extension",Name = "extension")]
		public bool Extension{
			get{ return _extension;}
			set{_extension = value;}
		}

		private IEnumerable<SalleBatimentItrmModel> _amelDe;
		public IEnumerable <SalleBatimentItrmModel> AmelDe{
			get{
				if( _amelDe == null ){
					_amelDe = LoadFromJointure<SalleBatimentItrmModel,SalleBatimentItrmModelAmelEnToSalleBatimentItrmModelAmelDe>(true);
				}
				return _amelDe;
			}
			set{
				SaveToJointure<SalleBatimentItrmModel, SalleBatimentItrmModelAmelEnToSalleBatimentItrmModelAmelDe> (_amelDe, value,true);
				_amelDe = value;
			}
		}

		private IEnumerable<SalleBatimentItrmModel> _amelEn;
		public IEnumerable <SalleBatimentItrmModel> AmelEn{
			get{
				if( _amelEn == null ){
					_amelEn = LoadFromJointure<SalleBatimentItrmModel,SalleBatimentItrmModelAmelEnToSalleBatimentItrmModelAmelDe>(false);
				}
				return _amelEn;
			}
			set{
				SaveToJointure<SalleBatimentItrmModel, SalleBatimentItrmModelAmelEnToSalleBatimentItrmModelAmelDe> (_amelEn, value,false);
				_amelEn = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<SalleBatimentItrmModel,SalleBatimentItrmModelAmelDeToSalleBatimentItrmModelAmelEn>(false);
			DeleteJoins<SalleBatimentItrmModel,SalleBatimentItrmModelAmelDeToSalleBatimentItrmModelAmelEn>(true);
			DeleteJoins<SalleBatimentItrmModel,SalleBatimentItrmModelAmelEnToSalleBatimentItrmModelAmelDe>(true);
			DeleteJoins<SalleBatimentItrmModel,SalleBatimentItrmModelAmelEnToSalleBatimentItrmModelAmelDe>(false);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "sallebatimentitrmdescription")]
	public partial class SalleBatimentItrmDescription : LucratifItrmDescription {
	}
	[Table(Schema = "pathfinder",Name = "sallebatimentitrmexemplar")]
	public partial class SalleBatimentItrmExemplar : LucratifItrmExemplar {

		private int _nbr;
		[Column(Storage = "Nbr",Name = "nbr")]
		public int Nbr{
			get{ return _nbr;}
			set{_nbr = value;}
		}
	}
}
