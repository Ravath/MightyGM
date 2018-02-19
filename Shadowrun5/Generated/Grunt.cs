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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "gruntmodel")]
	[CoreData]
	public partial class GruntModel : AbsGruntModel {

		private GruntDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<GruntDescription> id = GetModelReferencer<GruntDescription>();
					if(id.Count() == 0) {
						_obj = new GruntDescription();
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

		private int _lieutenantId;
		[Column(Storage = "LieutenantId",Name = "fk_lieutenantmodel_lieutenant")]
		[HiddenProperty]
		public int LieutenantId{
			get{ return _lieutenantId;}
			set{_lieutenantId = value;}
		}

		private LieutenantModel _lieutenant;
		public LieutenantModel Lieutenant{
			get {
				if(_lieutenant == null) {
					_lieutenant = LoadById<LieutenantModel>(LieutenantId);
			       }
				return _lieutenant;
			} set {
				if(value == _lieutenant) { return; }
				_lieutenant = value;
				if(_lieutenant != null) {
					_lieutenantId = _lieutenant.Id;
				} else {
					_lieutenantId = 0;
				}
			}
		}
	}
	[Table(Schema = "shadowrun5",Name = "gruntdescription")]
	public partial class GruntDescription : AbsGruntDescription {
	}
	[Table(Schema = "shadowrun5",Name = "gruntexemplar")]
	public partial class GruntExemplar : AbsGruntExemplar {
	}
}
