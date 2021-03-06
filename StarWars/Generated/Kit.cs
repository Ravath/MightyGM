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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "kitmodel")]
	[CoreData]
	public partial class KitModel : ObjectModel {

		private KitDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<KitDescription> id = GetModelReferencer<KitDescription>();
					if(id.Count() == 0) {
						_obj = new KitDescription();
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

		private int _emplacement;
		[Column(Storage = "Emplacement",Name = "emplacement")]
		public int Emplacement{
			get{ return _emplacement;}
			set{_emplacement = value;}
		}

		private TypeKit _typeKit;
		[Column(Storage = "TypeKit",Name = "typekit")]
		public TypeKit TypeKit{
			get{ return _typeKit;}
			set{_typeKit = value;}
		}

		private string _effet = "";
		[LargeText]
		[Column(Storage = "Effet",Name = "effet")]
		public string Effet{
			get{ return _effet;}
			set{_effet = value;}
		}

		private IEnumerable<ModModel> _modsPossibles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "ModsPossibles",OtherKey = "KitModelId")]
		public IEnumerable <ModModel> ModsPossibles{
			get{
				if( _modsPossibles == null ){
					_modsPossibles = LoadFromJointure<ModModel,KitModelToModModel>(false);
				}
				return _modsPossibles;
			}
			set{
				SaveToJointure<ModModel, KitModelToModModel> (_modsPossibles, value,false);
				_modsPossibles = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<KitModel,KitModelToModModel>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "starwars",Name = "kitdescription")]
	public partial class KitDescription : ObjectDescription {
	}
	[Table(Schema = "starwars",Name = "kitexemplar")]
	public partial class KitExemplar : ObjectExemplar {

		private IEnumerable<ModExemplar> _modsInstalles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "ModsInstalles",OtherKey = "KitExemplarId")]
		public IEnumerable <ModExemplar> ModsInstalles{
			get{
				if( _modsInstalles == null ){
					_modsInstalles = LoadFromJointure<ModExemplar,KitExemplarToModExemplar>(false);
				}
				return _modsInstalles;
			}
			set{
				SaveToJointure<ModExemplar, KitExemplarToModExemplar> (_modsInstalles, value,false);
				_modsInstalles = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<KitExemplar,KitExemplarToModExemplar>(true);
			base.DeleteObject();
		}
	}
}
