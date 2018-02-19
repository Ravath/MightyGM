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
	[Table(Schema = "pathfinder",Name = "donmodel")]
	[CoreData]
	public partial class DonModel : DataModel {

		private DonDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DonDescription> id = GetModelReferencer<DonDescription>();
					if(id.Count() == 0) {
						_obj = new DonDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeDon _typeDon;
		[Column(Storage = "TypeDon",Name = "typedon")]
		public TypeDon TypeDon{
			get{ return _typeDon;}
			set{_typeDon = value;}
		}

		private int _donRequisId;
		[Column(Storage = "DonRequisId",Name = "fk_donmodel_donrequis")]
		[HiddenProperty]
		public int DonRequisId{
			get{ return _donRequisId;}
			set{_donRequisId = value;}
		}

		private DonModel _donRequis;
		public DonModel DonRequis{
			get {
				if(_donRequis == null) {
					_donRequis = LoadById<DonModel>(DonRequisId);
			       }
				return _donRequis;
			} set {
				if(value == _donRequis) { return; }
				_donRequis = value;
				if(_donRequis != null) {
					_donRequisId = _donRequis.Id;
				} else {
					_donRequisId = 0;
				}
			}
		}

		private IEnumerable<DonModel> _autresDonsRequis;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "AutresDonsRequis",OtherKey = "DonModelAutresDonsRequisId")]
		public IEnumerable <DonModel> AutresDonsRequis{
			get{
				if( _autresDonsRequis == null ){
					_autresDonsRequis = LoadFromJointure<DonModel,DonModelToDonModel_AutresDonsRequis>(false);
				}
				return _autresDonsRequis;
			}
			set{
				SaveToJointure<DonModel, DonModelToDonModel_AutresDonsRequis> (_autresDonsRequis, value,false);
				_autresDonsRequis = value;
			}
		}

		private IEnumerable<DonModel> _donDebloques;
		public IEnumerable <DonModel> DonDebloques{
			get{
				if( _donDebloques == null ){
					_donDebloques = LoadByForeignKey<DonModel>(p => p.DonRequisId, Id);
				}
				return _donDebloques;
			}
			set{
				foreach( DonModel item in _donDebloques ){
					item.DonRequis = null;

				}
				_donDebloques = value;
				foreach( DonModel item in value ){
					item.DonRequis = this;
					item.SaveObject();
				}
			}
		}

		private bool _donMartial;
		[Column(Storage = "DonMartial",Name = "donmartial")]
		public bool DonMartial{
			get{ return _donMartial;}
			set{_donMartial = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<DonModel,DonModelToDonModel_AutresDonsRequis>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "dondescription")]
	public partial class DonDescription : DataDescription<DonModel> {

		private string _conditions = "";
		[LargeText]
		[Column(Storage = "Conditions",Name = "conditions")]
		public string Conditions{
			get{ return _conditions;}
			set{_conditions = value;}
		}

		private string _avantage = "";
		[LargeText]
		[Column(Storage = "Avantage",Name = "avantage")]
		public string Avantage{
			get{ return _avantage;}
			set{_avantage = value;}
		}

		private string _normal = "";
		[LargeText]
		[Column(Storage = "Normal",Name = "normal")]
		public string Normal{
			get{ return _normal;}
			set{_normal = value;}
		}

		private string _special = "";
		[LargeText]
		[Column(Storage = "Special",Name = "special")]
		public string Special{
			get{ return _special;}
			set{_special = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "donexemplar")]
	public partial class DonExemplar : DataExemplaire<DonModel> {
	}
}
