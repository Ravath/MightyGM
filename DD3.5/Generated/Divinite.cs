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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "divinitemodel")]
	[CoreData]
	public partial class DiviniteModel : DataModel {

		private DiviniteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DiviniteDescription> id = GetModelReferencer<DiviniteDescription>();
					if(id.Count() == 0) {
						_obj = new DiviniteDescription();
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

		private AlignementLoi _alignementLoi;
		[Column(Storage = "AlignementLoi",Name = "alignementloi")]
		public AlignementLoi AlignementLoi{
			get{ return _alignementLoi;}
			set{_alignementLoi = value;}
		}

		private AlignementBien _alignementBien;
		[Column(Storage = "AlignementBien",Name = "alignementbien")]
		public AlignementBien AlignementBien{
			get{ return _alignementBien;}
			set{_alignementBien = value;}
		}

		private IEnumerable<DomaineModel> _domaines;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Domaines",OtherKey = "DiviniteModelId")]
		public IEnumerable <DomaineModel> Domaines{
			get{
				if( _domaines == null ){
					_domaines = LoadFromJointure<DomaineModel,DiviniteModelToDomaineModel_Domaines>(false);
				}
				return _domaines;
			}
			set{
				SaveToJointure<DomaineModel, DiviniteModelToDomaineModel_Domaines> (_domaines, value,false);
				_domaines = value;
			}
		}

		private int _armeDePredilectionId;
		[Column(Storage = "ArmeDePredilectionId",Name = "fk_armemodel_armedepredilection")]
		[HiddenProperty]
		public int ArmeDePredilectionId{
			get{ return _armeDePredilectionId;}
			set{_armeDePredilectionId = value;}
		}

		private ArmeModel _armeDePredilection;
		public ArmeModel ArmeDePredilection{
			get{
				if( _armeDePredilection == null)
					_armeDePredilection = LoadById<ArmeModel>(ArmeDePredilectionId);
				return _armeDePredilection;
			} set {
				if(_armeDePredilection == value){return;}
				_armeDePredilection = value;
				if( value != null)
					ArmeDePredilectionId = value.Id;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<DiviniteModel,DiviniteModelToDomaineModel_Domaines>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "divinitedescription")]
	public partial class DiviniteDescription : DataDescription<DiviniteModel> {

		private string _clerge = "";
		[LargeText]
		[Column(Storage = "Clerge",Name = "clerge")]
		public string Clerge{
			get{ return _clerge;}
			set{_clerge = value;}
		}
	}
	[Table(Schema = "dd35",Name = "diviniteexemplar")]
	public partial class DiviniteExemplar : DataExemplaire<DiviniteModel> {
	}
}
