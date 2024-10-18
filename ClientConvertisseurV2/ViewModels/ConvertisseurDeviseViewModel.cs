using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDeviseViewModel : ObservableObject
    {

        #region Constructeur

        public ConvertisseurDeviseViewModel()
        {
            ActionGetDataAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }
        #endregion

        #region Propriétés
        private ObservableCollection<Devise> _devises;

        public ObservableCollection<Devise> Devises
        {
            get { return _devises; }
            set
            {
                _devises = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand BtnSetConversion { get; set; }

        private string _montantEuros;

        public string MontantEuros
        {
            get { return _montantEuros; }
            set
            {
                _montantEuros = value;
                OnPropertyChanged();
            }
        }

        private Devise _deviseSelected;

        public Devise DeviseSelected
        {
            get { return _deviseSelected; }
            set
            {
                _deviseSelected = value;
                OnPropertyChanged();
            }
        }

        private string _montantEnDevise;

        public string MontantEnDevise
        {
            get { return _montantEnDevise; }
            set
            {
                _montantEnDevise = value;
                OnPropertyChanged();
            }
        }


        #endregion
        #region Method

        private async void ActionGetDataAsync()
        {
            var result = await WSService.GetInstance().GetDevisesAsync("Devises");
            if (result == null)
            {
                ShowErrorAsync("API non disponible !");
                return;
            }
            Devises = new ObservableCollection<Devise>(result);
        }

        private void ActionSetConversion()
        {
            if (DeviseSelected == null)
            {
                ShowErrorAsync("Vous devez sélectionner une devise !");
                return;
            }
            double convertedValue = float.Parse(MontantEnDevise) / DeviseSelected.Taux;
            MontantEuros = convertedValue.ToString();
        }

        private async void ShowErrorAsync(string message)
        {
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = message,
                CloseButtonText = "OK"
            };

            errorDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await errorDialog.ShowAsync();
        }
        #endregion

    }
}
