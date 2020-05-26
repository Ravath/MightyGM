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
	[Table(Schema = "polaris",Name = "armedistancemodel")]
	[CoreData]
	public partial class ArmeDistanceModel : AbsArmeModel {

		private ArmeDistanceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeDistanceDescription> id = GetModelReferencer<ArmeDistanceDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeDistanceDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeArmeDistance _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeArmeDistance Type{
			get{ return _type;}
			set{_type = value;}
		}

		private int _munitions;
		[Column(Storage = "Munitions",Name = "munitions")]
		public int Munitions{
			get{ return _munitions;}
			set{_munitions = value;}
		}

		private int _coutMunitions;
		[Column(Storage = "CoutMunitions",Name = "coutmunitions")]
		public int CoutMunitions{
			get{ return _coutMunitions;}
			set{_coutMunitions = value;}
		}

		private int _porteePortant;
		[Column(Storage = "PorteePortant",Name = "porteeportant")]
		public int PorteePortant{
			get{ return _porteePortant;}
			set{_porteePortant = value;}
		}

		private int _porteeCourte;
		[Column(Storage = "PorteeCourte",Name = "porteecourte")]
		public int PorteeCourte{
			get{ return _porteeCourte;}
			set{_porteeCourte = value;}
		}

		private int _porteeMoyenne;
		[Column(Storage = "PorteeMoyenne",Name = "porteemoyenne")]
		public int PorteeMoyenne{
			get{ return _porteeMoyenne;}
			set{_porteeMoyenne = value;}
		}

		private int _porteeLongue;
		[Column(Storage = "PorteeLongue",Name = "porteelongue")]
		public int PorteeLongue{
			get{ return _porteeLongue;}
			set{_porteeLongue = value;}
		}

		private int _porteeExtreme;
		[Column(Storage = "PorteeExtreme",Name = "porteeextreme")]
		public int PorteeExtreme{
			get{ return _porteeExtreme;}
			set{_porteeExtreme = value;}
		}


		private IEnumerable < ModeTir > _modeTir;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "ModeTir",OtherKey = "ArmeDistanceModel")]
		public IEnumerable < ModeTir > ModeTir{
			get{
				if( _modeTir == null ){
					_modeTir = LoadFromDataValue<ModeTirFromArmeDistanceModel, ModeTir>();
				}
				return _modeTir;
			}
			set{
				SaveDataValue<ModeTirFromArmeDistanceModel, ModeTir>(_modeTir, value);
			}
		}
		public override void DeleteObject() {
			DeleteDataValue<ModeTirFromArmeDistanceModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "armedistancedescription")]
	public partial class ArmeDistanceDescription : AbsArmeDescription {
	}
	[Table(Schema = "polaris",Name = "armedistanceexemplar")]
	public partial class ArmeDistanceExemplar : AbsArmeExemplar {
	}
}
