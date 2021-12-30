using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : Objects
{
    public override float Timer { get; set; }
    public override void OnClick()
    {
        Player.score += 5;
        objectManager.DespawnWhenHit(this);
    }
}
