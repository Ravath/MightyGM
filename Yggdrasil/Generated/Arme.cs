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
namespace Yggdrasil.Data {
	[Table(Schema = "yggdrasil",Name = "armemodel")]
	[CoreData]
	public partial class ArmeModel : ObjetModel {

		private ArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeDescription> id = GetModelReferencer<ArmeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private CategorieArme _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieArme Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}

		private int _degats;
		[Column(Storage = "Degats",Name = "degats")]
		public int Degats{
			get{ return _degats;}
			set{_degats = value;}
		}

		private int _solidite;
		[Column(Storage = "Solidite",Name = "solidite")]
		public int Solidite{
			get{ return _solidite;}
			set{_solidite = value;}
		}

		private bool _peutEtreLancee;
		[Column(Storage = "PeutEtreLancee",Name = "peutetrelancee")]
		public bool PeutEtreLancee{
			get{ return _peutEtreLancee;}
			set{_peutEtreLancee = value;}
		}

		private int _porteeC;
		[Column(Storage = "PorteeC",Name = "porteec")]
		public int PorteeC{
			get{ return _porteeC;}
			set{_porteeC = value;}
		}

		private int _porteeM;
		[Column(Storage = "PorteeM",Name = "porteem")]
		public int PorteeM{
			get{ return _porteeM;}
			set{_porteeM = value;}
		}

		private int _porteeL;
		[Column(Storage = "PorteeL",Name = "porteel")]
		public int PorteeL{
			get{ return _porteeL;}
			set{_porteeL = value;}
		}

		private int _porteeE;
		[Column(Storage = "PorteeE",Name = "porteee")]
		public int PorteeE{
			get{ return _porteeE;}
			set{_porteeE = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "armedescription")]
	public partial class ArmeDescription : ObjetDescription {
	}
	[Table(Schema = "yggdrasil",Name = "armeexemplar")]
	public partial class ArmeExemplar : ObjetExemplar {

		private int _soliditeRestante;
		[Column(Storage = "SoliditeRestante",Name = "soliditerestante")]
		public int SoliditeRestante{
			get{ return _soliditeRestante;}
			set{_soliditeRestante = value;}
		}
	}
}
