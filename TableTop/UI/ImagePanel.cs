using CoreMono;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.UI
{
	public class ImagePanel : Entity
	{
		Button addFiles = new Button("Add");
		PictGrid pg = new PictGrid();

		public ImagePanel()
		{
			AddChild(addFiles);
			AddChild(pg);
			addFiles.OnClick = (Entity e) =>
			{
				var files = MainApplication.Controler.Files.GetPictFiles(out string message, out bool success);
				if (success)
				{
					LoadPicts(files);
				}
				else
				{
					//TODO
				}
			};
		}

		public void LoadPicts(FileInfo[] picts)
		{
			Texture2D[] tex = new Texture2D[picts.Length];
			for (int i = 0; i < picts.Length; i++)
			{
				tex[i] = Texture2D.FromStream(MainApplication.graphics.GraphicsDevice, picts[i].Open(FileMode.Open));
				string name = picts[i].Name;
				tex[i].Name = name.Remove(name.Length - picts[i].Extension.Length, picts[i].Extension.Length);
			}
			pg.SetPictures(tex);
		}
	}
}
