using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Framework.WpfInterop;
using System;
using System.IO;
using TableTop.GUI.Containers;
using TableTop.Map;
using TableTop.Sprites;

namespace TableTop
{
	public class MapDisplayer : WpfGame
	{
		private IGraphicsDeviceService graphics;
		private SpriteBatch spriteBatch;
		private Stretcher content = new Stretcher();

		public GraphicsDevice Graphics { get { return graphics.GraphicsDevice; } }
		public SpriteBatch SpriteBatch { get { return spriteBatch; } }

		public LayerMap Map { get; set; }

		public MapDisplayer()
		{
			graphics = new WpfGraphicsDeviceService(this);
			spriteBatch = new SpriteBatch(GraphicsDevice);
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
			Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			Map = new LayerMap(10,10);
			content.Child = Map;
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

			base.Draw(gameTime);
		}
	}
}
