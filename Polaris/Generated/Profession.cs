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
	[Table(Schema = "polaris",Name = "professionmodel")]
	[CoreData]
	public partial class ProfessionModel : DataModel {

		private ProfessionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ProfessionDescription> id = GetModelReferencer<ProfessionDescription>();
					if(id.Count() == 0) {
						_obj = new ProfessionDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<CompetenceModel> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "ProfessionModelId")]
		public IEnumerable <CompetenceModel> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceModel,ProfessionModelToCompetenceModel_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceModel, ProfessionModelToCompetenceModel_Competences> (_competences, value,false);
				_competences = value;
			}
		}

		private int _contacts;
		[Column(Storage = "Contacts",Name = "contacts")]
		public int Contacts{
			get{ return _contacts;}
			set{_contacts = value;}
		}

		private int _allies;
		[Column(Storage = "Allies",Name = "allies")]
		public int Allies{
			get{ return _allies;}
			set{_allies = value;}
		}

		private int _opposants;
		[Column(Storage = "Opposants",Name = "opposants")]
		public int Opposants{
			get{ return _opposants;}
			set{_opposants = value;}
		}

		private int _ratiosEnnemi;
		[Column(Storage = "RatiosEnnemi",Name = "ratiosennemi")]
		public int RatiosEnnemi{
			get{ return _ratiosEnnemi;}
			set{_ratiosEnnemi = value;}
		}

		private IEnumerable<AvantageProModel> _avantagesPro;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "AvantagesPro",OtherKey = "ProfessionModelId")]
		public IEnumerable <AvantageProModel> AvantagesPro{
			get{
				if( _avantagesPro == null ){
					_avantagesPro = LoadFromJointure<AvantageProModel,ProfessionModelToAvantageProModel_AvantagesPro>(false);
				}
				return _avantagesPro;
			}
			set{
				SaveToJointure<AvantageProModel, ProfessionModelToAvantageProModel_AvantagesPro> (_avantagesPro, value,false);
				_avantagesPro = value;
			}
		}

		private IEnumerable<Titre> _titres;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Titres",OtherKey = "ProfessionModelId")]
		public IEnumerable <Titre> Titres{
			get{
				if( _titres == null ){
					_titres = LoadFromJointure<Titre,ProfessionModelToTitre_Titres>(false);
				}
				return _titres;
			}
			set{
				SaveToJointure<Titre, ProfessionModelToTitre_Titres> (_titres, value,false);
				_titres = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ProfessionModel,ProfessionModelToCompetenceModel_Competences>(true);
			DeleteJoins<ProfessionModel,ProfessionModelToAvantageProModel_AvantagesPro>(true);
			DeleteJoins<ProfessionModel,ProfessionModelToTitre_Titres>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "professiondescription")]
	public partial class ProfessionDescription : DataDescription<ProfessionModel> {

		private string _origineGeographque = "";
		[LargeText]
		[Column(Storage = "OrigineGeographque",Name = "originegeographque")]
		public string OrigineGeographque{
			get{ return _origineGeographque;}
			set{_origineGeographque = value;}
		}
	}
	[Table(Schema = "polaris",Name = "professionexemplar")]
	public partial class ProfessionExemplar : DataExemplaire<ProfessionModel> {

		private int _experience;
		[Column(Storage = "Experience",Name = "experience")]
		public int Experience{
			get{ return _experience;}
			set{_experience = value;}
		}
	}
}
