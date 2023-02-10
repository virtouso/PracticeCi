using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

//using OceanExplorer.Managers;

namespace Help.Script.Help.SceneManager.AssetLoaderScene.Panels
{
    public class ValidatePanel : BaseAssetLoaderPanel
    {
  //      [Inject] private IDataManager _dataManager;
  //      [Inject] private IBackendServicesManager _servicesManager;
        [Inject] private SignalBus _signalBus;


        [SerializeField] private Button _submitButton;
        [SerializeField] private TMP_InputField _codeInputField;
        
        
        
        private async void ValidateUser()
        {

            // var userid = _dataManager.PlayerData.UserAuthenticationInstance.UserId;
            // var code = _codeInputField.text;
            // var result = await _servicesManager.SendModelRequest<ValidationResponse, 
            //     ValidationRequest>(BackendConfiguration.RequestName.ValidateSignup,new ValidationRequest(userid,code,_dataManager.PlayerData.UserAuthenticationInstance.Token));
            //
            // if (result.IsError)
            // {
            //     _signalBus.Fire<ShowMessagePanelSignal>(new ShowMessagePanelSignal("validation failed"));
            //     return;
            // }
            //
            // _dataManager.PlayerData.UserAuthenticationInstance.Token = result.Result.Token;
            // _dataManager.PlayerData.UserAuthenticationInstance.RefreshToken = result.Result.RefreshToken;
            // _dataManager.PlayerData.UserAuthenticationInstance.TokenExpiration = result.Result.RefreshTokenLifetime;
            // _dataManager.SaveUserData(false);
            //
            // UnityEngine.SceneManagement.SceneManager.LoadScene(SceneNames.GameFlow);

        }
        
        private void Start()
        {
            _submitButton.onClick.AddListener(ValidateUser);
        }
    }
}