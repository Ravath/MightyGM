using Shadowrun5.Data;
using Shadowrun5.JdrCore.Traits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore {
	public static class Instanciator {
		public static Metatype GetMetatype( MetatypeModel model ) {
			Metatype ret = new Metatype(model);
            switch(model.Tag) {
				//case "MET0001"://human
				//break;
				case "MET0002"://dwarf
				ResistanceToxines rs = new ResistanceToxines(2);
				rs.Bonus.Label = "Nain";
                ret.AddTrait(rs);
				break;
				//case "MET0003"://elf
				//break;
				//case "MET0004"://ork
				//break;
				//case "MET0005"://troll
				//break;
			}
			return ret;
		}
	}
}
