using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    public PlayerMovement moveScript;
    private Camera cam;

    private float yaw = 0;
    private float pitch = 0;

    private float cameraSensitivityX = 2.5f;
    private float cameraSensitivityY = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();

        transform.position = new Vector3(moveScript.transform.position.x,moveScript.transform.position.y+5,moveScript.transform.position.z);
       
    }

    private void RotateCamera()
    {
        //saves axis movement of x and y mouse movement
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // yaw and pitch values change determined on 
        // mousex and mousey movement and applied sensitivity to both
        yaw += mx * cameraSensitivityX;
        pitch -= my * cameraSensitivityY;

        //clamp pitch, so camera doesn't rotate too far low or high to seem weird
        float pitch_clamped = Mathf.Clamp(pitch, 0f, 90f);

        // use the clamped pitch and yaw to rotate camera rig, entered in as euler angles through Quaternion class 
        transform.rotation = Quaternion.Euler(pitch_clamped, yaw, 0);
    }
}
