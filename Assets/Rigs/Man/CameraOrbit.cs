using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    PlayerMovement moveScript;
    HealthSystem pHealth;
    private Camera cam;
    public GameObject hamster;

    private float yaw = 0;
    private float pitch = 0;

    private float cameraSensitivityX = 2.5f;
    private float cameraSensitivityY = 2.5f;

    private float fieldOfView = 60f;

    Vector3 prevForward;


    // Start is called before the first frame update
    void Start()
    {
        moveScript = GameObject.Find("rigged-dude").GetComponent<PlayerMovement>();
        pHealth = GameObject.Find("rigged-dude").GetComponent<HealthSystem>();
        hamster = GameObject.Find("Root_Hamster_Idle");
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        prevForward = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();

        Vector3 noZoomVec = new Vector3(moveScript.transform.position.x, moveScript.transform.position.y + 5, moveScript.transform.position.z);
        Vector3 zoomVec = new Vector3(moveScript.transform.position.x, moveScript.transform.position.y + 7, moveScript.transform.position.z);

        if(pHealth.isDying) fieldOfView = 60;
        if (!moveScript.rightMouseDown)
        {
            transform.position = AnimMath.Slide(transform.position, noZoomVec, 0.001f);
            fieldOfView = 60;
        }
        else
        {
            transform.position = AnimMath.Slide(transform.position, zoomVec, 0.001f);
            fieldOfView = 40;

            Vector3 dir = transform.position - hamster.transform.position;
            transform.forward = -Vector3.RotateTowards(transform.position, dir, 1f, 1f);
        }

        cam.fieldOfView = fieldOfView;
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
