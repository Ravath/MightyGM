using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map {

	public class FormalObjectGroup {
		private HashSet<FormalObject> _objs = new HashSet<FormalObject>();

		public void AddObject( FormalObject obj ) {
			if(_objs.Contains(obj)) { return; }
			_objs.Add(obj);
			obj.ParentGroup = this;
		}

		public void RemoveObject( FormalObject obj ) {
			if(!_objs.Contains(obj)) { return; }
			_objs.Remove(obj);
			obj.ParentGroup = null;
		}
		/// <summary>
		/// The specific rpg model object.
		/// </summary>
		public object RpgObject { get; set; }
	}

	public abstract class FormalObject {
		private FormalObjectGroup _group;
		public FormalObjectGroup ParentGroup {
			get { return _group; }
			set {
				if(_group == value) { return; }
				FormalObjectGroup _old = _group;
				_group = value;
				if(_old != null)
					_old.RemoveObject(this);
				if(value != null)
					value.AddObject(this);
			}
		}
	}
}
