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
	[Table(Schema = "yggdrasil",Name = "objetquotidienmodel")]
	[CoreData]
	public partial class ObjetQuotidienModel : ObjetModel {

		private ObjetQuotidienDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ObjetQuotidienDescription> id = GetModelReferencer<ObjetQuotidienDescription>();
					if(id.Count() == 0) {
						_obj = new ObjetQuotidienDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _prixMax;
		[Column(Storage = "PrixMax",Name = "prixmax")]
		public bool PrixMax{
			get{ return _prixMax;}
			set{_prixMax = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "objetquotidiendescription")]
	public partial class ObjetQuotidienDescription : ObjetDescription {
	}
	[Table(Schema = "yggdrasil",Name = "objetquotidienexemplar")]
	public partial class ObjetQuotidienExemplar : ObjetExemplar {

		private int _prixAchat;
		[Column(Storage = "PrixAchat",Name = "prixachat")]
		public int PrixAchat{
			get{ return _prixAchat;}
			set{_prixAchat = value;}
		}
	}
}
