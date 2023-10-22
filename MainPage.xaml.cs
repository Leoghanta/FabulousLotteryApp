using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FabulousLotteryApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        PlayGame game = App.game;

        public MainPage()
        {
            this.InitializeComponent();
		}

		private void NewPlayerButtonClicked(object sender, RoutedEventArgs e)
		{
            this.Frame.Navigate(typeof(Registration));
		}

		private void GenerateTicketButtonClicked(object sender, RoutedEventArgs e)
		{
            if (comboboxPlayerSelection.SelectedIndex < 0)
            {
                displayError("Please select a player from the drop down list", "Player Not Selected!");
            }
            else
            {
                try
                {
                    game.NewTicket(game.UsersList[comboboxPlayerSelection.SelectedIndex],
                        int.Parse(textboxBall1.Text),
                        int.Parse(textboxBall2.Text),
                        int.Parse(textboxBall3.Text),
                        int.Parse(textboxBall4.Text),
                        int.Parse(textboxBall5.Text),
                        int.Parse(textboxBall6.Text));
                    resetboard();
                    displayError(game.TicketList[game.TicketList.Count - 1].ToString(), "Ticket Generated!");
                }
                catch (Exception ex)
                {
                    displayError(ex.Message, "Could not create ticket!");
                }
            }
		}

        private void resetboard()
        {
            comboboxPlayerSelection.SelectedIndex = -1;
            textboxBall1.Text = string.Empty;
            textboxBall2.Text = string.Empty;
            textboxBall3.Text = string.Empty;
            textboxBall4.Text = string.Empty;
            textboxBall5.Text = string.Empty;
            textboxBall6.Text = string.Empty;
        }

		private async void displayError(string error, string name)
		{
			MessageDialog msg = new MessageDialog(error, name);
			await msg.ShowAsync();
		}

		private void LuckyDipButtonClicked(object sender, RoutedEventArgs e)
		{
			if (comboboxPlayerSelection.SelectedIndex < 0)
			{
				displayError("Please select a player from the drop down list", "Player Not Selected!");
			}
            else
            {
                try
                {
                    game.NewTicket(game.UsersList[comboboxPlayerSelection.SelectedIndex], true);
					resetboard();
					displayError(game.TicketList[game.TicketList.Count - 1].ToString(), "Ticket Generated!");
				} catch (Exception ex)
                {
                    displayError(ex.Message, "Could not create ticket!");
                }
            }
		}

		private void ResetButtonClicked(object sender, RoutedEventArgs e)
		{
            resetboard();
		}

		private void ExitButtonClicked(object sender, RoutedEventArgs e)
		{
            App.Current.Exit();
		}

		private void DrawButtonClicked(object sender, RoutedEventArgs e)
		{
            this.Frame.Navigate(typeof(DrawPage));
		}
	}
}
