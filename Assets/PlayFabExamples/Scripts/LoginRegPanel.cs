using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;

public class LoginRegPanel : MonoBehaviour
{
    public InputField LoginUsernameField;
    public InputField LoginPasswordField;
    public Text LoginErrorText;
    public Button LoginButton;
    public InputField RegUsernameField;
    public InputField RegEmailField;
    public InputField RegPasswordField;
    public Text RegErrorText;
    public Button RegButton;

    void Start()
    {
        LoginButton.onClick.AddListener(Login);
        RegButton.onClick.AddListener(Register);
    }

    public void Login()
    {
         var loginRequest = new LoginWithPlayFabRequest()
         {
             TitleId = PlayFabSettings.TitleId,
             Username = LoginUsernameField.text, 
             Password = LoginPasswordField.text
         };
        PlayFabClientAPI.LoginWithPlayFab(loginRequest, (result) =>
        {
            LoginRegisterSuccess(result.PlayFabId, result.SessionTicket);
        }, (error) =>
        {
            LoginErrorText.text = error.ErrorMessage;
            LoginErrorText.gameObject.transform.parent.gameObject.SetActive(true);
            PlayFabErrorHandler.HandlePlayFabError(error);
        });
    }

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest()
        {
            TitleId = PlayFabSettings.TitleId,
            Username = RegUsernameField.text,
            Password = RegPasswordField.text,
            Email = RegEmailField.text
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, (result) =>
        {
            LoginRegisterSuccess(result.PlayFabId,result.SessionTicket);
        }, (error) =>
        {
            RegErrorText.text = error.ErrorMessage;
            RegErrorText.gameObject.transform.parent.gameObject.SetActive(true);
            PlayFabErrorHandler.HandlePlayFabError(error);
        });
    }

    private void LoginRegisterSuccess(string PlayFabId, string SessionTicket)
    {
        PlayFabDataStore.PlayFabId = PlayFabId;
        PlayFabDataStore.SessionTicket = SessionTicket;
        LoginErrorText.gameObject.transform.parent.gameObject.SetActive(false);
        RegErrorText.gameObject.transform.parent.gameObject.SetActive(false);

        GetDataFromPlayFab(() =>
        {
            WindowManager.SendEvent("Store");
        });
    }


    private void GetDataFromPlayFab(Action callback)
    {
        var catalogRequest = new GetCatalogItemsRequest()
        {
            CatalogVersion = "ItemCatalog"
        };
        PlayFabClientAPI.GetCatalogItems(catalogRequest, (catResult) =>
        {
            PlayFabDataStore.Catalog = catResult.Catalog;

            var storeRequest = new GetStoreItemsRequest()
            {
                CatalogVersion = "ItemCatalog",
                StoreId = "ResizerItems"
            };
            PlayFabClientAPI.GetStoreItems(storeRequest, (storeResult) =>
            {
                PlayFabDataStore.Store = storeResult.Store;
                callback();
            }, PlayFabErrorHandler.HandlePlayFabError);

        }, PlayFabErrorHandler.HandlePlayFabError);

        
    }


}
