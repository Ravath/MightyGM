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

		private IEnumerable<PlayerConditionExemplar> _requis;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Requis",OtherKey = "ProfessionModelId")]
		public IEnumerable <PlayerConditionExemplar> Requis{
			get{
				if( _requis == null ){
					_requis = LoadFromJointure<PlayerConditionExemplar,ProfessionModelToPlayerConditionExemplar_Requis>(false);
				}
				return _requis;
			}
			set{
				SaveToJointure<PlayerConditionExemplar, ProfessionModelToPlayerConditionExemplar_Requis> (_requis, value,false);
				_requis = value;
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

		private int _contacts_num;
		[Column(Storage = "Contacts_num",Name = "contacts_num")]
		public int Contacts_num{
			get{ return _contacts_num;}
			set{_contacts_num = value;}
		}

		private int _contacts_den;
		[Column(Storage = "Contacts_den",Name = "contacts_den")]
		public int Contacts_den{
			get{ return _contacts_den;}
			set{_contacts_den = value;}
		}

		private int _allies_num;
		[Column(Storage = "Allies_num",Name = "allies_num")]
		public int Allies_num{
			get{ return _allies_num;}
			set{_allies_num = value;}
		}

		private int _allies_den;
		[Column(Storage = "Allies_den",Name = "allies_den")]
		public int Allies_den{
			get{ return _allies_den;}
			set{_allies_den = value;}
		}

		private int _opposants_num;
		[Column(Storage = "Opposants_num",Name = "opposants_num")]
		public int Opposants_num{
			get{ return _opposants_num;}
			set{_opposants_num = value;}
		}

		private int _opposants_den;
		[Column(Storage = "Opposants_den",Name = "opposants_den")]
		public int Opposants_den{
			get{ return _opposants_den;}
			set{_opposants_den = value;}
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

		private IEnumerable<AvantageProAleatoireModel> _avantagesProAleatoire;
		public IEnumerable <AvantageProAleatoireModel> AvantagesProAleatoire{
			get{
				if( _avantagesProAleatoire == null ){
					_avantagesProAleatoire = LoadByForeignKey<AvantageProAleatoireModel>(p => p.ProfessionId, Id);
				}
				return _avantagesProAleatoire;
			}
			set{
				foreach( AvantageProAleatoireModel item in _avantagesProAleatoire ){
					item.Profession = null;

				}
				_avantagesProAleatoire = value;
				foreach( AvantageProAleatoireModel item in value ){
					item.Profession = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<Titre> _titres;
		public IEnumerable <Titre> Titres{
			get{
				if( _titres == null ){
					_titres = LoadByForeignKey<Titre>(p => p.ProfessionId, Id);
				}
				return _titres;
			}
			set{
				foreach( Titre item in _titres ){
					item.Profession = null;

				}
				_titres = value;
				foreach( Titre item in value ){
					item.Profession = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<CategorieMaterielModel> _materielAccessible;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "MaterielAccessible",OtherKey = "ProfessionModelId")]
		public IEnumerable <CategorieMaterielModel> MaterielAccessible{
			get{
				if( _materielAccessible == null ){
					_materielAccessible = LoadFromJointure<CategorieMaterielModel,ProfessionModelToCategorieMaterielModel_MaterielAccessible>(false);
				}
				return _materielAccessible;
			}
			set{
				SaveToJointure<CategorieMaterielModel, ProfessionModelToCategorieMaterielModel_MaterielAccessible> (_materielAccessible, value,false);
				_materielAccessible = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ProfessionModel,ProfessionModelToPlayerConditionExemplar_Requis>(true);
			DeleteJoins<ProfessionModel,ProfessionModelToCompetenceModel_Competences>(true);
			DeleteJoins<ProfessionModel,ProfessionModelToAvantageProModel_AvantagesPro>(true);
			DeleteJoins<ProfessionModel,ProfessionModelToCategorieMaterielModel_MaterielAccessible>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "professiondescription")]
	public partial class ProfessionDescription : DataDescription<ProfessionModel> {

		private string _origineGeographique = "";
		[LargeText]
		[Column(Storage = "OrigineGeographique",Name = "originegeographique")]
		public string OrigineGeographique{
			get{ return _origineGeographique;}
			set{_origineGeographique = value;}
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
