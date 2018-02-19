using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Engine {
	public class CompositeJauge : IJauge {

		#region Members
		private int _soustract;
		private IValue _max;
		private IValue _min;
		#endregion

		#region Init
		public CompositeJauge( IValue min, IValue max, int current ) {
			if(max == null || min == null) {
				throw new ArgumentException("Max and Min IValues shall not be null");
			}
			_max = max;
			_min = min;
			_soustract = MaxValue - current;
			_max.ValueChanged += maxValChanged;
			_min.ValueChanged += minValChanged;
		}
		public CompositeJauge(int min, int max, int current) : this(new Value(min) , new Value(max) ,current){ }
		public CompositeJauge( int min, IValue max , int current ) : this(new Value(min), max, current) { }
		#endregion

		private void maxValChanged( IValue v, int oldval, int newval ) {
			if(MaxValueChanged != null) {
				MaxValueChanged(this, oldval, newval);
            }
			checkMinMax();
        }
		private void minValChanged( IValue v, int oldval, int newval ) {
			if(MinValueChanged != null) {
				MinValueChanged(this, oldval, newval);
			}
			checkMinMax();
		}
		private void checkMinMax() {
			if(_soustract == 0 && OnIsMax!=null) {
				OnIsMax(this);
            }if(_soustract == Max.TotalValue - Min.TotalValue && OnIsMin != null) {
				OnIsMin(this);
			}
		}

		#region Properties
		public IValue Max { get { return _max; } }
		public IValue Min { get { return _min; } }
		public int CurrentValue {
			get { return MaxValue - _soustract; }
			set {
				if(value == CurrentValue) { return; }
				setCurrentValue(value);
			}
		}
		public int MaxValue { get { return _max.TotalValue; } }
		public int MinValue { get { return _min.TotalValue; } }
		public bool Full { get { return CurrentValue >= MaxValue; } }
		public bool Empty { get { return CurrentValue <= MinValue; } }
		#endregion

		#region Events
		public event ValueChangedEventHandler CurrentValueChanged;
		public event ValueChangedEventHandler MaxValueChanged;
		public event ValueChangedEventHandler MinValueChanged;
		public event JaugeEventHandler OnIsMax;
		public event JaugeEventHandler OnIsMin;
		#endregion


		/// <summary>
		/// 
		/// </summary>
		/// <param name="soustractedValue">Shall be positive.</param>
		public void Decrease( int soustractedValue ) {
			if(soustractedValue == 0) { return; }
			if(soustractedValue < 0)
				throw new ArgumentException("soustractedValue argument shall be positive.");
			setCurrentValue(CurrentValue - soustractedValue);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sumValue">Shall be positive.</param>
		public void Increase( int sumValue ) {
			if(sumValue == 0) { return; }
			if(sumValue < 0)
				throw new ArgumentException("sumValue argument shall be positive.");
			setCurrentValue(CurrentValue + sumValue);
		}
		private void setCurrentValue( int newval ) {
			int old = CurrentValue;
			if(newval == old) { return; }
			if(newval < MinValue)
				newval = MinValue;
			if(newval > MaxValue)
				newval = MaxValue;
			_soustract = MaxValue - newval;
			if(CurrentValueChanged != null)
				CurrentValueChanged(this, old, CurrentValue);
			checkMinMax();

		}
	}
}
