using Core.Gestion.Sprites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MightyGmCtrl;

namespace MightyGmWPF.Tabs.Ressources
{
	/// <summary>
	/// Logique d'interaction pour WrkTextureMaps.xaml
	/// </summary>
	public partial class WrkTextureMaps : UserControl
	{
		public Context Context { get; }
		private TextureMapData _selectedTexture;
		private FileInfo _chosenImage;

		public WrkTextureMaps(Context context)
		{
			InitializeComponent();
			Context = context;
			UpdateList();
			SetReadOnly(true);
		}

		public void SetSelectedTexture(TextureMapData tx)
		{
			_selectedTexture = tx;
			xFiche.SelectedObject = _selectedTexture;
			if (tx == null)
			{
				xDisplay.Background = null;
			}
			else
			{
				BitmapImage img = Context.Textures.LoadImage(tx.Name);
				xDisplay.Background = new ImageBrush(img);
			}
		}

		private void SetReadOnly(Boolean readOnly)
		{
			xFiche.ReadOnly = readOnly;
			if (readOnly)
			{
				xButtons1.Visibility = Visibility.Visible;
				xButtons2.Visibility = Visibility.Collapsed;
			}
			else
			{
				xButtons1.Visibility = Visibility.Collapsed;
				xButtons2.Visibility = Visibility.Visible;
			}
		}

		private void UpdateList()
		{
			xList.ItemsSource = Context.Data.GetTable<TextureMapData>();
			xList.SelectedItem = null;
		}

		private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListView lv = sender as ListView;
			SetSelectedTexture(lv.SelectedItem as TextureMapData);
		}

		private void ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedTexture != null)
			{
				Context.Data.Delete(_selectedTexture);
				UpdateList();
			}
		}

		private void ButtonNew_Click(object sender, RoutedEventArgs e)
		{
			SetReadOnly(false);
			SetSelectedTexture(new TextureMapData());
			xFiche.RefreshContent();
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			SetReadOnly(true);
			if(!Context.Textures.AddToDatabase(_selectedTexture, _chosenImage)){
				MessageBox.Show("Un fichier portant déjà ce nom existe déjà dans les répertoires.");
			}
			else
			{
				UpdateList();
			}
			xFiche.RefreshContent();
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			SetReadOnly(true);
			SetSelectedTexture(null);
			xFiche.RefreshContent();
		}

		private void ButtonChooseImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg;*.jpg";
			if (openFileDialog.ShowDialog() == true)
			{
				_chosenImage = new FileInfo(openFileDialog.FileName);
				BitmapImage img = new BitmapImage(new Uri(_chosenImage.FullName));
				xDisplay.Background = new ImageBrush(img);
			}
		}
	}
}
