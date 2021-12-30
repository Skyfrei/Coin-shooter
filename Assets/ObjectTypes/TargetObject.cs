using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : Objects
{
    public override float Timer { get; set; }
    ///<summary>
    ///Once player clicks the object the next 5 objects will appear as coins.
    ///</summary>
    public override void OnClick()
    {
        objectManager.nextFiveAreCoin = true;
        objectManager.nextFiveAreCoinCount = 5;
        
        objectManager.DespawnWhenHit(this);
    }
}
