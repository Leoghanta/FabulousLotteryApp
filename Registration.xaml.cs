using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture.Frames;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FabulousLotteryApp
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Registration : Page
	{
		PlayGame game = App.game;


		public Registration()
		{
			this.InitializeComponent();
		}

		private void CancelButtonClicked(object sender, RoutedEventArgs e)
		{
			Frame.GoBack();
		}

		private void OKButtonClicked(object sender, RoutedEventArgs e)
		{
			try
			{
				game.NewPlayer(textboxName.Text, textboxPhone.Text, textboxEmail.Text);
				Frame.GoBack();
			}
			catch (Exception ex)
			{
				displayError(ex.Message, "Error Creating Player");
			}
		}

		private async void displayError(string error, string name)
		{
			MessageDialog msg = new MessageDialog(error, name);	
			await msg.ShowAsync();
		}

	}
}
