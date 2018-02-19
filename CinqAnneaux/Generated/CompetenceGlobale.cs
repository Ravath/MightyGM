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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "competenceglobalemodel")]
	[CoreData]
	public partial class CompetenceGlobaleModel : DataModel {

		private CompetenceGlobaleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CompetenceGlobaleDescription> id = GetModelReferencer<CompetenceGlobaleDescription>();
					if(id.Count() == 0) {
						_obj = new CompetenceGlobaleDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private GroupeCompetence _groupe;
		[Column(Storage = "Groupe",Name = "groupe")]
		public GroupeCompetence Groupe{
			get{ return _groupe;}
			set{_groupe = value;}
		}

		private TraitCompetence _traitAssocie;
		[Column(Storage = "TraitAssocie",Name = "traitassocie")]
		public TraitCompetence TraitAssocie{
			get{ return _traitAssocie;}
			set{_traitAssocie = value;}
		}

		private IEnumerable<SousTypeGlobal> _specialisations;
		public IEnumerable <SousTypeGlobal> Specialisations{
			get{
				if( _specialisations == null ){
					_specialisations = LoadByForeignKey<SousTypeGlobal>(p => p.CompetenceId, Id);
				}
				return _specialisations;
			}
			set{
				foreach( SousTypeGlobal item in _specialisations ){
					item.Competence = null;

				}
				_specialisations = value;
				foreach( SousTypeGlobal item in value ){
					item.Competence = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<CompetenceModel> _specifiques;
		public IEnumerable <CompetenceModel> Specifiques{
			get{
				if( _specifiques == null ){
					_specifiques = LoadByForeignKey<CompetenceModel>(p => p.GlobalId, Id);
				}
				return _specifiques;
			}
			set{
				foreach( CompetenceModel item in _specifiques ){
					item.Global = null;

				}
				_specifiques = value;
				foreach( CompetenceModel item in value ){
					item.Global = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "competenceglobaledescription")]
	public partial class CompetenceGlobaleDescription : DataDescription<CompetenceGlobaleModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "competenceglobaleexemplar")]
	public partial class CompetenceGlobaleExemplar : DataExemplaire<CompetenceGlobaleModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}

		private int _specialisationId;
		[Column(Storage = "SpecialisationId",Name = "fk_soustypeglobal_specialisation")]
		[HiddenProperty]
		public int SpecialisationId{
			get{ return _specialisationId;}
			set{_specialisationId = value;}
		}

		private SousTypeGlobal _specialisation;
		public SousTypeGlobal Specialisation{
			get{
				if( _specialisation == null)
					_specialisation = LoadById<SousTypeGlobal>(SpecialisationId);
				return _specialisation;
			} set {
				if(_specialisation == value){return;}
				_specialisation = value;
				if( value != null)
					SpecialisationId = value.Id;
			}
		}
	}
}
