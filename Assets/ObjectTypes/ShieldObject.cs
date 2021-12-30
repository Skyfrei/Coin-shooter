using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShieldObject : Objects
{
    private byte timesLeft = 5;
    public override float Timer { get; set; }

    ///<summary>
    ///Player has to click the object five times before he gets points from it
    ///</summary>
    public override void OnClick()
    {
        if (timesLeft > 0)
        {
            timesLeft--;
            return;
        }
        Player.score += 10;
        timesLeft = 5;
        objectManager.DespawnWhenHit(this);
    }
}
