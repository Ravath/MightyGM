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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "lancetorpillemodel")]
	[CoreData]
	public partial class LanceTorpilleModel : ObjectModel {

		private LanceTorpilleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<LanceTorpilleDescription> id = GetModelReferencer<LanceTorpilleDescription>();
					if(id.Count() == 0) {
						_obj = new LanceTorpilleDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		[Column(Name="tailletorpille_min", Storage="TailleTorpilleMin")]
		public int TailleTorpilleMin{
			get{
				return TailleTorpille.Min;
			}
			set{
				TailleTorpille.Min = value;
			}
		}

		[Column(Name="tailletorpille_max", Storage="TailleTorpilleMax")]
		public int TailleTorpilleMax{
			get{
				return TailleTorpille.Max;
			}
			set{
				TailleTorpille.Max = value;
			}
		}

		private Range _tailleTorpille = new Range();
		[HiddenProperty]
		public Range TailleTorpille{
			get{
				return _tailleTorpille;
			}
			set{
				_tailleTorpille = value;
			}
		}



		private int _for;
		[Column(Storage = "For",Name = "for")]
		public int For{
			get{ return _for;}
			set{_for = value;}
		}

		private int _init;
		[Column(Storage = "Init",Name = "init")]
		public int Init{
			get{ return _init;}
			set{_init = value;}
		}


		private IEnumerable < ModeTir > _modeTir;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "ModeTir",OtherKey = "LanceTorpilleModel")]
		public IEnumerable < ModeTir > ModeTir{
			get{
				if( _modeTir == null ){
					_modeTir = LoadFromDataValue<ModeTirFromLanceTorpilleModel, ModeTir>();
				}
				return _modeTir;
			}
			set{
				SaveDataValue<ModeTirFromLanceTorpilleModel, ModeTir>(_modeTir, value);
			}
		}
		public override void DeleteObject() {
			DeleteDataValue<ModeTirFromLanceTorpilleModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "lancetorpilledescription")]
	public partial class LanceTorpilleDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "lancetorpilleexemplar")]
	public partial class LanceTorpilleExemplar : ObjectExemplar {
	}
}
