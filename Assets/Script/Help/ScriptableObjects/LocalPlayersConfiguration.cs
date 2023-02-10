using System.Collections.Generic;
using Shared.Basic.Models;
using UnityEngine;

namespace Help.Script.Help.ScriptableObjects
{
    public class LocalPlayersConfiguration : ScriptableObject
    {
     [SerializeField]   private List<MockPlayer> _mockPlayers;


     public MockPlayer GetRandomPlayer()
     {
         return _mockPlayers[Random.Range(0, _mockPlayers.Count - 1)];
     }
     
    }


}