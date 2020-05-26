using Core.Data;
using CoreMono;
using CoreMono.UI;
using GeonBit.UI.DataTypes;
using GeonBit.UI.Entities;
using GeonBit.UI.Entities.TextValidators;
using LinqToDB.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI.Utils;

namespace TableTop.UI
{
	public class RessourcesPanel : Entity
	{

		private bool _tagDelegationDone = false;

		private PanelBase researchPane;
		private PanelBase visualizationPane;
		private TwoListsSelector<Tag> tagsList = new TwoListsSelector<Tag>(Vector2.Zero);
		private TrackPanel musicPlayerPane = new TrackPanel(null, Vector2.Zero);
		/// <summary>
		/// Keyboard previous state, for preventing key flooding.
		/// </summary>
		KeyboardState previousState;

		private SelectList listResearchView = new SelectList(Vector2.Zero) { Scale = 0.8f };
		//TODO
		private Entity miniResearchView = new PanelBase(Vector2.Zero);

		//Filter buttons
		private Button filterImagesButton;
		private Button filterSoundsButton;
		private Button filterTextsButton;
		private Button filterMiscButton;

		public RessourcesPanel(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			const int buttonHeight = 50;
			const float leftSizeRatio = 0.5f;
			const float visualizationHeightRatio = 0.6f;
			Vector2 buttonSize = new Vector2(250, buttonHeight);
			Vector2 halfButtonSize = new Vector2(250/2, buttonHeight);

			//Create menu
			var layout = new SimpleFileMenu.MenuLayout();
			layout.AddMenu("DB", 260);
			layout.AddItemToMenu("DB", "Add DB", On_addDb);
			layout.AddItemToMenu("DB", "Add Tag", On_addTag);
			//TODO
			layout.AddItemToMenu("DB", "Refresh", () => { GeonBit.UI.Utils.MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("DB", "Rename Tag", () => { GeonBit.UI.Utils.MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("DB", "Merge Tags", () => { GeonBit.UI.Utils.MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("DB", "Remove Tag", () => { GeonBit.UI.Utils.MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			var fileMenu = SimpleFileMenu.Create(layout);
			fileMenu.Anchor = Anchor.Auto;

			// Special Filter buttons on the menu
			PanelBase filterPanel = new PanelBase(new Vector2(0.5f, 0f), PanelSkin.None, Anchor.CenterRight) { Padding = Vector2.Zero };
			Button selViewButton = new Button("View", ButtonSkin.Default, Anchor.AutoInline) { Size = buttonSize, ToggleMode = true };
			filterImagesButton = new Button("Img", ButtonSkin.Default, Anchor.AutoInline) { Size = halfButtonSize, ToggleMode = true, Checked = true };
			filterSoundsButton = new Button("Snd", ButtonSkin.Default, Anchor.AutoInline) { Size = halfButtonSize, ToggleMode = true, Checked = true };
			filterTextsButton = new Button("Txt", ButtonSkin.Default, Anchor.AutoInline) { Size = halfButtonSize, ToggleMode = true, Checked = true };
			filterMiscButton = new Button("Misc", ButtonSkin.Default, Anchor.AutoInline) { Size = halfButtonSize, ToggleMode = true, Checked = false };
			filterPanel.Padding = new Vector2((fileMenu.Size.Y - buttonHeight) / 2);

			// Results visualization
			PanelBase resultPanel = new PanelBase(Vector2.Zero, PanelSkin.None, Anchor.Auto) { Padding = Vector2.Zero };
			researchPane = new PanelBase(new Vector2(leftSizeRatio, 0f), PanelSkin.None, Anchor.AutoInline) { Padding = Vector2.Zero };
			visualizationPane = new PanelBase(new Vector2(1f - leftSizeRatio, visualizationHeightRatio), PanelSkin.None, Anchor.TopRight) { Padding = Vector2.Zero };
			PanelBase tagPane = new PanelBase(new Vector2(1f - leftSizeRatio, 1 - visualizationHeightRatio), PanelSkin.None, Anchor.BottomRight) { Padding = Vector2.Zero };

			// LINK PANELS
			AddChild(fileMenu);
			AddChild(resultPanel);

			fileMenu.AddChild(filterPanel);
			filterPanel.AddChild(selViewButton);
			filterPanel.AddChild(filterImagesButton);
			filterPanel.AddChild(filterSoundsButton);
			filterPanel.AddChild(filterTextsButton);
			filterPanel.AddChild(filterMiscButton);

			resultPanel.AddChild(researchPane);
			resultPanel.AddChild(visualizationPane);
			resultPanel.AddChild(tagPane);
			tagPane.AddChild(tagsList);

			//init reseach view
			On_selView(selViewButton);

			//ADD EVENTS
			selViewButton.OnClick = On_selView;
			listResearchView.OnValueChange = On_selectedRessourceByList;
			listResearchView.BeforeUpdate = ResultList_keys;
			filterImagesButton.OnClick = (Entity e) => { UpdateResearch(); UpdateResearchView(); };
			filterSoundsButton.OnClick = (Entity e) => { UpdateResearch(); UpdateResearchView(); };
			filterTextsButton.OnClick =  (Entity e) => { UpdateResearch(); UpdateResearchView(); };
			filterMiscButton.OnClick =   (Entity e) => { UpdateResearch(); UpdateResearchView(); };
			//TODO : idem for minis

			UpdateResearch();
			UpdateResearchView();

			// Specific calculus for adjusting the resultPanel to the parent
			BeforeUpdate = (e) =>
			{
				resultPanel.Size = new Vector2(0f, _destRectInternal.Height - fileMenu.GetActualDestRect().Height);
			};
		}

		private void On_addTag()
		{
			var textInput = new TextInput(false)
			{
				Validators = new List<ITextValidator>() { new SlugValidator() }
			};
			var textError = new Label("")
			{
				FillColor = Color.Red
			};
			var mess = GeonBit.UI.Utils.MessageBox.ShowMsgBox("New Tag Creation", "Tag Name:", new GeonBit.UI.Utils.MessageBox.MsgBoxOption[]
			{
				new GeonBit.UI.Utils.MessageBox.MsgBoxOption("OK", () => {
					bool isok = MainApplication.Controler.CoreData.AddNewTag(textInput.Value, false, out string errMess);
					textError.Text = errMess;
					return isok;
				}),
				new GeonBit.UI.Utils.MessageBox.MsgBoxOption("Cancel", () => { return true; }),
			}, new Entity[] { textInput, textError }
			);
		}

		/// <summary>
		/// Manage Up/Down selection in list.
		/// </summary>
		/// <param name="entity"></param>
		private void ResultList_keys(Entity entity)
		{
			int nbrItems = listResearchView.Items.Count();
			if (nbrItems == 0 || previousState == null) { previousState = Keyboard.GetState(); return; }
			

			// Poll for current keyboard state
			KeyboardState state = Keyboard.GetState();

			int newValue = listResearchView.SelectedIndex;
			if (state.IsKeyDown(Keys.Up) && !previousState.IsKeyDown(Keys.Up))
			{
				newValue -= 1;
				listResearchView.SelectedIndex = (newValue + nbrItems) % nbrItems;
			}
			if (state.IsKeyDown(Keys.Down) && !previousState.IsKeyDown(Keys.Down))
			{
				newValue += 1;
				listResearchView.SelectedIndex = (newValue + nbrItems) % nbrItems;
			}
			previousState = Keyboard.GetState();
		}

		private RawRessource _selectedRessource;
		public RawRessource GetSelectedRessource()
		{
			return _selectedRessource;
		}

		private void On_selectedRessourceByList(Entity entity)
		{
			if(listResearchView.SelectedIndex != -1)
			{
				_selectedRessource = MainApplication.Controler.CoreData.GetRessources().ElementAt(listResearchView.SelectedIndex);
			}
			else
			{
				_selectedRessource = null;
			}
			UpdateSelectedVizualization();
		}

		private void On_addDb()
		{
			var folder = MainApplication.Controler.Files.GetFolder(false, out string message, out bool success);
			if (success)
			{
				SetDB(folder);
				UpdateResearchView();
			}
			else
			{
				//TODO : Display error message
			}
		}

		private void On_selView(Entity btn)
		{
			Button selView = (Button)btn;
			researchPane.ClearChildren();
			if (selView.Checked)
			{
				researchPane.AddChild(listResearchView);
			}
			else
			{
				researchPane.AddChild(miniResearchView);
			}
			UpdateResearchView();
		}

		public void SetDB(DirectoryInfo dr)
		{
			MainApplication.Controler.CoreData.ImportNewDb(dr);
			UpdateResearch();
		}

		private Boolean updateList = false;
		private Boolean updateMini = false;
		public void UpdateResearch()
		{
			MainApplication.Controler.CoreData.GetPictures = filterImagesButton.Checked;
			MainApplication.Controler.CoreData.GetSounds = filterSoundsButton.Checked;
			MainApplication.Controler.CoreData.GetTexts = filterTextsButton.Checked;
			MainApplication.Controler.CoreData.GetMiscs = filterMiscButton.Checked;
			updateList = true;
			updateMini = true;
		}

		public void UpdateResearchView()
		{
			if (listResearchView.Parent != null && updateList)
			{
				listResearchView.ClearItems();

				listResearchView.AddItem(
					MainApplication.Controler.CoreData.GetRessources()
					.Select(item=>MgFont.Clean(item.Name)));

				updateList = false;
			}
			else if(miniResearchView.Parent != null && updateMini)
			{
				//TODO miniResearchView.ClearItems();
				//TODO refresh miniResearchView
				updateMini = false;
			}
		}
		

		private void UpdateSelectedVizualization()
		{
			RawRessource visualizedRes = GetSelectedRessource();
			if (visualizedRes == null)
			{
				tagsList.OnAddedItem -= OnTagsUpdated;
				tagsList.OnRemovedItem -= OnTagsUpdated;
				_tagDelegationDone = false;
				return;
			}

			FileInfo visualizedResInfo = visualizedRes.Info;
			visualizationPane.ClearChildren();

			// Check if File still valid
			if (!visualizedResInfo.Exists)
			{
				visualizationPane.AddChild(new Paragraph("Can't find " + visualizedResInfo.FullName));
			}
			// Picture visualisation
			else if (visualizedRes.RessourceType == RawRessourceType.Picture)
			{
				Texture2D tex = GetTexture(visualizedResInfo);
				Image img = new Image(tex) { Anchor = Anchor.Center };

				//Adapt image size to destination
				Rectangle destSize = visualizationPane.CalcDestRect();
				float texRatio = (float)tex.Width / (float)tex.Height;
				float destRatio = (float)destSize.Width / (float)destSize.Height;
				if (texRatio > destRatio)
				{//more wide than height
					img.Size = new Vector2(destSize.Width, destSize.Width / texRatio);
				}
				else
				{//more height than wide
					img.Size = new Vector2(destSize.Height * texRatio, destSize.Height);
				}

				visualizationPane.AddChild(img);
			}
			// Music visualisation
			else if (visualizedRes.RessourceType == RawRessourceType.Soundtrack)
			{
				musicPlayerPane.Track = MainApplication.Controler.Audio.Open(visualizedRes);
				musicPlayerPane.Play();
				visualizationPane.AddChild(musicPlayerPane);
			}
			// TODO : Text visualisation
			//else if (visualizedRes.RessourceType == RawRessourceType.Text)
			//{
			//	FileStream fs = visualizedResInfo.Open(FileMode.Open);
			//	string  text = System.IO.File.ReadAllText(visualizedResInfo.FullName);
			//	visualizationPane.AddChild(new Paragraph(text));
			//}
			// Default visualisation
			else
			{
				visualizationPane.AddChild(new Paragraph(visualizedResInfo.FullName));
			}

			// update tag lists
			tagsList.LoadSet(MainApplication.Controler.CoreData.GetTags());
			tagsList.LoadSelection(visualizedRes.Tags);
			if (!_tagDelegationDone)
			{
				tagsList.OnAddedItem += OnTagsUpdated;
				tagsList.OnRemovedItem += OnTagsUpdated;
				_tagDelegationDone = true;
			}
		}

		private Texture2D GetTexture(FileInfo file)
		{
			return Texture2D.FromStream(MainApplication.graphics.GraphicsDevice, file.OpenRead());
		}

		private void OnTagsUpdated(TwoListsSelector<Tag> entity, Tag updatedItem)
		{
			//TODO after "Tag Creation" completed, investigate a problem with the tag jointure table update.
			RawRessource selected = GetSelectedRessource();
			selected.Tags = entity.GetCurrentSelection();
			selected.SaveObject();
		}

		private void StopMusic()
		{
			musicPlayerPane.Track?.Dispose();
			musicPlayerPane.Track = null;
		}
	}
}
