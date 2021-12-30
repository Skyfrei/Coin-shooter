using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueObject : Objects
{
    public override void OnClick()
    {
        Player.score += 2;
        objectManager.DespawnWhenHit(this);
    }
    public override float Timer { get; set; }
}
