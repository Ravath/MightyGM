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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "competencemodel")]
	[CoreData]
	public partial class CompetenceModel : DataModel {

		private CompetenceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CompetenceDescription> id = GetModelReferencer<CompetenceDescription>();
					if(id.Count() == 0) {
						_obj = new CompetenceDescription();
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

		private Caracteristique _caracteristique;
		[Column(Storage = "Caracteristique",Name = "caracteristique")]
		public Caracteristique Caracteristique{
			get{ return _caracteristique;}
			set{_caracteristique = value;}
		}

		private TypeCompetence _typeCompetence;
		[Column(Storage = "TypeCompetence",Name = "typecompetence")]
		public TypeCompetence TypeCompetence{
			get{ return _typeCompetence;}
			set{_typeCompetence = value;}
		}
	}
	[Table(Schema = "starwars",Name = "competencedescription")]
	public partial class CompetenceDescription : DataDescription<CompetenceModel> {


		private IEnumerable < string > _exempleUtilisation;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "ExempleUtilisation",OtherKey = "CompetenceDescription")]
		public IEnumerable < string > ExempleUtilisation{
			get{
				if( _exempleUtilisation == null ){
					_exempleUtilisation = LoadFromDataValue<ExempleUtilisationFromCompetenceDescription, string>();
				}
				return _exempleUtilisation;
			}
			set{
				SaveDataValue<ExempleUtilisationFromCompetenceDescription, string>(_exempleUtilisation, value);
			}
		}

		private string _constitutionPool = "";
		[LargeText]
		[Column(Storage = "ConstitutionPool",Name = "constitutionpool")]
		public string ConstitutionPool{
			get{ return _constitutionPool;}
			set{_constitutionPool = value;}
		}

		private string _utilisationSucces = "";
		[LargeText]
		[Column(Storage = "UtilisationSucces",Name = "utilisationsucces")]
		public string UtilisationSucces{
			get{ return _utilisationSucces;}
			set{_utilisationSucces = value;}
		}

		private string _utilisationAvantages = "";
		[LargeText]
		[Column(Storage = "UtilisationAvantages",Name = "utilisationavantages")]
		public string UtilisationAvantages{
			get{ return _utilisationAvantages;}
			set{_utilisationAvantages = value;}
		}

		private string _utilisationMenaces = "";
		[LargeText]
		[Column(Storage = "UtilisationMenaces",Name = "utilisationmenaces")]
		public string UtilisationMenaces{
			get{ return _utilisationMenaces;}
			set{_utilisationMenaces = value;}
		}

		private string _utilisationEchecs = "";
		[LargeText]
		[Column(Storage = "UtilisationEchecs",Name = "utilisationechecs")]
		public string UtilisationEchecs{
			get{ return _utilisationEchecs;}
			set{_utilisationEchecs = value;}
		}

		private string _utilisationTriomphes = "";
		[LargeText]
		[Column(Storage = "UtilisationTriomphes",Name = "utilisationtriomphes")]
		public string UtilisationTriomphes{
			get{ return _utilisationTriomphes;}
			set{_utilisationTriomphes = value;}
		}

		private string _utilisationDesastres = "";
		[LargeText]
		[Column(Storage = "UtilisationDesastres",Name = "utilisationdesastres")]
		public string UtilisationDesastres{
			get{ return _utilisationDesastres;}
			set{_utilisationDesastres = value;}
		}
		public override void DeleteObject() {
			DeleteDataValue<ExempleUtilisationFromCompetenceDescription>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "starwars",Name = "competenceexemplar")]
	public partial class CompetenceExemplar : DataExemplaire<CompetenceModel> {

		private int _maitrise;
		[Column(Storage = "Maitrise",Name = "maitrise")]
		public int Maitrise{
			get{ return _maitrise;}
			set{_maitrise = value;}
		}
	}
}
