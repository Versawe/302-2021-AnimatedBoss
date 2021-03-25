using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    public PlayerMovement moveScript;
    private Camera cam;

    private float yaw = 0;
    private float pitch = 0;

    public float cameraSensitivityX = 10;
    public float cameraSensitivityY = 10;

    public float shakeIntensity = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerOrbitCamera();

        transform.position = moveScript.transform.position;
       
    }

    public void Shake(float intensity = 1)
    {
        if(intensity > 1)
        {
            shakeIntensity = intensity;
        }
        else
        {
            shakeIntensity += intensity;
            if (shakeIntensity > 1) shakeIntensity = 1;
        }

    }


    private void PlayerOrbitCamera()
    {
        float mx = Input.GetAxisRaw("Mouse X");
        float my = Input.GetAxisRaw("Mouse Y");

        yaw += mx * cameraSensitivityX;
        pitch += my * cameraSensitivityY;

 
        pitch = Mathf.Clamp(pitch, 15, 60);

        //find player facing
        float playerYaw = moveScript.transform.eulerAngles.y;
        //clamp camera-rig Yaw to playerYaw +- 40
        yaw = Mathf.Clamp(yaw, playerYaw - 40, playerYaw + 40);


        transform.rotation = AnimMath.Slide(transform.rotation, Quaternion.Euler(pitch, yaw, 0), .001f);
    }
}
