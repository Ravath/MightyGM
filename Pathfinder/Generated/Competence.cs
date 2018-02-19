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
	[Table(Schema = "pathfinder",Name = "competencemodel")]
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

		private Caracteristique _caracteristique;
		[Column(Storage = "Caracteristique",Name = "caracteristique")]
		public Caracteristique Caracteristique{
			get{ return _caracteristique;}
			set{_caracteristique = value;}
		}

		private bool _sansFormation;
		[Column(Storage = "SansFormation",Name = "sansformation")]
		public bool SansFormation{
			get{ return _sansFormation;}
			set{_sansFormation = value;}
		}

		private bool _malusArmure;
		[Column(Storage = "MalusArmure",Name = "malusarmure")]
		public bool MalusArmure{
			get{ return _malusArmure;}
			set{_malusArmure = value;}
		}

		private IEnumerable<SousTypeModel> _sousTypes;
		public IEnumerable <SousTypeModel> SousTypes{
			get{
				if( _sousTypes == null ){
					_sousTypes = LoadByForeignKey<SousTypeModel>(p => p.CompetenceId, Id);
				}
				return _sousTypes;
			}
			set{
				foreach( SousTypeModel item in _sousTypes ){
					item.Competence = null;

				}
				_sousTypes = value;
				foreach( SousTypeModel item in value ){
					item.Competence = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "competencedescription")]
	public partial class CompetenceDescription : DataDescription<CompetenceModel> {

		private string _testCompetence = "";
		[LargeText]
		[Column(Storage = "TestCompetence",Name = "testcompetence")]
		public string TestCompetence{
			get{ return _testCompetence;}
			set{_testCompetence = value;}
		}

		private string _action = "";
		[LargeText]
		[Column(Storage = "Action",Name = "action")]
		public string Action{
			get{ return _action;}
			set{_action = value;}
		}

		private string _nouvellesTentatives = "";
		[LargeText]
		[Column(Storage = "NouvellesTentatives",Name = "nouvellestentatives")]
		public string NouvellesTentatives{
			get{ return _nouvellesTentatives;}
			set{_nouvellesTentatives = value;}
		}

		private string _special = "";
		[LargeText]
		[Column(Storage = "Special",Name = "special")]
		public string Special{
			get{ return _special;}
			set{_special = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "competenceexemplar")]
	public partial class CompetenceExemplar : DataExemplaire<CompetenceModel> {

		private int _specialiteId;
		[Column(Storage = "SpecialiteId",Name = "fk_soustypemodel_specialite")]
		[HiddenProperty]
		public int SpecialiteId{
			get{ return _specialiteId;}
			set{_specialiteId = value;}
		}

		private SousTypeModel _specialite;
		public SousTypeModel Specialite{
			get{
				if( _specialite == null)
					_specialite = LoadById<SousTypeModel>(SpecialiteId);
				return _specialite;
			} set {
				if(_specialite == value){return;}
				_specialite = value;
				if( value != null)
					SpecialiteId = value.Id;
			}
		}

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
