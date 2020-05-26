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
	[Table(Schema = "polaris",Name = "absarmemodel")]
	public abstract partial class AbsArmeModel : ObjectModel {

		private string _degats = "";
		[Column(Storage = "Degats",Name = "degats")]
		public string Degats{
			get{ return _degats;}
			set{_degats = value;}
		}

		private int _penalite;
		[Column(Storage = "Penalite",Name = "penalite")]
		public int Penalite{
			get{ return _penalite;}
			set{_penalite = value;}
		}

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int _init;
		[Column(Storage = "Init",Name = "init")]
		public int Init{
			get{ return _init;}
			set{_init = value;}
		}

		private IEnumerable<SpecialArmeExemplar> _special;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Special",OtherKey = "AbsArmeModelId")]
		public IEnumerable <SpecialArmeExemplar> Special{
			get{
				if( _special == null ){
					_special = LoadFromJointure<SpecialArmeExemplar,AbsArmeModelToSpecialArmeExemplar_Special>(false);
				}
				return _special;
			}
			set{
				SaveToJointure<SpecialArmeExemplar, AbsArmeModelToSpecialArmeExemplar_Special> (_special, value,false);
				_special = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AbsArmeModel,AbsArmeModelToSpecialArmeExemplar_Special>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "absarmedescription")]
	public abstract partial class AbsArmeDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "absarmeexemplar")]
	public abstract partial class AbsArmeExemplar : ObjectExemplar {
	}
}
