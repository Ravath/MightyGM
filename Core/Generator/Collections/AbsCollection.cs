using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public abstract class AbsCollection<E> : AbsNode where E : AbsNode
	{
		protected List<E> _children = new List<E>();

		public void AddChild(E newChild)
		{
			_children.Add(newChild);
		}

		public void AddChild(params E[] newChildren)
		{
			foreach (var item in newChildren)
			{
				AddChild(item);
			}
		}

		public override void StartGeneration()
		{
			foreach (var item in _children)
			{
				item.StartGeneration();
			}
		}

		public override void EndGeneration()
		{
			foreach (var item in _children)
			{
				item.EndGeneration();
			}
		}

		public ICollection<E> GetChildren() { return _children; }

		public IEnumerable<AbsNode> GetAllChildren() {
			foreach (var item in _children)
			{
				yield return item;
			}
		}
	}
}
