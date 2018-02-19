using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.Data;

namespace CinqAnneaux.JdrCore.Capacites {

	public class Sort : AbsRankedCapacity {

		protected double _range;
		protected TargetType _targetType;

		public bool Mahou { get; private set; }
		public bool Concentration { get; private set; }
		public ElementSort Element { get; protected set; }

		public override double Range { get { return _range; } }
		public override TargetType TargetType { get { return _targetType; } }

		public void SetSortModel( AbsSortModel model ) {
			Name = model.Name;
			Element = model.Element;
			Rank = model.Maitrise;
			Mahou = (model is MahouModel);
			Concentration = model.Concentration;
			_range = (double)model.FacteurPortee;
			Delegate = SortImplementer.GetImplementation(model.Tag);
			// TODO : remove this bulshit
			switch(model.Portee) {
				case Portee.Personnel:
				_targetType = TargetType.Self;
                break;
				case Portee.Contact:
				_targetType = TargetType.Agent;
				break;
				case Portee.PersonnelContact:
				_targetType = TargetType.Agent;
				break;
				case Portee.Metres:
				_targetType = TargetType.Place;
				break;
				case Portee.Kilometres:
				_targetType = TargetType.Place;
				break;
				case Portee.Special:
				_targetType = TargetType.Place;
				break;
				default:
				throw new NotImplementedException("SetSortModel not implemented for enum "+model);
			}
		}
	}
}
