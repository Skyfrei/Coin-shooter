using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraClass : MonoBehaviour
{
    private float rotationOnX;
    private float mouseSensitivity = 90f;
    public Image crosshair;
    
    [SerializeField]
    private Transform player;
    

    void Start()
    {
        crosshair.enabled = false;
    }

    void Update()
    {
        //Mouse Input
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        float mX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        //Camera rotation up & down
        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        //Left and right rotation
        player.Rotate(Vector3.up * mX);
    }
    
}
