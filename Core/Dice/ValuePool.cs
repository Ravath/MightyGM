using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dice {
	public class ValuePool : IPool {

		private Value _nbr = new Value(1);
		private Value _face = new Value(6);
		private List<int> _results = new List<int>();

		public int Face {
			get { return _face.BaseValue; }
			set { _face.BaseValue = value; }
		}

		public int Number {
			get { return _nbr.BaseValue; }
			set { _nbr.BaseValue = value; }
		}

		public IEnumerable<int> Results {
			get { return _results; }
		}
		public Value NumberValue {
			get { return _nbr; }
		}
		public Value FaceValue {
			get { return _face; }
		}
		/// <summary>
		/// Default implementation : throw the dice and gets the sum.
		/// </summary>
		/// <returns>The sum of the roll.</returns>
		public virtual int GetResult() {
			Roll();
            return _results.Sum();
		}

		public void Roll() {
			_results.Clear();
			for(int i = 0; i < _nbr.TotalValue; i++) {
				_results.Add(Pool.RollD(_face.TotalValue));
			}
		}
	}
}
