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
	[Table(Schema = "yggdrasil",Name = "archetypemodel")]
	[CoreData]
	public partial class ArchetypeModel : DataModel {

		private ArchetypeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArchetypeDescription> id = GetModelReferencer<ArchetypeDescription>();
					if(id.Count() == 0) {
						_obj = new ArchetypeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private ClasseArchetype _classe;
		[Column(Storage = "Classe",Name = "classe")]
		public ClasseArchetype Classe{
			get{ return _classe;}
			set{_classe = value;}
		}

		private IEnumerable<CompetenceModel> _competencesPrivilegiees;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "CompetencesPrivilegiees",OtherKey = "ArchetypeModelId")]
		public IEnumerable <CompetenceModel> CompetencesPrivilegiees{
			get{
				if( _competencesPrivilegiees == null ){
					_competencesPrivilegiees = LoadFromJointure<CompetenceModel,ArchetypeModelToCompetenceModel_CompetencesPrivilegiees>(false);
				}
				return _competencesPrivilegiees;
			}
			set{
				SaveToJointure<CompetenceModel, ArchetypeModelToCompetenceModel_CompetencesPrivilegiees> (_competencesPrivilegiees, value,false);
				_competencesPrivilegiees = value;
			}
		}

		private bool _competenceMagique;
		[Column(Storage = "CompetenceMagique",Name = "competencemagique")]
		public bool CompetenceMagique{
			get{ return _competenceMagique;}
			set{_competenceMagique = value;}
		}

		private int _competencesMartiales;
		[Column(Storage = "CompetencesMartiales",Name = "competencesmartiales")]
		public int CompetencesMartiales{
			get{ return _competencesMartiales;}
			set{_competencesMartiales = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<ArchetypeModel,ArchetypeModelToCompetenceModel_CompetencesPrivilegiees>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "yggdrasil",Name = "archetypedescription")]
	public partial class ArchetypeDescription : DataDescription<ArchetypeModel> {
	}
	[Table(Schema = "yggdrasil",Name = "archetypeexemplar")]
	public partial class ArchetypeExemplar : DataExemplaire<ArchetypeModel> {

		private IEnumerable<CompetenceModel> _competencesChoisies;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "CompetencesChoisies",OtherKey = "ArchetypeExemplarId")]
		public IEnumerable <CompetenceModel> CompetencesChoisies{
			get{
				if( _competencesChoisies == null ){
					_competencesChoisies = LoadFromJointure<CompetenceModel,ArchetypeExemplarToCompetenceModel_CompetencesChoisies>(false);
				}
				return _competencesChoisies;
			}
			set{
				SaveToJointure<CompetenceModel, ArchetypeExemplarToCompetenceModel_CompetencesChoisies> (_competencesChoisies, value,false);
				_competencesChoisies = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArchetypeExemplar,ArchetypeExemplarToCompetenceModel_CompetencesChoisies>(true);
			base.DeleteObject();
		}
	}
}
