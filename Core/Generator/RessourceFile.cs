using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public class RessourceFile : AbsRessource
	{
		private string _path;
		private Generator _generator;

		[XmlAttribute("Path")]
		public string Path
		{
			get { return _path; }
			set {
				_path = value;
				_generator = Generator.FromFile(value);
			}
		}



		public override void Generation(ref GenerationResult result)
		{
			if(_generator == null)
			{
				result.ReportError(String.Format("Generator '{0}' not found at : '{1}'.", Name, _path));
			}
			else
			{
				result.AddText(_generator.Generate().FinalText);
			}
		}

		public RessourceFile()
		{

		}

		public RessourceFile(string name, string path)
		{
			Name = name;
			Path = path;
		}
	}
}
