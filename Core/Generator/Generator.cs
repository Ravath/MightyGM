using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public class Generator
	{
		private GenerationResult _result;

		public string Name { get; set; }
		public NodeSequence Sequence { get; set; }
		[XmlArrayItem("File", typeof(RessourceFile))]
		[XmlArrayItem("Ressource", typeof(RessourceSequence))]
		public List<AbsRessource> Ressources { get; set; }

		public Generator()
		{
			Sequence = new NodeSequence();
			Ressources = new List<AbsRessource>();
			_result = new GenerationResult(this);
		}

		public GenerationResult Generate()
		{
			_result.StartGeneration();
			Sequence.Generation(ref _result);
			_result.EndGeneration();

			return _result;
		}

		#region XML Serialization
		private static Encoding Encoding = Encoding.Unicode;

		public static Generator FromFile(string path)
		{
			Generator result;

			XmlSerializer xs = new XmlSerializer(typeof(Generator));
			using (StreamReader wr = new StreamReader(path, Encoding))
			{
				result = (Generator)xs.Deserialize(wr);
			}

			return result;
		}

		public void UseRessource(string ressourceTag, GenerationResult result)
		{
			foreach (var item in Ressources)
			{
				if(item.Name == ressourceTag)
				{
					item.Generation(ref result);
				}
			}
		}

		public static void ToFile(Generator generator, string path)
		{
			if (!path.EndsWith(".xml"))
				path += ".xml";

			XmlSerializer xs = new XmlSerializer(typeof(Generator));
			using (StreamWriter wr = new StreamWriter(path, false, Encoding))
			{
				xs.Serialize(wr, generator);
			}
		} 
		#endregion
	}
}
