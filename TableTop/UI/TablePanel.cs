using CoreMono;
using CoreMono.Map;
using CoreMono.Map.Commands;
using CoreMono.Map.Sprites;
using CoreMono.TableTop;
using CoreMono.TableTop.Graph;
using CoreMono.TableTop.Graph.Shape;
using CoreMono.TableTop.Grid;
using CoreMono.TableTop.Grid.Shape;
using CoreMono.TableTop.Token;
using CoreMono.TableTop.Token.Shape;
using CoreMono.UI;
using GeonBit.UI.Entities;
using GeonBit.UI.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.UI
{
	public class TablePanel : Entity
	{
		private Entity _propertiesPanel;
		private Entity _tabletopPanel;
		private SelectList _layersList;
		private PropertyDisplay _displayer;

		TableMap map = new TableMap(Vector2.Zero, Anchor.Center, Vector2.Zero);
		public int ColumnWidth { get; set; } = 10;
		public int RowWidth { get; set; } = 10;
		public int SquareSize { get; set; } = 80;

		public TablePanel()
		{
			const int layersWidth = 80;
			Padding = Vector2.Zero;

			//Create menu
			var layout = new SimpleFileMenu.MenuLayout();
			layout.AddMenu("General", 260);
			layout.AddItemToMenu("General", "Ressources", () => { MainApplication.inst.RessourceView(); });
			layout.AddItemToMenu("General", "Joueurs", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("General", "Proprietes", () => { MainApplication.inst.OptionView(); });
			layout.AddMenu("Rpg", 260);
			layout.AddItemToMenu("Rpg", "Choisir", () => { MainApplication.inst.ChooseRpgView(); });
			layout.AddItemToMenu("Rpg", "Fiches", () => { MainApplication.inst.FicheView(); });
			layout.AddItemToMenu("Rpg", "Livres", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Rpg", "Proprietes", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddMenu("Map", 260);
			layout.AddItemToMenu("Map", "Creer Map", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Map", "Creer Donjon", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Map", "Proprietes", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Map", "Export", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddMenu("Scenario", 260);
			layout.AddItemToMenu("Scenario", "Nouveau", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Scenario", "Charger", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Scenario", "Groupe", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Scenario", "Notes?", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Scenario", "Start/End Sceance", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			layout.AddItemToMenu("Scenario", "Proprietes", () => { MessageBox.ShowMsgBox("Not Yet", "This function has not been implemented."); });
			var manuPanel = SimpleFileMenu.Create(layout);

			// Create Layer Creation menu
			SelectList newLayerList = new SelectList(new Vector2(250,200), Anchor.TopLeft, new Vector2(layersWidth, 0)) { Visible = false };
			newLayerList.OnValueChange = (e) => {
				// Create layer of the selected type
				if (newLayerList.SelectedIndex >= 0) { AddLayer(newLayerList.SelectedIndex); }
				// Reset Menu
				newLayerList.SelectedIndex = -1;
				newLayerList.Visible = false;
			};
			newLayerList.AddItem(layerNames);

			// Button for displaying the layerList creation
			Button newLayerButton = new Button("+")
			{
				Size = new Vector2(layersWidth),
				Padding = Vector2.Zero,
				OnClick = (e) => { newLayerList.Visible = !newLayerList.Visible; }
			};

			// Containers panels
			PanelBase mainPanel = new PanelBase() { Skin = PanelSkin.None, Anchor = Anchor.BottomCenter, Padding = Vector2.Zero };
			PanelBase layersBoxPanel = new PanelBase(new Vector2(layersWidth, 0), PanelSkin.None, Anchor.CenterLeft) { Padding = Vector2.Zero };

			// Control panels
			_propertiesPanel = new PanelBase(new Vector2(300, 0)) { Anchor = Anchor.AutoInline, Padding = Vector2.Zero };
			_tabletopPanel = new PanelBase() { Anchor = Anchor.AutoInline };
			_displayer = new PropertyDisplay();
			// Create list of map layers
			_layersList = new SelectList(new Vector2(0f, 0), Anchor.BottomCenter);
			_layersList.OnValueChange = (e) => {
				SelectLayer(_layersList.Children.Count - _layersList.SelectedIndex -1);
			};

			// Assembly

			_propertiesPanel.AddChild(_displayer);

			layersBoxPanel.AddChild(newLayerButton);
			layersBoxPanel.AddChild(newLayerList);
			layersBoxPanel.AddChild(_layersList);

			_tabletopPanel.AddChild(map);
			_tabletopPanel.AddChild(layersBoxPanel);

			mainPanel.AddChild(_propertiesPanel);
			mainPanel.AddChild(_tabletopPanel);

			AddChild(manuPanel);
			AddChild(mainPanel);

			// Specific calculus for adjusting the Panels to the parent

			BeforeUpdate = (e) =>
			{
				mainPanel.Size = new Vector2(0f, e.GetActualDestRect().Height - manuPanel.GetActualDestRect().Height);
			};
			mainPanel.BeforeUpdate = (e) =>
			{
				_tabletopPanel.Size = new Vector2(e.GetActualDestRect().Width - _propertiesPanel.GetActualDestRect().Width, 0f);
			};
			layersBoxPanel.BeforeUpdate = (e) =>
			{
				_layersList.Size = new Vector2(0f, e.GetActualDestRect().Height - newLayerButton.GetActualDestRect().Height);
			};
		}

		private string[] layerNames = {"Grid", "Graph"};
		private void AddLayer(int selectedIndex)
		{
			TableLayer newLayer;
			Color tint = map.LayerCount < 1 ? Color.Green : Color.Red;//TODO this is debug
			switch (selectedIndex)
			{
				case 0:
					//TODO this is test
					IGridShape texture = new GridComputedSprite(
						   Texture2D.FromStream(MainApplication.graphics.GraphicsDevice, File.OpenRead("TilesI_wb.png"))) { Tint = tint };
					GridLayer gl = new GridLayer(ColumnWidth, RowWidth, texture, SquareSize);
					newLayer = gl;
					break;
				case 1:
					//TODO this is test
					IEdgeShape defaultEdgeShape = new PlainLineShape()
					{
						Width = 2,
						Tint = Color.Green,
						Shape = LineShapeE.Straight
					};
					ITokenShape defaultTokenShape = new GeometricShape()
					{
						BackgroundTint = Color.Orange,
						WidthTint = Color.Red,
						Width = 1,
					};
					GraphLayer gh = new GraphLayer(defaultTokenShape, defaultEdgeShape);
					Token t1 = new Token() { Offset = new Vector2(10, 10), Size = new Vector2(25) };
					Token t2 = new Token() { Offset = new Vector2(60, 30), Size = new Vector2(25) };
					Token t3 = new Token() { Offset = new Vector2(80, 20), Size = new Vector2(25) };
					gh.AddToken(t1);
					gh.AddToken(t2);
					gh.AddToken(t3);
					gh.Bound(t1, t2);
					gh.Bound(t2, t3);
					newLayer = gh;
					break;
				default:
					MessageBox.ShowMsgBox("Not Yet", "This layer has not been implemented. Index=" + selectedIndex);
					return;
			}
			map.AddLayer(newLayer);

			_layersList.AddItem(map.LayerCount+"", 0);
			_layersList.AllowReselectValue = true;
			_layersList.SelectedIndex = 0;
			_layersList.AllowReselectValue = false;
		}

		private void SelectLayer(int index)
		{
			index = index < 0 ? 0 : index;
			index = index >= map.LayerCount ? map.LayerCount - 1 : index;

			map.SetActiveLayer(index);

			map.GetActiveLayer<TableLayer>().DisplayProperties(_displayer);
		}
	}
}
