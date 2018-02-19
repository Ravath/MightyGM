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
	[Table(Schema = "shadowrun5",Name = "weaknessmodel")]
	[CoreData]
	public partial class WeaknessModel : DataModel {

		private WeaknessDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<WeaknessDescription> id = GetModelReferencer<WeaknessDescription>();
					if(id.Count() == 0) {
						_obj = new WeaknessDescription();
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
	}
	[Table(Schema = "shadowrun5",Name = "weaknessdescription")]
	public partial class WeaknessDescription : DataDescription<WeaknessModel> {
	}
	[Table(Schema = "shadowrun5",Name = "weaknessexemplar")]
	public partial class WeaknessExemplar : DataExemplaire<WeaknessModel> {

		private string _tag;
		[Column(Storage = "Tag",Name = "tag")]
		public string Tag{
			get{ return _tag;}
			set{_tag = value;}
		}
	}
}
