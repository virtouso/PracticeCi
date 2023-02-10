using System;
using Help.Script.Help.MultiLanguageSystem.Models;
using MVC.Script.MVC;
using Shared.Basic.Models;

namespace App.Script.App_GameFlow.Model
{
    [System.Serializable]
    public  class PlayerDataModel: BaseModel
    {

        public string Token;
        public string RefreshToken;
        public DateTime ExpirationDate;
        
        public string GameToken;

        public Language Langauge;
        
        public PlayerData PlayerData= new PlayerData();

    }
}