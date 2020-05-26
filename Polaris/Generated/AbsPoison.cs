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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "abspoisonmodel")]
	public abstract partial class AbsPoisonModel : DataModel {

		private ModeContamination _modeContamination;
		[Column(Storage = "ModeContamination",Name = "modecontamination")]
		public ModeContamination ModeContamination{
			get{ return _modeContamination;}
			set{_modeContamination = value;}
		}

		private int _modifDiagnostique;
		[Column(Storage = "ModifDiagnostique",Name = "modifdiagnostique")]
		public int ModifDiagnostique{
			get{ return _modifDiagnostique;}
			set{_modifDiagnostique = value;}
		}

		private int _modifGuerison;
		[Column(Storage = "ModifGuerison",Name = "modifguerison")]
		public int ModifGuerison{
			get{ return _modifGuerison;}
			set{_modifGuerison = value;}
		}
	}
	[Table(Schema = "polaris",Name = "abspoisondescription")]
	public abstract partial class AbsPoisonDescription : DataDescription<AbsPoisonModel> {
	}
	[Table(Schema = "polaris",Name = "abspoisonexemplar")]
	public abstract partial class AbsPoisonExemplar : DataExemplaire<AbsPoisonModel> {
	}
}
