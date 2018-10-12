using CoreMono.Map;
using CoreMono.Map.Commands;
using CoreMono.Map.Sprites;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.UI
{
	public class GridPanel : Entity
	{

		Texture2D map;
		SquareGridTerrainSprite walls;
		SquareGridSprites grass;
		SquareGridTintDrawer backGround;

		MapDrawer gridMap;
		MapLayerGrid backLayer, grassLayer, wallLayer;

		public GridPanel()
		{
			gridMap = new MapDrawer(new Vector2(0, 0), Anchor.AutoCenter, new Vector2(0, 0));
			Panel panel = new Panel(new Vector2(0, 0), PanelSkin.Default, Anchor.Center);
			panel.AddChild(gridMap);
			AddChild(panel);
		}

		public void LoadContent(GraphicsDeviceManager graphics)
		{
			//load Sprites
			map = Texture2D.FromStream(graphics.GraphicsDevice, File.Open("map.png", FileMode.Open));
			walls = new SquareGridTerrainSprite(
				Texture2D.FromStream(graphics.GraphicsDevice, File.Open("TilesI_wb.png", FileMode.Open)))
			{
				Tint = Color.Green
			};
			backGround = new SquareGridTintDrawer(graphics.GraphicsDevice, Color.Purple);
			grass = new SquareGridSprites(
				Texture2D.FromStream(graphics.GraphicsDevice, File.Open("dalles.jpg", FileMode.Open)), 6, 6)
			{
				Tint = Color.White
			};

			//parametrize map for tests
			backLayer = new MapLayerGrid(20, 20, backGround);
			grassLayer = new MapLayerGrid(20, 20, grass);
			wallLayer = new MapLayerGrid(20, 20, walls);

			gridMap.SquareSize = 90;

			gridMap.AddLayer(backLayer);
			gridMap.AddLayer(grassLayer);
			gridMap.AddLayer(wallLayer);

			gridMap.SetActiveLayer(2);
			gridMap.ActiveCommand = new SquareDrawCmd();

			//preset some values
			backLayer.SetMap(true);
			grassLayer.SetMap(true);
			grassLayer.Map[1, 1] = false;
			grassLayer.Map[2, 1] = true;
			grassLayer.Map[1, 2] = true;
			wallLayer.SetMap(true);
			wallLayer.Map[1, 1] = false;
			wallLayer.Map[2, 2] = false;
			wallLayer.Map[5, 2] = true;
			wallLayer.Map[5, 3] = true;
			wallLayer.Map[5, 4] = true;
			wallLayer.Map[4, 3] = true;
		}
	}
}
