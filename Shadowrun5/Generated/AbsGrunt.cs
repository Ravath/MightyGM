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
	[Table(Schema = "shadowrun5",Name = "absgruntmodel")]
	public abstract partial class AbsGruntModel : CharacterModel {

		private int _professionalRating;
		[Column(Storage = "ProfessionalRating",Name = "professionalrating")]
		public int ProfessionalRating{
			get{ return _professionalRating;}
			set{_professionalRating = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "absgruntdescription")]
	public abstract partial class AbsGruntDescription : CharacterDescription {
	}
	[Table(Schema = "shadowrun5",Name = "absgruntexemplar")]
	public abstract partial class AbsGruntExemplar : CharacterExemplar {

		private int _metatypeId;
		[Column(Storage = "MetatypeId",Name = "fk_metatypemodel_metatype")]
		[HiddenProperty]
		public int MetatypeId{
			get{ return _metatypeId;}
			set{_metatypeId = value;}
		}

		private MetatypeModel _metatype;
		public MetatypeModel Metatype{
			get{
				if( _metatype == null)
					_metatype = LoadById<MetatypeModel>(MetatypeId);
				return _metatype;
			} set {
				if(_metatype == value){return;}
				_metatype = value;
				if( value != null)
					MetatypeId = value.Id;
			}
		}
	}
}
