using CoreMono.UI;
using GeonBit.UI;
using GeonBit.UI.Entities;
using GeonBit.UI.Entities.TextValidators;
using GeonBit.UI.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MightyGmCtrl;
using System;
using System.Collections.Generic;
using System.IO;
using TableTop.UI;

namespace CoreMono
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class MainApplication : Game
	{
		public static float ActualScale { get { return 1f / UserInterface.Active.GlobalScale; } }
		public static Context Controler;
		public static DefaultConfiguration configuration;
		public static GraphicsDeviceManager graphics;
		public static MainApplication inst;
		SpriteBatch spriteBatch;

		// THE PANELS
		public TablePanel TableControl { get; private set; }
		public JdrPanel JdrControl { get; private set; }
		public RessourcesPanel ResControl { get; private set; }
		public FichePanel FicheControl { get; private set; }
		public OptionPanel OptionControl { get; private set; }
		// TODO : test panels
		public ImagePanel ImageControl { get; private set; }

		public MainApplication()
		{
			// Initialize Controler
			Controler = Context.MightyGmContext("Mono");
			Controler.ReportManager.EndOfProcessEvent += EndOfProcessReport;

			// Initialize graphics
			graphics = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
				PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
			};

			// Configure
			//graphics.ToggleFullScreen();
			Content.RootDirectory = "Content";

			// Register Exit Event
			Exiting += (object sender, EventArgs e) => { Controler.Exit(); };

			// init static access
			inst = this;
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
			UserInterface.Active.UseRenderTarget = true;
			UserInterface.Active.GlobalScale = 1f;
			UserInterface.Active.GenerateTooltipFunc = GenerateTooltipFunc;
			UserInterface.TimeToShowTooltipText = 1f;

			//Decomment for debug drawing assistance
			//UserInterface.Active.DebugDraw = true;

			TableControl = new TablePanel();
			JdrControl = new JdrPanel();
			ResControl = new RessourcesPanel();
			//ImageControl = new ImagePanel();
			FicheControl = new FichePanel();
			OptionControl = new OptionPanel();

			//// SW shortcut
			//if (JdrControl.JdrCount == 1)
				JdrControl.JdrIndex = 0;

			//UserInterface.Active.AddEntity(tabPanel);
			//UserInterface.Active.AddEntity(TableControl);
			ReturnToTable();

			base.Initialize();
		}

		public void ReturnToTable()
		{
			UserInterface.Active.Clear();
			UserInterface.Active.AddEntity(TableControl);
		}

		internal void SetExitableView(Entity view)
		{
			UserInterface.Active.Clear();
			UserInterface.Active.AddEntity(view);
			UserInterface.Active.AddEntity(new Button("X", anchor: Anchor.TopLeft, size: new Vector2(50))
			{
				Padding = Vector2.Zero,
				OnClick = (e) => { ReturnToTable(); }
			});
		}

		internal void ChooseRpgView()
		{
			SetExitableView(JdrControl);
		}

		internal void RessourceView()
		{
			SetExitableView(ResControl);
		}

		internal void FicheView()
		{
			SetExitableView(FicheControl);
		}

		internal void OptionView()
		{
			SetExitableView(OptionControl);
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			configuration = new DefaultConfiguration(graphics, ".");
			MgFont.SpriteFont = Resources.Fonts[(int)0];
			foreach (var font in Resources.Fonts)
			{
				font.DefaultCharacter = ' ';
			}
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
			// Exit if asked
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// Nominal Processing
			UserInterface.Active.Update(gameTime);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			// Clear Graphics
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// Drawing Graphics
			UserInterface.Active.Draw(spriteBatch);

			// use `UserInterface.Active.RenderTarget` here.
			// in this example we call DrawMainRenderTarget(), which will draw the UserInterface.Active.RenderTarget on the currently set target (or backbuffer if non is set)
			UserInterface.Active.DrawMainRenderTarget(spriteBatch);

			base.Draw(gameTime);
		}

		/// <summary>
		/// Displays an "EndofProcess" Event.
		/// </summary>
		/// <param name="procName">The name of the ended process.</param>
		/// <param name="success">The ended process finishing state.</param>
		public void EndOfProcessReport(string procName, bool success)
		{
			if (success)
			{
				GeonBit.UI.Utils.MessageBox.ShowMsgBox(procName, "Operation Finished With Success");
			}
			else
			{
				GeonBit.UI.Utils.MessageBox.ShowMsgBox(procName, "Operation Failed");
			}
		}
		
		/// <summary>
		/// Override function used to generate tooltip text entities.
		/// </summary>
		/// <param name="source">Source entity.</param>
		/// <returns>Entity to use for tooltip text.</returns>
		static private Entity GenerateTooltipFunc(Entity source)
		{
			// no tooltip text? return null
			if (source.ToolTipText == null) return null;

			// create tooltip paragraph
			var tooltip = new Paragraph(source.ToolTipText, size: new Vector2(700, -1))
			{
				BackgroundColor = Color.Black,
				Scale = source.ToolTipText.Length>100?0.8f : 1.0f
			};

			// add callback to update tooltip position
			tooltip.BeforeDraw += (Entity ent) =>
			{
				// get dest rect and calculate tooltip position based on size and mouse position
				var destRect = tooltip.GetActualDestRect();
				var position = UserInterface.Active.GetTransformedCursorPos(new Vector2(-destRect.Width / 2, -destRect.Height - 20));

				// make sure tooltip is not out of screen boundaries
				var screenBounds = UserInterface.Active.Root.GetActualDestRect();
				if (position.Y < screenBounds.Top) position.Y = screenBounds.Top;
				if (position.Y > screenBounds.Bottom - destRect.Height) position.Y = screenBounds.Bottom - destRect.Height;
				if (position.X < screenBounds.Left) position.X = screenBounds.Left;
				if (position.X > screenBounds.Right - destRect.Width) position.X = screenBounds.Right - destRect.Width;

				// update tooltip position
				tooltip.SetAnchorAndOffset(Anchor.TopLeft, position / UserInterface.Active.GlobalScale);
			};
			tooltip.CalcTextActualRectWithWrap();
			tooltip.BeforeDraw(tooltip);

			// return tooltip object
			return tooltip;
		}
	}
}
