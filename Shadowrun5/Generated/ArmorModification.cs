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
	[Table(Schema = "shadowrun5",Name = "armormodificationmodel")]
	[CoreData]
	public partial class ArmorModificationModel : ProductModel {

		private ArmorModificationDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmorModificationDescription> id = GetModelReferencer<ArmorModificationDescription>();
					if(id.Count() == 0) {
						_obj = new ArmorModificationDescription();
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

		private int _capacity;
		[Column(Storage = "Capacity",Name = "capacity")]
		public int Capacity{
			get{ return _capacity;}
			set{_capacity = value;}
		}

		private bool _hasRating;
		[Column(Storage = "HasRating",Name = "hasrating")]
		public bool HasRating{
			get{ return _hasRating;}
			set{_hasRating = value;}
		}

		private int _exlusivityId;
		[Column(Storage = "ExlusivityId",Name = "fk_armormodel_exlusivity")]
		[HiddenProperty]
		public int ExlusivityId{
			get{ return _exlusivityId;}
			set{_exlusivityId = value;}
		}

		private ArmorModel _exlusivity;
		public ArmorModel Exlusivity{
			get{
				if( _exlusivity == null)
					_exlusivity = LoadById<ArmorModel>(ExlusivityId);
				return _exlusivity;
			} set {
				if(_exlusivity == value){return;}
				_exlusivity = value;
				if( value != null)
					ExlusivityId = value.Id;
			}
		}
	}
	[Table(Schema = "shadowrun5",Name = "armormodificationdescription")]
	public partial class ArmorModificationDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "armormodificationexemplar")]
	public partial class ArmorModificationExemplar : ProductExemplar {

		private int _rating;
		[Column(Storage = "Rating",Name = "rating")]
		public int Rating{
			get{ return _rating;}
			set{_rating = value;}
		}
	}
}
