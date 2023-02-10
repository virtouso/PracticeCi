using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

//using OceanExplorer.Managers;

namespace Help.Script.Help.SceneManager.AssetLoaderScene.Panels
{
    public class SignupPanel : BaseAssetLoaderPanel
    {
        [Inject] private SignalBus _signalBus;
  //      [Inject] private IDataManager _dataManager;
   //     [Inject] private IBackendServicesManager _backendServicesManager;
        [SerializeField] private TMP_InputField _userIdField;
        [SerializeField] private TMP_InputField _emailField;
        [SerializeField] private TMP_InputField _passwordField;
        [SerializeField] private Button _submitButton;



        private async void SubmitButtonPressed()
        {
            var userId = _userIdField.text;
            var pass = _passwordField.text;
            var email = _emailField.text;
           // var result = await _backendServicesManager.SendModelRequest<SignupResponse,SignupRequest>(BackendConfiguration.RequestName.SignUp,new SignupRequest(userId,pass,email));

            // if (result.IsError)
            // {
            //     Debug.Log("signup failed");
            //     _signalBus.Fire<ShowMessagePanelSignal>(new ShowMessagePanelSignal("signup failed"));
            //     return;
            // }
            //
            // _dataManager.PlayerData.UserAuthenticationInstance.UserId = userId;
            // _dataManager.PlayerData.UserAuthenticationInstance.UserEmail = email;
            // _dataManager.PlayerData.UserAuthenticationInstance.Token = result.Result.TempToken;
            // _signalBus.Fire<OpenPanelSignal>(new OpenPanelSignal(PanelId.Validation));
        }
        
        private void Start()
        {
            _submitButton.onClick.AddListener(SubmitButtonPressed);
        }
    }
}