using Core.Engine;
using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Agents {
	public class Grunt: ShadowrunAgent {

		#region Members
		private Grunt _alter;
		private bool _lieutenant;
		#endregion

		#region Properties
		public Value Professionalism { get; }

		public bool Lieutenant {
			get {
				return _lieutenant;
			}
			private set {
				_lieutenant = value;
				Alter._lieutenant = !value;
            }
		}

		public Grunt Alter {
			get { return _alter; }
			private set { _alter = value; }
		}
		#endregion

		#region Setters
		private void setAbstractGruntModelStep( AbsGruntModel agm ) {
			setCharacterModelStep(agm);
			Professionalism.BaseValue = agm.ProfessionalRating;
			Caracteristiques.MaxChance.BaseValue = Professionalism.BaseValue;
		}
		private void setAbstractGruntExemplarStep( AbsGruntExemplar agm ) {
			setCharacterExemplarStep(agm);
			Metatype = new Metatype(agm.Metatype);
		}
		public void SetModel( AbsGruntModel agm ) {
			if(agm == null) { ResetExemplar(); ResetModel(); return; }
			setAbstractGruntModelStep(agm);
		}
		public void SetExemplaire( AbsGruntExemplar agm ) {
			if(agm == null) { ResetExemplar(); return; }
			setAbstractGruntModelStep((AbsGruntModel)agm.Model);
			setAbstractGruntExemplarStep(agm);
        }
		protected override void ResetModel() {
			base.ResetModel();
			Professionalism.BaseValue = 0;
			Caracteristiques.MaxChance.BaseValue = 0;
        }
		protected override void ResetExemplar() {
			base.ResetExemplar();
			Metatype = null;
        }
		#endregion

		#region Constructors
		public Grunt( ) : base() {
			Professionalism = new Value();
			Alter = new Grunt(this);
        }

		public Grunt( Grunt alter ) : base() {
			Professionalism = new Value();
			Alter = alter;
        }

		public Grunt( GruntModel gm ) : this() {
			SetModel(gm);
			Lieutenant = false;
			Alter.SetModel(gm.Lieutenant);
		}
		public Grunt( GruntExemplar gm ) : this() {
			SetExemplaire(gm);
			Lieutenant = false;
			Alter.SetModel(((GruntModel)gm.Model).Lieutenant);
		}
		public Grunt( LieutenantModel lm ) : this() {
			SetModel(lm);
			Lieutenant = true;
			Alter.SetModel(lm.Grunt);
		}
		public Grunt( LieutenantExemplar lm ) : this() {
			SetExemplaire(lm);
			Lieutenant = true;
			Alter.SetModel(((LieutenantModel)lm.Model).Grunt);
		}
		#endregion
	}
}
