using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGenerator.CSharp;
using DataGenerator.Parser;

namespace DataGenerator.DataModel {
	public class EnumTable : AbsTable {
		public EnumTable(RawTable table) : base(table) {

		}

		public override AbsAttribute CreateAttribute( RawAttribute attribute ) {
			EnumAttribute ae = new EnumAttribute() { Name = attribute.Name };
			if(!string.IsNullOrWhiteSpace(attribute.Type)
				|| !string.IsNullOrWhiteSpace(attribute.CardMax)
				|| !string.IsNullOrWhiteSpace(attribute.CardMin)
				|| !string.IsNullOrWhiteSpace(attribute.Section)
				|| !string.IsNullOrWhiteSpace(attribute.Target)
				|| !string.IsNullOrWhiteSpace(attribute.TypeTag)) {
				ErrorManager.Error(Name+":Les attributs d'une enumeration ont uniquement un attribut nom.");
			}
			if(string.IsNullOrWhiteSpace(attribute.Name)) {
				ErrorManager.Error(Name + ":Attribut sans nom détecté.");
			}
			return ae;
        }

		public override bool CheckIntegrity() {
			if(Attributes.Count() < 1) {
				ErrorManager.Error(Name + " Has No Attributes.");
				return base.CheckIntegrity() && false;
            }
			return base.CheckIntegrity();
		}
	}
}
