using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using SeriesApp.Services;
using WebAPI_TP3.Models.EntityFramework;

namespace SeriesApp.ViewModels;

public partial class UtilisateurViewModel : ObservableObject
{

    #region Propriétés

    public IRelayCommand BtnSearchUser
    {
        get;
        set;
    }

    public IRelayCommand BtnModifyUtilisateurCommand
    {
        get;
        set;
    }
    public IRelayCommand BtnClearUtilisateurCommand
    {
        get;
        set;
    }
    public IRelayCommand BtnAddUtilisateurCommand
    {
        get;
        set;
    }

    private Utilisateur _utilisateurSearch;

    public Utilisateur UtilisateurSearch
    {
        get
        {
            return _utilisateurSearch;
        }
        set
        {
            _utilisateurSearch = value;
            OnPropertyChanged();
        }
    }

    private string _selectedEmail;
    public string SelectedEmail
    {
        get
        {
            return _selectedEmail;
        }
        set
        {
            _selectedEmail = value;
            OnPropertyChanged();
        }
    }
    #endregion
    #region Constructeur

    public UtilisateurViewModel()
    {
        UtilisateurSearch = new Utilisateur();
        BtnSearchUser = new RelayCommand(EmailResearch);
        BtnAddUtilisateurCommand = new RelayCommand(AddUser);
        BtnModifyUtilisateurCommand = new RelayCommand(ModifyUser);
        BtnClearUtilisateurCommand = new RelayCommand(ClearUser);
    }

    #endregion
    #region Methode

    private async void GetUtilisateurByEmailAsync(string email)
    {
        var result = await WSService.GetInstance().GetUserByEmailAsync(email);
        if (result == null)
        {
            throw new Exception("API non disponible !");
            return;
        }

        UtilisateurSearch = result;

    }

    private async void PutUtilisateur(int id, Utilisateur utilisateur)
    {
        await WSService.GetInstance().PutUtilisateur(id, utilisateur);
    }

    private async void PostUtilisateur(Utilisateur utilisateur)
    {
        WSBingMap.GetInstance().GetCoordinates(utilisateur);
        await WSService.GetInstance().PostUtilisateur(utilisateur);
    }

    private void EmailResearch()
    {
        if (SelectedEmail == null)
        {
            throw new Exception("Vous devez sélectionner un email !");
            return;
        }
        GetUtilisateurByEmailAsync(SelectedEmail);
    }

    private void ModifyUser()
    {
        if (UtilisateurSearch == null)
        {
            throw new Exception("Vous devez remplir les informations d'un utilisateur");
            return;
        }
        PutUtilisateur(UtilisateurSearch.UtilisateurId, UtilisateurSearch);
        showContentDialog("Utilisateur " + UtilisateurSearch.Nom + " modifié");
    }

    private void AddUser()
    {
        if (UtilisateurSearch == null)
        {
            throw new Exception("Vous devez remplir les informations d'un utilisateur");
            return;
        }
        PostUtilisateur(UtilisateurSearch);
        showContentDialog("Utilisateur " + UtilisateurSearch.Nom + " ajouté");
    }

    private void ClearUser()
    {
        UtilisateurSearch = null;
    }

    private async void showContentDialog(string message)
    {
        ContentDialog modificationDialog = new ContentDialog
        {
            Title = "Information",
            Content = message,
            CloseButtonText = "OK"
        };
        modificationDialog.XamlRoot = App.MainRoot.XamlRoot;
        ContentDialogResult result = await modificationDialog.ShowAsync();
    }
    #endregion

}
