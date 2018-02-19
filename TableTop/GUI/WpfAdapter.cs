using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework.WpfInterop;
using MonoGame.Framework.WpfInterop.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTop.GUI.Containers;

namespace TableTop.GUI
{
	public class WpfAdapter : WpfGame
	{
		private IGraphicsDeviceService graphics;
		private SpriteBatch spriteBatch;
		private Stretcher content = new Stretcher();
		private WpfKeyboard _keyboard;
		private WpfMouse _mouse;

		public GuiElement GuiContent {
			get
			{
				return content.Child;
			}
			set
			{
				content.Child = value;
			}
		}

		public IGuiApparence Apparence
		{
			get
			{
				return content.Apparence;
			}
			set
			{
				content.Apparence = value;
			}
		}

		public GraphicsDevice Graphics { get { return graphics.GraphicsDevice; } }
		public SpriteBatch SpriteBatch { get { return spriteBatch; } }

		public WpfAdapter()
		{

		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// must be initialized. required by Content loading and rendering (will add itself to the Services)
			graphics = new WpfGraphicsDeviceService(this);
			Content.RootDirectory = "Content";

			// wpf and keyboard need reference to the host control in order to receive input
			// this means every WpfGame control will have it's own keyboard & mouse manager which will only react if the mouse is in the control
			_keyboard = new WpfKeyboard(this);
			_mouse = new WpfMouse(this);

			// must be called after the WpfGraphicsDeviceService instance was created
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			//spriteBatch = new SpriteBatch(GraphicsDevice);
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
			// every update we can now query the keyboard & mouse for our WpfGame
			var mouseState = _mouse.GetState();
			var keyboardState = _keyboard.GetState();

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
