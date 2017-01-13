using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics.Contracts;

namespace Core.Dice {
	public class Pool {
		public static int RollD( int faces ) {
			return _generator.Next(1, faces + 1);
        }
		public static int D20() {
			return RollD(20);
        }
		//[ContractInvariantMethod]
		//protected void ObjectInvariant() {
		//	Contract.Invariant(Number >= 1);
		//	Contract.Invariant(Face >= 1);
		//}
		#region Init
		/// <summary>
		/// Init with 1D6.
		/// </summary>
		public Pool() {
			_number = 1;
			_face = 6;
		}
		/// <summary>
		/// Init with XdY where X: NumberOfDice and Y: FacesOfDice
		/// </summary>
		/// <param name="NumberOfDice">The number of dice in the pool. Must be >=1.</param>
		/// <param name="FacesOfDice">The number of faces of the dice. Must be >=1.</param>
		public Pool(int NumberOfDice, int FacesOfDice ) {
			//Contract.Requires(NumberOfDice >= 1);
			//Contract.Requires(FacesOfDice >= 1);
			_number = NumberOfDice;
			_face = FacesOfDice;
		}
		#endregion
		#region Properties
		private static Random _generator = new Random();//the numbers generator.
		private int _number;
		private int _face;
		private List<int> _results = new List<int>();
		#endregion
		#region Properties
		/// <summary>
		/// The number of dice in the pool. Must be >=1.
		/// </summary>
		public int Number {
			get { return _number; }
			set { _number = value;
				//Contract.Requires(value >= 1);
			}
		}
		/// <summary>
		/// The number of faces of the dice. Must be >=1.
		/// </summary>
		public int Face {
			get { return _face; }
			set { _face = value;
				//Contract.Requires(value >= 1);
			}
		}
		/// <summary>
		/// The results of the dice when thrown.
		/// </summary>
		public IEnumerable<int> Results {
			get { return _results; }
		} 
		#endregion

		public void Roll() {
			//Contract.Requires(Face>=1);
			//Contract.Requires(Number>=1);
			_results.Clear();
			for(int i = 0; i < _number; i++) {
				_results.Add(RollD(_face));
			}
			//Contract.Ensures(_results.Count() == Number);
		}
		/// <summary>
		/// Sort the results by increasing order.
		/// </summary>
		public void Sort() {
			_results.Sort();
		}
		/// <summary>
		/// Sort the results by decreasing order.
		/// </summary>
		public void SortDecreasing() {
			_results.Sort();
			_results.Reverse();
        }
    }
}
