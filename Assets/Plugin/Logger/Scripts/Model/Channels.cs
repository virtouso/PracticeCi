using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum Channels : uint
{
    Animation = 1 << 0,
    GameFlow= 1 << 1,
    GamePlay = 1 << 2,
    Backend = 1 << 3,
    Services=1<<4,
    UI=1<<5,
    InAppPurchase=1<<6
    //.. add channels you n need
}