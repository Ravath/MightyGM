using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.CSharp
{
	/// <summary>
	/// A Collection of CSAnnotations.
	/// </summary>
	public class CSAnnotationCollection
	{
		#region Members
		private List<CSAnnotation> _annotations = new List<CSAnnotation>();
		#endregion
		#region Collection Annotations
		public IEnumerable<CSAnnotation> Annotations
		{
			get
			{
				return _annotations;
			}
		}
		public void AddAnnotation(CSAnnotation anno)
		{
			_annotations.Add(anno);
		}
		public void AddAnnotation(string annoName)
		{
			_annotations.Add(new CSAnnotation() { Name = annoName });
		}

		public bool RemoveAnnotation(CSAnnotation anno)
		{
			return _annotations.Remove(anno);
		}
		#endregion

		public void CreateString(StringBuilder sb, IndentationCount indentation)
		{
			foreach (CSAnnotation annot in Annotations)
			{
				annot.CreateString(sb, indentation);
				sb.AppendLine();
			}
		}
	}
}
