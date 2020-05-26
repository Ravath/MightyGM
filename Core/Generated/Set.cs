using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data {
	[Table(Schema = "core",Name = "set")]
	[CoreData]
	public partial class Set : SecondaryRessource {

		private IEnumerable<RawRessource> _ressources;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Ressources",OtherKey = "SetId")]
		public IEnumerable <RawRessource> Ressources{
			get{
				if( _ressources == null ){
					_ressources = LoadFromJointure<RawRessource,SetToRawRessource_Ressources>(false);
				}
				return _ressources;
			}
			set{
				SaveToJointure<RawRessource, SetToRawRessource_Ressources> (_ressources, value,false);
				_ressources = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<Set,SetToRawRessource_Ressources>(true);
			base.DeleteObject();
		}
	}
}
