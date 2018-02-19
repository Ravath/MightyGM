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
	[Table(Schema = "shadowrun5",Name = "augmentationmodel")]
	[CoreData]
	public partial class AugmentationModel : ProductModel {

		private AugmentationDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AugmentationDescription> id = GetModelReferencer<AugmentationDescription>();
					if(id.Count() == 0) {
						_obj = new AugmentationDescription();
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

		private AugmentationType _type;
		[Column(Storage = "Type",Name = "type")]
		public AugmentationType Type{
			get{ return _type;}
			set{_type = value;}
		}

		private double _essence;
		[Column(Storage = "Essence",Name = "essence")]
		public double Essence{
			get{ return _essence;}
			set{_essence = value;}
		}

		private int _capacity;
		[Column(Storage = "Capacity",Name = "capacity")]
		public int Capacity{
			get{ return _capacity;}
			set{_capacity = value;}
		}

		private int _minRating;
		[Column(Storage = "MinRating",Name = "minrating")]
		public int MinRating{
			get{ return _minRating;}
			set{_minRating = value;}
		}

		private int _maxRating;
		[Column(Storage = "MaxRating",Name = "maxrating")]
		public int MaxRating{
			get{ return _maxRating;}
			set{_maxRating = value;}
		}

		private bool _isContainer;
		[Column(Storage = "IsContainer",Name = "iscontainer")]
		public bool IsContainer{
			get{ return _isContainer;}
			set{_isContainer = value;}
		}

		private bool _ratPerAvail;
		[Column(Storage = "RatPerAvail",Name = "ratperavail")]
		public bool RatPerAvail{
			get{ return _ratPerAvail;}
			set{_ratPerAvail = value;}
		}

		private bool _ratPerEssence;
		[Column(Storage = "RatPerEssence",Name = "ratperessence")]
		public bool RatPerEssence{
			get{ return _ratPerEssence;}
			set{_ratPerEssence = value;}
		}

		private bool _ratPerCapacity;
		[Column(Storage = "RatPerCapacity",Name = "ratpercapacity")]
		public bool RatPerCapacity{
			get{ return _ratPerCapacity;}
			set{_ratPerCapacity = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "augmentationdescription")]
	public partial class AugmentationDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "augmentationexemplar")]
	public partial class AugmentationExemplar : ProductExemplar {

		private int _rating;
		[Column(Storage = "Rating",Name = "rating")]
		public int Rating{
			get{ return _rating;}
			set{_rating = value;}
		}

		private WareGrade _grade;
		[Column(Storage = "Grade",Name = "grade")]
		public WareGrade Grade{
			get{ return _grade;}
			set{_grade = value;}
		}

		private IEnumerable<AugmentationModel> _modifications;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Modifications",OtherKey = "AugmentationExemplarId")]
		public IEnumerable <AugmentationModel> Modifications{
			get{
				if( _modifications == null ){
					_modifications = LoadFromJointure<AugmentationModel,AugmentationExemplarToAugmentationModel_Modifications>(false);
				}
				return _modifications;
			}
			set{
				SaveToJointure<AugmentationModel, AugmentationExemplarToAugmentationModel_Modifications> (_modifications, value,false);
				_modifications = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AugmentationExemplar,AugmentationExemplarToAugmentationModel_Modifications>(true);
			base.DeleteObject();
		}
	}
}
