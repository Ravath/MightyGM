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
	[Table(Schema = "cinqanneaux",Name = "groupeavantagemodel")]
	[CoreData]
	public partial class GroupeAvantageModel : DataModel {

		private GroupeAvantageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<GroupeAvantageDescription> id = GetModelReferencer<GroupeAvantageDescription>();
					if(id.Count() == 0) {
						_obj = new GroupeAvantageDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<AbsAvantageModel> _avantages;
		public IEnumerable <AbsAvantageModel> Avantages{
			get{
				if( _avantages == null ){
					_avantages = LoadByForeignKey<AbsAvantageModel>(p => p.GroupeId, Id);
				}
				return _avantages;
			}
			set{
				foreach( AbsAvantageModel item in _avantages ){
					item.Groupe = null;

				}
				_avantages = value;
				foreach( AbsAvantageModel item in value ){
					item.Groupe = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "groupeavantagedescription")]
	public partial class GroupeAvantageDescription : DataDescription<GroupeAvantageModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "groupeavantageexemplar")]
	public partial class GroupeAvantageExemplar : DataExemplaire<GroupeAvantageModel> {
	}
}
