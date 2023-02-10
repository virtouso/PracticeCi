using System.Collections.Generic;
using System.Linq;
using Shared.Basic.Enums;
using UnityEngine;

namespace Help.Script.Help.ScriptableObjects
{
    public class AvatarsConfiguration : ScriptableObject
    {
        [SerializeField] private List<AvatarSpritePair> _avatars;

        public Sprite GetAvatarSprite(AvatarId avatar)
        {
            return _avatars.First(x => x.Avatar == avatar).Sprite;
        }
    }


    [System.Serializable]
    public struct AvatarSpritePair
    {
        public AvatarId Avatar;
        public Sprite Sprite;
    }
}