﻿using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Engine {

	public class TraitCollection<C,T> : AgentPart<C> , INamedCollection
			where C : class, IAgent
			where T : ITrait<C>{

		public TraitCollection(C agent): base(agent) {}

		#region Traits
		private List<T> _traits = new List<T>();

		public event SelectionChangedHandler SelectionChanged;

		public IEnumerable<T> Traits {
			get { return _traits; }
		}

		public IEnumerable<INamed> NamedCollection {
			get {
				return Traits.Cast<INamed>();
            }
		}

		public void AddTrait( T t ) {
			_traits.Add(t);
			t.AffectAgent(Agent);
			if(SelectionChanged != null)
				SelectionChanged(this);
		}
		public void RemoveTrait( T t ) {
			if(_traits.Remove(t))
				t.UnaffectAgent(Agent);
			if(SelectionChanged != null)
				SelectionChanged(this);
		}
		public void Clear() {
			foreach(var t in _traits) {
				t.UnaffectAgent(Agent);
			}
			_traits.Clear();
			if(SelectionChanged != null)
				SelectionChanged(this);
		}

		public void RemoveNamed( INamed item ) {
			RemoveTrait((T)item);
		}

		public void AddNamed( INamed item ) {
			AddTrait((T)item);
		}
		#endregion
	}
}
