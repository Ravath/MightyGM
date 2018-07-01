using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Core.Contexts;
using Core.Data;

namespace MightyGmCtrl.Controleurs
{
	public class Textures : Controleur
	{
		public String TexturesDirectory { get { return GlobalContext.Files.TexturesDirectory; } }

		public Textures(Context context) : base(context) {}

		private Boolean GetPath(ref String relPath)
		{
			if (relPath == null)
				return false;
			if (!relPath.StartsWith("\\"))
			{
				relPath = "\\" + relPath;
			}
			relPath = TexturesDirectory + relPath;
			return File.Exists(relPath);
		}

		public BitmapImage LoadImage(string relPath)
		{
			if (!GetPath(ref relPath)) {
				ReportMessageRef(MessageType.WARNING,"RESSOURCE_NOT_FOUND", relPath);
				return null;
			}
			BitmapImage bi = new BitmapImage();
			bi.BeginInit();
			bi.UriSource = new Uri(relPath);
			bi.EndInit();
			return bi;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="selectedTexture"></param>
		/// <param name="chosenImage"></param>
		/// <returns>False if a file Texture directory has to be replaced by new file. The Data has not been added to DB, and file has not been moved.</returns>
		public Boolean AddToDatabase(Image selectedTexture, FileInfo chosenImage)
		{
			//TODO use filePath, distinct from Name
			Boolean copy = false;
			Boolean alreadyExists = false;
			//if not in the textures directory, copy in Textures diretory
			DirectoryInfo destDirectory = new DirectoryInfo(TexturesDirectory);
			if (chosenImage.Directory.FullName != destDirectory.FullName)
			{
				copy = true;
			}
			//if texture name is specified and different, copy with new name
			if(String.IsNullOrWhiteSpace(selectedTexture.Name))
			{
				selectedTexture.Name = chosenImage.Name;
			}
			else if (selectedTexture.Name != chosenImage.Name)
			{
				// check extension compatibility
				FileInfo fi = new FileInfo(selectedTexture.Name);
				if (String.IsNullOrWhiteSpace(fi.Extension))
				{
					selectedTexture.Name += chosenImage.Extension;
				}
				else if(fi.Extension != chosenImage.Extension)
				{
					selectedTexture.Name = selectedTexture.Name.Replace(fi.Extension, chosenImage.Extension);
				}
				copy = true;
			}
			//copy if needed
			if (copy)
			{
				//Check if file already exists
				String destination = TexturesDirectory + "\\" + selectedTexture.Name;
				if (!File.Exists(destination))
				{
					chosenImage.CopyTo(destination);
				}
				else
				{
					alreadyExists = true;
				}
			}
			//update database
			if (!alreadyExists)
			{
				GlobalContext.Data.Insert(selectedTexture);
			}
			return !alreadyExists;
		}
	}
}