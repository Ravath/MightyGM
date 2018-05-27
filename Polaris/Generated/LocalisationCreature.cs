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
	[Table(Schema = "polaris",Name = "localisationcreaturemodel")]
	[CoreData]
	public partial class LocalisationCreatureModel : DataModel {

		private LocalisationCreatureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<LocalisationCreatureDescription> id = GetModelReferencer<LocalisationCreatureDescription>();
					if(id.Count() == 0) {
						_obj = new LocalisationCreatureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}
	}
	[Table(Schema = "polaris",Name = "localisationcreaturedescription")]
	public partial class LocalisationCreatureDescription : DataDescription<LocalisationCreatureModel> {
	}
	[Table(Schema = "polaris",Name = "localisationcreatureexemplar")]
	public partial class LocalisationCreatureExemplar : DataExemplaire<LocalisationCreatureModel> {

		private int _chances;
		[Column(Storage = "Chances",Name = "chances")]
		public int Chances{
			get{ return _chances;}
			set{_chances = value;}
		}
	}
}
