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
	[Table(Schema = "shadowrun5",Name = "complexformmodel")]
	[CoreData]
	public partial class ComplexFormModel : DataModel {

		private ComplexFormDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ComplexFormDescription> id = GetModelReferencer<ComplexFormDescription>();
					if(id.Count() == 0) {
						_obj = new ComplexFormDescription();
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

		private ResonanceTarget _target;
		[Column(Storage = "Target",Name = "target")]
		public ResonanceTarget Target{
			get{ return _target;}
			set{_target = value;}
		}

		private Duration _duration;
		[Column(Storage = "Duration",Name = "duration")]
		public Duration Duration{
			get{ return _duration;}
			set{_duration = value;}
		}

		private int _fV;
		[Column(Storage = "FV",Name = "fv")]
		public int FV{
			get{ return _fV;}
			set{_fV = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "complexformdescription")]
	public partial class ComplexFormDescription : DataDescription<ComplexFormModel> {
	}
	[Table(Schema = "shadowrun5",Name = "complexformexemplar")]
	public partial class ComplexFormExemplar : DataExemplaire<ComplexFormModel> {
	}
}
