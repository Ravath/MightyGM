using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Engine {
	public interface IAttributesGenerator {
		void GenerateValues( Attributes attributes );
	}
	public interface PointsMethodPolicy {
		int DefaultValue { set; }
		int Cost( int oldValue, int newValue );
	}
}
