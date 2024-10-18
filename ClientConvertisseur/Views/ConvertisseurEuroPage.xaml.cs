using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ABI.Windows.Web.Http;
using ClientConvertisseur.Models;
using ClientConvertisseur.Services;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseur.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page
    {
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            ActionGetDataAsync();
        }

        private async void ActionGetDataAsync()
        {
            var result = await WSService.GetInstance().GetDevisesAsync("Devises");
            if (result == null)
            {
                ShowErrorAsync("API non disponible");
                return;
            }

            this.cbxDevise.DataContext = new List<Devise>(result);
        }

        private void BtnConvertir_Click(object sender, RoutedEventArgs e)
        {
            var cbxDevise = (Devise)this.cbxDevise.SelectedItem;
            if (cbxDevise == null)
            {
                ShowErrorAsync("Vous devez sélectionner une devise");
                return;
            }
            double convertedValue = cbxDevise.Taux * int.Parse(txtBox1.Text);
            this.txtBox2.Text = convertedValue.ToString();
        }

        private async void ShowErrorAsync(string message)
        {
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = message,
                CloseButtonText = "OK"
            };

            errorDialog.XamlRoot = this.Content.XamlRoot;
            ContentDialogResult result = await errorDialog.ShowAsync();
        }

    }
}
