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
	[Table(Schema = "pathfinder",Name = "conflitmodel")]
	[CoreData]
	public partial class ConflitModel : AbsOddTableModel {

		private ConflitDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ConflitDescription> id = GetModelReferencer<ConflitDescription>();
					if(id.Count() == 0) {
						_obj = new ConflitDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "conflitdescription")]
	public partial class ConflitDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "conflitexemplar")]
	public partial class ConflitExemplar : AbsOddTableExemplar {

		private IEnumerable<ActeurConflitModel> _acteurs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Acteurs",OtherKey = "ConflitExemplarId")]
		public IEnumerable <ActeurConflitModel> Acteurs{
			get{
				if( _acteurs == null ){
					_acteurs = LoadFromJointure<ActeurConflitModel,ConflitExemplarToActeurConflitModel_Acteurs>(false);
				}
				return _acteurs;
			}
			set{
				SaveToJointure<ActeurConflitModel, ConflitExemplarToActeurConflitModel_Acteurs> (_acteurs, value,false);
				_acteurs = value;
			}
		}

		private int _origineId;
		[Column(Storage = "OrigineId",Name = "fk_origineconflitmodel_origine")]
		[HiddenProperty]
		public int OrigineId{
			get{ return _origineId;}
			set{_origineId = value;}
		}

		private OrigineConflitModel _origine;
		public OrigineConflitModel Origine{
			get{
				if( _origine == null)
					_origine = LoadById<OrigineConflitModel>(OrigineId);
				return _origine;
			} set {
				if(_origine == value){return;}
				_origine = value;
				if( value != null)
					OrigineId = value.Id;
			}
		}

		private int _resolutionId;
		[Column(Storage = "ResolutionId",Name = "fk_resolutionconflitmodel_resolution")]
		[HiddenProperty]
		public int ResolutionId{
			get{ return _resolutionId;}
			set{_resolutionId = value;}
		}

		private ResolutionConflitModel _resolution;
		public ResolutionConflitModel Resolution{
			get{
				if( _resolution == null)
					_resolution = LoadById<ResolutionConflitModel>(ResolutionId);
				return _resolution;
			} set {
				if(_resolution == value){return;}
				_resolution = value;
				if( value != null)
					ResolutionId = value.Id;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ConflitExemplar,ConflitExemplarToActeurConflitModel_Acteurs>(true);
			base.DeleteObject();
		}
	}
}
