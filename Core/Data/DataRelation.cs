using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data {
	public interface IDataRelation : IDataObject {
		DataObject Object1 { get; set; }
		DataObject Object2 { get; set; }
		int Object1Id { get; set; }
		int Object2Id { get; set; }
		Type Obj1Type { get; }
		Type Obj2Type { get; }
		PropertyInfo Property1 { get; }
		PropertyInfo Property2 { get; }

		DataObject GetOther( DataObject _obj );
	}
	/// <summary>
	/// Représente une table relationnelle
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="U"></typeparam>
	public class DataRelation<T,U> : DataObject, IDataRelation
												where T : DataObject 
												where U : DataObject {
		public DataRelation() : base() { }
		public DataRelation(T obj1, U obj2) : base() {
			Object1 = obj1;
			Object2 = obj2;
		}
		public Type Obj1Type {
			get {
				return typeof(T);
			}
		}
		public Type Obj2Type {
			get {
				return typeof(U);
			}
		}
		public int Object1Id { get; set; }
		private T _object1;
		public T Object1 {
			get {
				if(_object1 == null) {
					_object1 = LoadById<T>(Object1Id);
				}
				return _object1;
			}
			set {
				if(value == _object1) { return; }
				_object1 = value;
				if(_object1 != null) {
					Object1Id = _object1.Id;
				}
			}
		}

		public int Object2Id { get; set; }
		private U _object2;
		public U Object2 {
			get {
				if(_object2 == null) {
					_object2 = LoadById<U>(Object2Id);
				}
				return _object2;
			}
			set {
				if(value == _object2) { return; }
				_object2 = value;
				if(_object2 != null) {
					Object2Id = _object2.Id;
				}
			}
		}

		DataObject IDataRelation.Object1 {
			get {
				return Object1;
			}
			set {
				Object1 = (T)value;
			}
		}

		DataObject IDataRelation.Object2 {
			get {
				return Object2;
			}
			set {
				Object2 = (U)value;
			}
		}

		public PropertyInfo Property1 {
			get {
				return GetType().GetProperty("Object1");
			}
		}

		public PropertyInfo Property2 {
			get {
				return GetType().GetProperty("Object2");
			}
		}

		public override string ToString() {
			return String.Format("{0}-<{1};{2}>", Id, Object1.ToString(), Object2.ToString());
		}

		public DataObject GetOther( DataObject _obj ) {
			if(_obj.GetType() == Object1.GetType() && _obj.Id == Object1.Id)
				return Object2;
			return Object1;
		}
	}
}
