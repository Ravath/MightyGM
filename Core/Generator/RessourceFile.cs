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
		[XmlAttribute("Path")]
		public string Path { get; set; }

		public RessourceFile()
		{

		}

		public RessourceFile(string name, string path)
		{
			Name = name;
			Path = path;
		}
		
		public override void Generation(ref GenerationResult result)
		{
			string currentPath = result.ReplaceTags(Path);
			Generator _generator = Generator.FromFile(currentPath);

			if (_generator == null)
			{
				result.ReportError(String.Format("Generator '{0}' not found at : '{1}'.", Name, currentPath));
			}
			else
			{
				result.AddText(_generator.Generate().FinalText);
			}
		}
	}
}
