using Core.Data;
using Core.Data.Schema;
using CoreWpf.UI;
using Shadowrun5.JdrCore;
using Shadowrun5.JdrCore.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5Wpf.CreationPersonnage {

	#region Enums
	public enum OptionCreation {
		Normal, Rue, Elite
	}
	public enum Priorite {
		A, B, C, D, E
	}
	public enum TypePriorite {
		Metatype, Attribut, Pouvoir, Competence, Ressource
	} 
	#endregion

	public class ParametresCreationPJ : IStepsArgument {
		#region Members
		private OptionCreation _opt;
		#endregion
		/// <summary>
		/// Ctonstructeur, necessite un accès à la base.
		/// </summary>
		/// <param name="dt"></param>
		public ParametresCreationPJ( Database dt ) {
			Data = dt;
			_selections.Add(TypePriorite.Metatype, Priorite.A);
			_selections.Add(TypePriorite.Attribut, Priorite.A);
			_selections.Add(TypePriorite.Pouvoir, Priorite.A);
			_selections.Add(TypePriorite.Competence, Priorite.A);
			_selections.Add(TypePriorite.Ressource, Priorite.A);
		}
		public void Init() {
			Personnage = new Personnage();
			Options = OptionCreation.Normal;
			KarmaCourant = 0;
        }
		public void SetOption( OptionCreation opt ) {
			switch(opt) {
				case OptionCreation.Normal:
				Karma = 25;
				IndiceMax = 6;
				DisponibiliteMax = 12;
				ConvertionKarmaNuyenMax = 10;
				PointsContacts = 3;
				RessourcesA = 75000;
				RessourcesB = 50000;
                RessourcesC = 25000;
				RessourcesD = 15000;
                RessourcesE =  6000;
                break;
				case OptionCreation.Rue:
				Karma = 13;
				IndiceMax = 4;
				DisponibiliteMax = 10;
				ConvertionKarmaNuyenMax = 5;
				PointsContacts = 3;
				RessourcesA = 450000;
				RessourcesB = 275000;
				RessourcesC = 140000;
				RessourcesD = 50000;
				RessourcesE = 6000;
				break;
				case OptionCreation.Elite:
				Karma = 35;
				IndiceMax = 6;
				DisponibiliteMax = 15;
				ConvertionKarmaNuyenMax = 25;
				PointsContacts = 6;
				RessourcesA = 500000;
				RessourcesB = 325000;
				RessourcesC = 210000;
				RessourcesD = 150000;
				RessourcesE = 100000;
				break;
				default:
				break;
			}
		}

		#region Properties
		public Database Data { get; }
		[HiddenProperty]
		public Personnage Personnage { get; private set; } 
		/// <summary>
		/// La méthode de création de personnage.
		/// </summary>
		public OptionCreation Options {
			get { return _opt; }
			set { _opt = value; SetOption(value); }
		}
		/// <summary>
		/// Points de personnalisation à distribuer.
		/// </summary>
		public int Karma { get; private set; }
		/// <summary>
		/// Karma max à la création. Le karma peut par exemple augmenter avec des désavantages.
		/// </summary>
		[HiddenProperty]
		public int KarmaCourant { get; set; }
		/// <summary>
		/// L'indice d'équipement maximum  autorisé à l'achat à la création.
		/// </summary>
		public int IndiceMax { get; private set; }
		/// <summary>
		/// La disponibilité d'équipement maximum  autorisé à l'achat à la création.
		/// </summary>
		public int DisponibiliteMax { get; private set; }
		/// <summary>
		/// Le nombre de points de karma qu'un joueur peut dépenser à la création contre des nuyens (1:2000)
		/// </summary>
		public int ConvertionKarmaNuyenMax { get; private set; }
		/// <summary>
		/// Le facteur utilisé pour connaitre les points gratuits d'achat de contact.
		/// (généralement 3*charisme, 6* charisme pour une création élite.)
		/// </summary>
		public int PointsContacts { get; private set; }
		public int RessourcesA { get; private set; }
		public int RessourcesB { get; private set; }
		public int RessourcesC { get; private set; }
		public int RessourcesD { get; private set; }
		public int RessourcesE { get; private set; }
		private Dictionary<TypePriorite, Priorite> _selections = new Dictionary<TypePriorite, Priorite>();
		public Dictionary<TypePriorite, Priorite> Priorites {
			get { return _selections; }
		}
		#endregion

	}
}
