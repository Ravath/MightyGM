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
	[Table(Schema = "polaris",Name = "archetypemodel")]
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

		private int _base;
		[Column(Storage = "Base",Name = "base")]
		public int Base{
			get{ return _base;}
			set{_base = value;}
		}

		private int _genetique;
		[Column(Storage = "Genetique",Name = "genetique")]
		public int Genetique{
			get{ return _genetique;}
			set{_genetique = value;}
		}

		private int _special;
		[Column(Storage = "Special",Name = "special")]
		public int Special{
			get{ return _special;}
			set{_special = value;}
		}

		private int _experience;
		[Column(Storage = "Experience",Name = "experience")]
		public int Experience{
			get{ return _experience;}
			set{_experience = value;}
		}

		private int _avantages;
		[Column(Storage = "Avantages",Name = "avantages")]
		public int Avantages{
			get{ return _avantages;}
			set{_avantages = value;}
		}

		private int _desavantages;
		[Column(Storage = "Desavantages",Name = "desavantages")]
		public int Desavantages{
			get{ return _desavantages;}
			set{_desavantages = value;}
		}
	}
	[Table(Schema = "polaris",Name = "archetypedescription")]
	public partial class ArchetypeDescription : DataDescription<ArchetypeModel> {
	}
	[Table(Schema = "polaris",Name = "archetypeexemplar")]
	public partial class ArchetypeExemplar : DataExemplaire<ArchetypeModel> {
	}
}
