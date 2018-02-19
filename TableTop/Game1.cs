using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using TableTop.GUI;
using TableTop.GUI.Apparences;
using TableTop.GUI.Containers;
using TableTop.Map;
using TableTop.Map.Commands;
using TableTop.Sprites;

namespace TableTop
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		Stretcher content = new Stretcher();
		Margin margin = new Margin(30);

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		DefaultConfiguration configuration;

		Texture2D map;
		SquareGridTerrainSprite walls;
		SquareGridSprites grass;
		SquareGridTintDrawer backGround;

		LayerMap gridMap = new LayerMap(10,10);
		LayerGrid backLayer, grassLayer, wallLayer;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			Window.ClientSizeChanged += Window_ClientSizeChanged;
			
			content.Child = margin;
			margin.Child = gridMap;
		}

		private void Window_ClientSizeChanged(object sender, EventArgs e)
		{
			content.Resize(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

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

			content.Apparence = new PlainColor(Color.SaddleBrown);
			margin.Apparence = configuration.FrameApparence;

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

			backLayer = new LayerGrid(20, 20, backGround);
			grassLayer = new LayerGrid(20, 20, grass);
			wallLayer = new LayerGrid(20, 20, walls);

			gridMap.SquareSize = 90;

			gridMap.AddLayer(backLayer);
			gridMap.AddLayer(grassLayer);
			gridMap.AddLayer(wallLayer);

			gridMap.SetActivalayer(2);
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

			content.MouseClick(Mouse.GetState());

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			content.Draw(spriteBatch);
			
			spriteBatch.Begin();
			spriteBatch.Draw(configuration.MouseSprite, new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
