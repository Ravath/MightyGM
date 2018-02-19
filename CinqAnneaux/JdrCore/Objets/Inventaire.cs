using CinqAnneaux.JdrCore.Attributs;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Objets {
	public class Inventaire : ListeObjets<Object, Agent.Agent> {

		public Inventaire( Agent.Agent agent ) : base(agent) {

		}
	}
	public class BaseArmorND : DerivedValue {
		private Attribut _ref;
		public BaseArmorND(Attribut reflexe) : base(reflexe) { _ref = reflexe; }

		public override int BaseValue {
			get {
				return (_ref.TotalValue+1 )*5;
			}
		}
	}

	public class InventaireArmure : WearableModule<Armure, Agent.Agent> {
		#region Members
		private Value _zero = new Value(0);
		private BaseArmorND _base;
		private bool _creature = true;
		#endregion
		#region Properties
		public IndirectValue ND { get; }
		public IndirectValue Reduction { get; }
		#endregion

		public InventaireArmure( Agent.Agent agent ) : base(agent) {
			this.MaxEquipedObject = 1;
			this.ReachedLimitBehaviour = WearableModuleBehaviour.RemoveFirsts;
			_base = new BaseArmorND(agent.Attributs.Reflexes);
			ND = new IndirectValue(_base);
			Reduction = new IndirectValue(_zero);
        }

		public void SetPersonnage() {
			if(_creature) {
				_creature = false;
				ND.SetValue(_base);
				//Reduction.SetValue(_zero);
			}
        }
		public void SetCreature() {
			if(!_creature) {
				_creature = true;
				ND.SetValue(_zero);
				//Reduction.SetValue(_zero);
			}
		}

	}

	public class InventaireArme : WearableModule<Arme, Agent.Agent> {
	
		public InventaireArme( Agent.Agent agent ) : base(agent) {
			this.MaxEquipedObject = 1;
			this.ReachedLimitBehaviour = WearableModuleBehaviour.DoesntWear;
		}
	}
}
