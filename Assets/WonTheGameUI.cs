using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WonTheGameUI : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        if (Player.score >= 100)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }
}
