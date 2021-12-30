using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowObject : Objects
{
    public override float Timer { get; set; }
    public override void OnClick()
    {
        Player.score++;
        objectManager.DespawnWhenHit(this);
    }
}
