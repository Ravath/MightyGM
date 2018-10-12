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
	[Table(Schema = "cinqanneaux",Name = "attaquefigurant")]
	[CoreData]
	public partial class AttaqueFigurant : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private int _degats_r;
		[Column(Storage = "Degats_r",Name = "degats_r")]
		public int Degats_r{
			get{ return _degats_r;}
			set{_degats_r = value;}
		}

		private int _degats_k;
		[Column(Storage = "Degats_k",Name = "degats_k")]
		public int Degats_k{
			get{ return _degats_k;}
			set{_degats_k = value;}
		}

		private int _toucher_r;
		[Column(Storage = "Toucher_r",Name = "toucher_r")]
		public int Toucher_r{
			get{ return _toucher_r;}
			set{_toucher_r = value;}
		}

		private int _toucher_k;
		[Column(Storage = "Toucher_k",Name = "toucher_k")]
		public int Toucher_k{
			get{ return _toucher_k;}
			set{_toucher_k = value;}
		}

		private Action _action;
		[Column(Storage = "Action",Name = "action")]
		public Action Action{
			get{ return _action;}
			set{_action = value;}
		}

		private int _figurantId;
		[Column(Storage = "FigurantId",Name = "fk_figurantmodel_figurant")]
		[HiddenProperty]
		public int FigurantId{
			get{ return _figurantId;}
			set{_figurantId = value;}
		}

		private FigurantModel _figurant;
		public FigurantModel Figurant{
			get {
				if(_figurant == null) {
					_figurant = LoadById<FigurantModel>(FigurantId);
			       }
				return _figurant;
			} set {
				if(value == _figurant) { return; }
				_figurant = value;
				if(_figurant != null) {
					_figurantId = _figurant.Id;
				} else {
					_figurantId = 0;
				}
			}
		}
	}
}
