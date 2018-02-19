using Core.Gestion.Sprites;
using CoreWpf.Dialogs;
using MightyGmCtrl;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TableTop.GUI;
using TableTop.GUI.Apparences;

namespace MightyGmWPF.Tabs.Ressources
{
	/// <summary>
	/// Logique d'interaction pour WrkSprites.xaml
	/// </summary>
	public partial class WrkSprites : UserControl
	{
		private SpriteData _selectedSprite;
		private int _editedId;

		public Context Context { get; }
		public WrkSprites(Context context)
		{
			InitializeComponent();
			Context = context;
			UpdateList();
			EnterReadMode();
		}

		private void SetSelection(SpriteData newSel)
		{
			_selectedSprite = newSel;
			xFiche.SelectedObject = newSel;
			BitmapSource img = Context.Textures.GetImageFromSprite(_selectedSprite);
			xDisplay.Background = new ImageBrush(img);
		}

		private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListView lv = sender as ListView;
			SetSelection(lv.SelectedItem as SpriteData);
		}

		private void UpdateList()
		{
			xList.ItemsSource = Context.Data.GetTable<SpriteData>();
			xList.SelectedItem = null;
		}

		private void EnterEditMode()
		{
			xFiche.ReadOnly = false;
			xButtons1.Visibility = Visibility.Collapsed;
			xButtons2.Visibility = Visibility.Collapsed;
			xButtons3.Visibility = Visibility.Visible;
			_editedId = _selectedSprite.Id; ;
	}

	private void EnterReadMode()
		{
			xFiche.ReadOnly = true;
			xButtons1.Visibility = Visibility.Visible;
			xButtons2.Visibility = Visibility.Collapsed;
			xButtons3.Visibility = Visibility.Collapsed;
		}

		private void EnterCreateMode()
		{
			xFiche.ReadOnly = false;
			xButtons1.Visibility = Visibility.Collapsed;
			xButtons2.Visibility = Visibility.Visible;
			xButtons3.Visibility = Visibility.Collapsed;
		}

		private void ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedSprite != null)
			{
				Context.Data.Delete(_selectedSprite);
			}
			EnterReadMode();
			UpdateList();
		}

		private void ButtonNew_Click(object sender, RoutedEventArgs e)
		{
			EnterCreateMode();
			SetSelection(new SpriteData());
			xFiche.RefreshContent();
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			if (CheckValidity(_selectedSprite))
			{
				if (Context.Data.Insert(_selectedSprite))
				{
					UpdateList();
					EnterReadMode();
					xFiche.RefreshContent();
				}
				else
				{
					MessageBox.Show("Ajout avorté : Erreur lors de l'ajout en database.");
				}
			}
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			EnterReadMode();
			SetSelection(null);
			xFiche.RefreshContent();
		}

		private void ButtonEdit_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedSprite != null)
			{
				EnterEditMode();
			}
			xFiche.RefreshContent();
		}

		private void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			if (CheckValidity(_selectedSprite))
			{
				EnterReadMode();
				//if another item has been selected while editing, it would have changed every values.
				//but we need the id to stay unchanged.
				_selectedSprite.Id = _editedId;
				Context.Data.Update(_selectedSprite);
				xFiche.RefreshContent();
			}
		}

		private Boolean CheckValidity(SpriteData sprite)
		{
			bool valid = true;
			if (sprite.Bottom > sprite.TextureMap.Row)
			{
				MessageBox.Show("Max bottom value for this texture is " + sprite.TextureMap.Row);
				valid = false;
			}
			if (sprite.Right > sprite.TextureMap.Column)
			{
				MessageBox.Show("Max Right value for this texture is " + sprite.TextureMap.Column);
				valid = false;
			}
			if (String.IsNullOrWhiteSpace(sprite.Name))
			{
				MessageBox.Show("Name is Compulsory");
				valid = false;
			}
			return valid;
		}

		private void SelectTexture_Click(object sender, RoutedEventArgs e)
		{
			ListSelector ls = new ListSelector()
			{
				Data = Context.Data,
				Single = true
			};
			ls.Load(typeof(TextureMapData));
			ListSelectorResult res = ls.GetSelection();
			_selectedSprite.TextureMap = (TextureMapData)res.Data.FirstOrDefault();
		}
	}
}