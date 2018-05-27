using CoreMono.GUI.Apparences;
using CoreMono.GUI.Containers;
using CoreMono.Map.Commands;
using CoreMono.Panels;
using CoreMono.Sprites;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace CoreMono
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class MainApplication : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		DefaultConfiguration configuration;

		Panel panel;

		Texture2D map;
		SquareGridTerrainSprite walls;
		SquareGridSprites grass;
		SquareGridTintDrawer backGround;

		MapDrawer gridMap;
		MapLayerGrid backLayer, grassLayer, wallLayer;

		public MainApplication()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// GeonBit.UI: Init the UI manager using the "hd" built-in theme
			UserInterface.Initialize(Content, BuiltinThemes.hd);

			// create a panel and position in center of screen
			panel = new Panel(new Vector2(0, 0), PanelSkin.Default, Anchor.Center);
			gridMap = new MapDrawer(new Vector2(0, 0), Anchor.AutoCenter, new Vector2(0, 0));
			UserInterface.Active.AddEntity(panel);

			panel.AddChild(gridMap);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			configuration = new DefaultConfiguration(graphics, ".");

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

			backLayer = new MapLayerGrid(20, 20, backGround);
			grassLayer = new MapLayerGrid(20, 20, grass);
			wallLayer = new MapLayerGrid(20, 20, walls);

			gridMap.SquareSize = 90;

			gridMap.AddLayer(backLayer);
			gridMap.AddLayer(grassLayer);
			gridMap.AddLayer(wallLayer);

			gridMap.SetActiveLayer(2);
			gridMap.ActiveCommand = new SquareDrawCmd();

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

			//TODO implement grid drawing
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			Content.Unload();
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			UserInterface.Active.Update(gameTime);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			UserInterface.Active.Draw(spriteBatch);

			base.Draw(gameTime);
		}
	}
}
