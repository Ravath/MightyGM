using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.DataModel.Model
{
	/// <summary>
	/// A Collection of attributes from a specific DataEntity.
	/// </summary>
	/// <typeparam name="T">The type of the collection attributes the entity manipulates.</typeparam>
	public class AttributeCollection<T> where T : DataEntityAttribute
	{
		private DataEntity _parent;
		private List<T> _attributes = new List<T>();

		public AttributeCollection(DataEntity parentEntity)
		{
			_parent = parentEntity;
		}

		public IEnumerable<T> Attributes { get { return _attributes; } }

		public void Add(T attribute)
		{
			_attributes.Add(attribute);
			attribute.Parent = _parent;
		}

		public T GetByName(string name)
		{
			string ln = name.ToLower();
			return _attributes.SingleOrDefault<T>(a => a.Name.ToLower() == ln);
		}
	}
}
