using System;
using CoreWpf.UI;
using CinqAnneaux.JdrCore.Agent;
using Core.Data.Schema;
using Core.Data;

namespace CinqAnneauxWpf.CreationPersonnage {
	internal class ParametresCreationPJ : IStepsArgument {

		public ParametresCreationPJ( Database dt ) {
			this.Data = dt;
		}

		public void Init() {
			Personnage = new Personnage();
			Experience = 40;
			AdvantagesAreCaped = true;
			AuthorizedRonin = false;
			AuthorizedMoine = false;
			AuthorizedClanMineur   = false;
			AuthorizedClanAraignee = false;
        }

		#region Properties
		[HiddenProperty]
		public Database Data { get; }
		[HiddenProperty]
		public Personnage Personnage { get; private set; }
		//options
		public bool AuthorizedRonin { get; set; }
		public bool AuthorizedMoine { get; set; }
		public bool AuthorizedClanMineur	{ get; set; }
		public bool AuthorizedClanAraignee  { get; set; }
		/// <summary>
		/// The initial amount of experience points.
		/// </summary>
		public int Experience { get; set; }
		/// <summary>
		/// True if no more than 15 points can be invested in advantages.
		/// </summary>
		public bool AdvantagesAreCaped { get; set; }
		#endregion
	}
}