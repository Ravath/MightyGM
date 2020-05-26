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
	[Table(Schema = "polaris",Name = "techniquemartialemodel")]
	[CoreData]
	public partial class TechniqueMartialeModel : DataModel {

		private TechniqueMartialeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TechniqueMartialeDescription> id = GetModelReferencer<TechniqueMartialeDescription>();
					if(id.Count() == 0) {
						_obj = new TechniqueMartialeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeTechniqueMartiale _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeTechniqueMartiale Type{
			get{ return _type;}
			set{_type = value;}
		}

		private bool _utilisationLibre;
		[Column(Storage = "UtilisationLibre",Name = "utilisationlibre")]
		public bool UtilisationLibre{
			get{ return _utilisationLibre;}
			set{_utilisationLibre = value;}
		}
	}
	[Table(Schema = "polaris",Name = "techniquemartialedescription")]
	public partial class TechniqueMartialeDescription : DataDescription<TechniqueMartialeModel> {
	}
	[Table(Schema = "polaris",Name = "techniquemartialeexemplar")]
	public partial class TechniqueMartialeExemplar : DataExemplaire<TechniqueMartialeModel> {
	}
}
