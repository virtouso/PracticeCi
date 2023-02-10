using Help.Script.Help.Consts.Keys;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

//using OceanExplorer.Managers;

namespace Help.Script.Help.SceneManager.AssetLoaderScene.Panels
{
    public class LoginPanel : BaseAssetLoaderPanel
    {
        [SerializeField] private Button _submitButton;

       // [Inject] private IBackendServicesManager _servicesManager;
        [Inject] private SignalBus _signalBus;
        //[Inject] private IDataManager _dataManager;


        [SerializeField] private TMP_InputField _userIdField;
        [SerializeField] private TMP_InputField _passwordField;


        private async void Submit()
        {
            var userId = _userIdField.text;
            var password = _passwordField.text;

        //    var result = await _servicesManager.SendModelRequest<LoginResponse, LoginRequest>(BackendConfiguration.RequestName.Login, new LoginRequest(userId, password));

            // if (result.IsError)
            // {
            //     _signalBus.Fire<ShowMessagePanelSignal>(new ShowMessagePanelSignal("login failed"));
            //     return;
            // }

           // _dataManager.PlayerData.UserAuthenticationInstance.Token = result.Result.Token;
          //  _dataManager.PlayerData.UserAuthenticationInstance.RefreshToken = result.Result.RefreshToken;
         //   _dataManager.PlayerData.UserAuthenticationInstance.TokenExpiration = result.Result.RefreshTokenLifetime;
         //   _dataManager.SaveUserData(false);

            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneNames.GameFlow);

        }


        private void Start()
        {
            _submitButton.onClick.AddListener(Submit);
        }
    }
}