using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyUI : MonoBehaviour
{
    public ObjectManager objectManager;
    [SerializeField]
    private Canvas canvas;
    private CameraClass camera;
    
    void Start()
    {
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraClass>();
    }

    public void SetDifficultyEasy()
    {
        objectManager.diffScriptableObject = Resources.Load<DifficultyScriptableObject>("Easy");
        objectManager.GetDifficultyStats();
    }

    public void SetDifficultyMedium()
    {
        objectManager.diffScriptableObject = Resources.Load<DifficultyScriptableObject>("Medium");
        objectManager.GetDifficultyStats();
    }

    public void SetDifficultyHard()
    {
        objectManager.diffScriptableObject = Resources.Load<DifficultyScriptableObject>("Hard");
        objectManager.GetDifficultyStats();
    }

    public void CloseUI()
    {
        canvas.enabled = !canvas.enabled;
        camera.crosshair.enabled = !camera.crosshair.enabled;
        
        Cursor.lockState = CursorLockMode.Locked;
    }
}
