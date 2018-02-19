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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "skillmodel")]
	[CoreData]
	public partial class SkillModel : DataModel {

		private SkillDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SkillDescription> id = GetModelReferencer<SkillDescription>();
					if(id.Count() == 0) {
						_obj = new SkillDescription();
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

		private SkillGroup? _skillGroup;
		[Column(Storage = "SkillGroup",Name = "skillgroup")]
		public SkillGroup? SkillGroup{
			get{ return _skillGroup;}
			set{_skillGroup = value;}
		}

		private Attribut _caracteristic;
		[Column(Storage = "Caracteristic",Name = "caracteristic")]
		public Attribut Caracteristic{
			get{ return _caracteristic;}
			set{_caracteristic = value;}
		}

		private SkillCategory _type;
		[Column(Storage = "Type",Name = "type")]
		public SkillCategory Type{
			get{ return _type;}
			set{_type = value;}
		}

		private bool _defaultUse;
		[Column(Storage = "DefaultUse",Name = "defaultuse")]
		public bool DefaultUse{
			get{ return _defaultUse;}
			set{_defaultUse = value;}
		}


		private IEnumerable < string > _specialisations;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Specialisations",OtherKey = "SkillModel")]
		public IEnumerable < string > Specialisations{
			get{
				if( _specialisations == null ){
					_specialisations = LoadFromDataValue<SpecialisationsFromSkillModel, string>();
				}
				return _specialisations;
			}
			set{
				SaveDataValue<SpecialisationsFromSkillModel, string>(_specialisations, value);
			}
		}
		public override void DeleteObject() {
			DeleteDataValue<SpecialisationsFromSkillModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "shadowrun5",Name = "skilldescription")]
	public partial class SkillDescription : DataDescription<SkillModel> {
	}
	[Table(Schema = "shadowrun5",Name = "skillexemplar")]
	public partial class SkillExemplar : DataExemplaire<SkillModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
