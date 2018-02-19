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
	[Table(Schema = "shadowrun5",Name = "mentorspiritmodel")]
	[CoreData]
	public partial class MentorSpiritModel : DataModel {

		private MentorSpiritDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MentorSpiritDescription> id = GetModelReferencer<MentorSpiritDescription>();
					if(id.Count() == 0) {
						_obj = new MentorSpiritDescription();
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
	}
	[Table(Schema = "shadowrun5",Name = "mentorspiritdescription")]
	public partial class MentorSpiritDescription : DataDescription<MentorSpiritModel> {

		private string _allAdvantage = "";
		[LargeText]
		[Column(Storage = "AllAdvantage",Name = "alladvantage")]
		public string AllAdvantage{
			get{ return _allAdvantage;}
			set{_allAdvantage = value;}
		}

		private string _magicianAdvantage = "";
		[LargeText]
		[Column(Storage = "MagicianAdvantage",Name = "magicianadvantage")]
		public string MagicianAdvantage{
			get{ return _magicianAdvantage;}
			set{_magicianAdvantage = value;}
		}

		private string _adeptAdvantage = "";
		[LargeText]
		[Column(Storage = "AdeptAdvantage",Name = "adeptadvantage")]
		public string AdeptAdvantage{
			get{ return _adeptAdvantage;}
			set{_adeptAdvantage = value;}
		}

		private string _disadvantages = "";
		[LargeText]
		[Column(Storage = "Disadvantages",Name = "disadvantages")]
		public string Disadvantages{
			get{ return _disadvantages;}
			set{_disadvantages = value;}
		}


		private IEnumerable < string > _similarArchetypes;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "SimilarArchetypes",OtherKey = "MentorSpiritDescription")]
		public IEnumerable < string > SimilarArchetypes{
			get{
				if( _similarArchetypes == null ){
					_similarArchetypes = LoadFromDataValue<SimilarArchetypesFromMentorSpiritDescription, string>();
				}
				return _similarArchetypes;
			}
			set{
				SaveDataValue<SimilarArchetypesFromMentorSpiritDescription, string>(_similarArchetypes, value);
			}
		}
		public override void DeleteObject() {
			DeleteDataValue<SimilarArchetypesFromMentorSpiritDescription>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "shadowrun5",Name = "mentorspiritexemplar")]
	public partial class MentorSpiritExemplar : DataExemplaire<MentorSpiritModel> {
	}
}
