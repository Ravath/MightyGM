using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Parser;

namespace DataGenerator.DataModel {
	public class DiceTable : EnumTable {
		public DiceTable( RawTable rwt) : base(rwt)   {

		}
		public override AbsAttribute CreateAttribute( RawAttribute attribute ) {
			bool hasParsed = int.TryParse(attribute.Type, out int odd);
			if (hasParsed && odd>0) {
				if(string.IsNullOrWhiteSpace(attribute.Name)) {
					ErrorManager.Error(Name + ": Attribute without name.");
					return null;
				} else {
					DiceAttribute da = new DiceAttribute() {
						Name = attribute.Name,
						Odds = odd
					};
					if(!string.IsNullOrWhiteSpace(attribute.CardMax)
						|| !string.IsNullOrWhiteSpace(attribute.CardMin)
						|| !string.IsNullOrWhiteSpace(attribute.Section)
						|| !string.IsNullOrWhiteSpace(attribute.Target)
						|| !string.IsNullOrWhiteSpace(attribute.TypeTag)) {
						ErrorManager.Error(Name + ":Les attributs d'une DiceTable ont uniquement un attribut nom et un type.");
					}
					return da;
				}
			} else {
				ErrorManager.Error(Name + ": Type must be a positive integer.");
				return null;
			}
        }

		public override bool CheckIntegrity() {
			bool positive = true;
			foreach(DiceAttribute att in Attributes)
				positive = att.CheckIntegrity() && positive;
			return base.CheckIntegrity() && positive;
		}
	}
}
