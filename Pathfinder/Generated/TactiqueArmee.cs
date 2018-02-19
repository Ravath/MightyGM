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
	[Table(Schema = "pathfinder",Name = "tactiquearmeemodel")]
	[CoreData]
	public partial class TactiqueArmeeModel : DataModel {

		private TactiqueArmeeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TactiqueArmeeDescription> id = GetModelReferencer<TactiqueArmeeDescription>();
					if(id.Count() == 0) {
						_obj = new TactiqueArmeeDescription();
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
	[Table(Schema = "pathfinder",Name = "tactiquearmeedescription")]
	public partial class TactiqueArmeeDescription : DataDescription<TactiqueArmeeModel> {
	}
	[Table(Schema = "pathfinder",Name = "tactiquearmeeexemplar")]
	public partial class TactiqueArmeeExemplar : DataExemplaire<TactiqueArmeeModel> {
	}
}
