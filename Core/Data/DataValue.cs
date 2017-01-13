using System;
using System.Reflection;

namespace Core.Data {
	public interface IDataValue : IDataObject {
		DataObject From { get; set; }
		int FromId { get; set; }
		Type FromType { get; }
		PropertyInfo FromProperty { get; }

		object Value { get; set; }
		Type ValueType { get; }
		PropertyInfo ValueProperty { get; }
	}

	public class DataValue<F,V> : DataObject, IDataValue where F : DataObject{
		private F _from;
		public F From {
			get {
				if(_from == null) {
					_from = LoadById<F>(FromId);
				}
				return _from;
			}
			set {
				if(value == _from) { return; }
				_from = value;
				if(_from != null) {
					FromId = _from.Id;
				}
			}
		}

		public int FromId { get; set; }

		public V Value { get; set; }

		public Type ValueType { get { return typeof(V); } }
		public Type FromType { get { return typeof(F); } }

		object IDataValue.Value {
			get { return Value; }
			set { Value = (V)value; }
		}

		public PropertyInfo ValueProperty {
			get { return GetType().GetProperty("Value"); }
		}

		public PropertyInfo FromProperty {
			get { return GetType().GetProperty("From"); }
		}

		DataObject IDataValue.From {
			get { return From; }
			set { From = (F)value; }
		}
	}
}
