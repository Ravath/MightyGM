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
	[Table(Schema = "dd35",Name = "competencemodel")]
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

		private bool _innee;
		[Column(Storage = "Innee",Name = "innee")]
		public bool Innee{
			get{ return _innee;}
			set{_innee = value;}
		}

		private MalusArmure _malusArmure;
		[Column(Storage = "MalusArmure",Name = "malusarmure")]
		public MalusArmure MalusArmure{
			get{ return _malusArmure;}
			set{_malusArmure = value;}
		}

		private bool _generale;
		[Column(Storage = "Generale",Name = "generale")]
		public bool Generale{
			get{ return _generale;}
			set{_generale = value;}
		}
	}
	[Table(Schema = "dd35",Name = "competencedescription")]
	public partial class CompetenceDescription : DataDescription<CompetenceModel> {
	}
	[Table(Schema = "dd35",Name = "competenceexemplar")]
	public partial class CompetenceExemplar : DataExemplaire<CompetenceModel> {

		private string _specialite = "";
		[Column(Storage = "Specialite",Name = "specialite")]
		public string Specialite{
			get{ return _specialite;}
			set{_specialite = value;}
		}

		private int _rang;
		[Column(Storage = "rang",Name = "rang")]
		public int rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
