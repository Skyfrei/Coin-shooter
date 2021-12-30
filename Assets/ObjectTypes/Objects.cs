using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Objects : MonoBehaviour
{
    public abstract void OnClick();
    public abstract float Timer { get; set; }
    public ObjectManager objectManager;

    private void Start() {
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
    }
}
