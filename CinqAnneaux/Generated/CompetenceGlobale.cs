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
	}
}
