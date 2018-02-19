using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.Model
{
	public class DataObject : DataEntity
	{
		public DataObject( string name ) : base(name)
		{

		}

		public DataObject Parent { get; set; }

		#region Attributes Collections
		private List<DataObjectAttribute> _modelAttributes = new List<DataObjectAttribute>();
		public IEnumerable<DataObjectAttribute> ModelAttributes { get { return _modelAttributes; } }

		public void AddModelAttribute(DataObjectAttribute modelAttribute)
		{
			_modelAttributes.Add(modelAttribute);
		}


		private List<DataObjectAttribute> _exemplarAttributess = new List<DataObjectAttribute>();
		public IEnumerable<DataObjectAttribute> ExemplarAttributes { get { return _exemplarAttributess; } }

		public void AddExemplarAttribute(DataObjectAttribute exemplarAttributes)
		{
			_exemplarAttributess.Add(exemplarAttributes);
		}


		private List<DataObjectAttribute> _descriptionAttributes = new List<DataObjectAttribute>();
		public IEnumerable<DataObjectAttribute> DesciptionAttributes { get { return _descriptionAttributes; } }

		public void AddDescriptionAttribute(DataObjectAttribute descriptionAttribute)
		{
			_descriptionAttributes.Add(descriptionAttribute);
		} 
		#endregion
	}

	public abstract class DataObjectAttribute : DataAttribute
	{
		public string TypeName { get; protected set; }
		public bool CanBeNull { get; set; }
		public bool IsCollection { get; set; }

		public DataObjectAttribute(string name) : base(name) { }
	}
}
