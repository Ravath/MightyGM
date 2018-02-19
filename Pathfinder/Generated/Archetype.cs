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
	[Table(Schema = "pathfinder",Name = "archetypemodel")]
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

		private int _modFP;
		[Column(Storage = "ModFP",Name = "modfp")]
		public int ModFP{
			get{ return _modFP;}
			set{_modFP = value;}
		}

		private IEnumerable<ParticulariteExemplar> _particularites;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Particularites",OtherKey = "ArchetypeModelId")]
		public IEnumerable <ParticulariteExemplar> Particularites{
			get{
				if( _particularites == null ){
					_particularites = LoadFromJointure<ParticulariteExemplar,ArchetypeModelToParticulariteExemplar_Particularites>(false);
				}
				return _particularites;
			}
			set{
				SaveToJointure<ParticulariteExemplar, ArchetypeModelToParticulariteExemplar_Particularites> (_particularites, value,false);
				_particularites = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArchetypeModel,ArchetypeModelToParticulariteExemplar_Particularites>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "archetypedescription")]
	public partial class ArchetypeDescription : DataDescription<ArchetypeModel> {
	}
	[Table(Schema = "pathfinder",Name = "archetypeexemplar")]
	public partial class ArchetypeExemplar : DataExemplaire<ArchetypeModel> {
	}
}
