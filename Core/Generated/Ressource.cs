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
	[Table(Schema = "core",Name = "ressource")]
	public abstract partial class Ressource : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private IEnumerable<Tag> _tags;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Tags",OtherKey = "RessourceId")]
		public IEnumerable <Tag> Tags{
			get{
				if( _tags == null ){
					_tags = LoadFromJointure<Tag,RessourceToTag_Tags>(false);
				}
				return _tags;
			}
			set{
				SaveToJointure<Tag, RessourceToTag_Tags> (_tags, value,false);
				_tags = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<Ressource,RessourceToTag_Tags>(true);
			base.DeleteObject();
		}
	}
}
