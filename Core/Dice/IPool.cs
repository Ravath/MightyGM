using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dice {
	public interface IPool {
		/// <summary>
		/// The number of dice in the pool. Must be >=1.
		/// </summary>
		int Number { get; set; }
		/// <summary>
		/// The number of faces of the dice. Must be >=1.
		/// </summary>
		int Face { get; set; }
		/// <summary>
		/// The results of the dice when thrown.
		/// </summary>
		IEnumerable<int> Results { get; }
		/// <summary>
		/// Roll the dice and the return the result as an integer.
		/// </summary>
		/// <returns></returns>
		int GetResult();
		/// <summary>
		/// roll the dice.
		/// </summary>
		void Roll();
	}
}
