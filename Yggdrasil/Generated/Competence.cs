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
namespace Yggdrasil.Data {
	[Table(Schema = "yggdrasil",Name = "competencemodel")]
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
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private CategorieCompetence _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieCompetence Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}

		private bool _hasSpecialisations;
		[Column(Storage = "HasSpecialisations",Name = "hasspecialisations")]
		public bool HasSpecialisations{
			get{ return _hasSpecialisations;}
			set{_hasSpecialisations = value;}
		}

		private bool _utilisationInnee;
		[Column(Storage = "UtilisationInnee",Name = "utilisationinnee")]
		public bool UtilisationInnee{
			get{ return _utilisationInnee;}
			set{_utilisationInnee = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "competencedescription")]
	public partial class CompetenceDescription : DataDescription<CompetenceModel> {
	}
	[Table(Schema = "yggdrasil",Name = "competenceexemplar")]
	public partial class CompetenceExemplar : DataExemplaire<CompetenceModel> {

		private int _points;
		[Column(Storage = "Points",Name = "points")]
		public int Points{
			get{ return _points;}
			set{_points = value;}
		}

		private string _specialisationChoisie = "";
		[Column(Storage = "SpecialisationChoisie",Name = "specialisationchoisie")]
		public string SpecialisationChoisie{
			get{ return _specialisationChoisie;}
			set{_specialisationChoisie = value;}
		}
	}
}
