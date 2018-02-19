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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "absdvmodel")]
	public abstract partial class AbsDVModel : DataModel {

		private int _dVType;
		[Column(Storage = "DVType",Name = "dvtype")]
		public int DVType{
			get{ return _dVType;}
			set{_dVType = value;}
		}

		private int _facteurCompetence;
		[Column(Storage = "FacteurCompetence",Name = "facteurcompetence")]
		public int FacteurCompetence{
			get{ return _facteurCompetence;}
			set{_facteurCompetence = value;}
		}

		private ProgressionBBA _bBA;
		[Column(Storage = "BBA",Name = "bba")]
		public ProgressionBBA BBA{
			get{ return _bBA;}
			set{_bBA = value;}
		}

		private ProgessionSauvegarde _reflexes;
		[Column(Storage = "Reflexes",Name = "reflexes")]
		public ProgessionSauvegarde Reflexes{
			get{ return _reflexes;}
			set{_reflexes = value;}
		}

		private ProgessionSauvegarde _vigueur;
		[Column(Storage = "Vigueur",Name = "vigueur")]
		public ProgessionSauvegarde Vigueur{
			get{ return _vigueur;}
			set{_vigueur = value;}
		}

		private ProgessionSauvegarde _volonte;
		[Column(Storage = "Volonte",Name = "volonte")]
		public ProgessionSauvegarde Volonte{
			get{ return _volonte;}
			set{_volonte = value;}
		}
	}
	[Table(Schema = "dd35",Name = "absdvdescription")]
	public abstract partial class AbsDVDescription : DataDescription<AbsDVModel> {
	}
	[Table(Schema = "dd35",Name = "absdvexemplar")]
	public abstract partial class AbsDVExemplar : DataExemplaire<AbsDVModel> {
	}
}
