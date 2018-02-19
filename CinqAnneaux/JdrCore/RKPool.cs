using Core.Dice;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore {

	public class CompositeRKPool : AbsRKPool {

		private IValue _keep;
		private IValue _number;

		public override IValue KeepIValue {
			get { return _keep; }
		}

		public override IValue NumberIValue {
			get { return _number; }
		}

		public CompositeRKPool( IValue n, IValue k ) {
			_keep = k;
			_number = n;
		}
		public CompositeRKPool( AbsRKPool pool ) : this(pool.NumberIValue, pool.KeepIValue) { }
	}

	public class RKPool : AbsRKPool {

		public Value KeepValue { get; protected set; }
		public Value NumberValue { get; protected set; }

		public override IValue KeepIValue {
			get {
				return KeepValue;
			}
		}

		public override IValue NumberIValue {
			get {
				return NumberValue;
			}
		}
		public override int Keep {
			get { return base.Keep; }
			set { KeepValue.BaseValue = value; }
		}
		/// <summary>
		/// the natural numbre of dice to roll.
		/// Set the base value, but get the total value!!
		/// </summary>
		public override int Number {
			get { return base.Number; }
			set { NumberValue.BaseValue = value; }
		}

		public RKPool() {
			KeepValue = new Value();
			NumberValue = new Value();
		}
	}

	public abstract class AbsRKPool : IPool {

		#region members
		private List<int> _result = new List<int>();
		#endregion

		public abstract IValue KeepIValue { get; }
		public abstract IValue NumberIValue { get; }

		public virtual int Keep {
			get { return KeepIValue.TotalValue; }
			set { }
		}
		/// <summary>
		/// the natural numbre of dice to roll.
		/// Set the base value, but get the total value!!
		/// </summary>
		public virtual int Number {
			get { return NumberIValue.TotalValue; }
			set { }
		}
		/// <summary>
		/// Always 10.
		/// </summary>
		public int Face {
			get { return 10; }
			set {/* nothing */}
		}
		/// <summary>
		/// All the results from the last roll..
		/// </summary>
		public IEnumerable<int> Results {
			get { return _result; }
		}

		/// <summary>
		/// Throw 'number' dice'.
		/// Sum the 'Keep' highest.
		/// </summary>
		/// <returns>The sum of the highest scores.</returns>
		public int GetResult() {
			Roll();
			int s = 0;
			int keep = Math.Min(Keep, _result.Count);
			for(int i = 0; i<keep; i++) {
				s += _result[i];
			}
			return s;
		}

		public void Roll() {
			_result.Clear();
			for(int i =0; i<Number; i++) {
				_result.Add(Pool.RollD(Face));
			}
			_result.Sort();
			_result.Reverse();
		}

		public override string ToString() {
			return String.Format("{0}g{1}",Number, Keep);
		}
	}
}
