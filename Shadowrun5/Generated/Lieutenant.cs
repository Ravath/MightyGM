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
	[Table(Schema = "shadowrun5",Name = "lieutenantmodel")]
	[CoreData]
	public partial class LieutenantModel : AbsGruntModel {

		private LieutenantDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<LieutenantDescription> id = GetModelReferencer<LieutenantDescription>();
					if(id.Count() == 0) {
						_obj = new LieutenantDescription();
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

		private int _gruntId;
		[Column(Storage = "GruntId",Name = "fk_gruntmodel_grunt")]
		[HiddenProperty]
		public int GruntId{
			get{ return _gruntId;}
			set{_gruntId = value;}
		}

		private GruntModel _grunt;
		public GruntModel Grunt{
			get {
				if(_grunt == null) {
					_grunt = LoadById<GruntModel>(GruntId);
			       }
				return _grunt;
			} set {
				if(value == _grunt) { return; }
				_grunt = value;
				if(_grunt != null) {
					_gruntId = _grunt.Id;
				} else {
					_gruntId = 0;
				}
			}
		}
	}
	[Table(Schema = "shadowrun5",Name = "lieutenantdescription")]
	public partial class LieutenantDescription : AbsGruntDescription {
	}
	[Table(Schema = "shadowrun5",Name = "lieutenantexemplar")]
	public partial class LieutenantExemplar : AbsGruntExemplar {
	}
}
