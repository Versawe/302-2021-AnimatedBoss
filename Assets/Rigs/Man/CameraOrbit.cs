using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    PlayerMovement moveScript;
    HealthSystem pHealth;
    private GameObject dude;
    private Camera cam;
    public GameObject hamster;

    private float yaw = 0;
    private float pitch = 0;

    private float cameraSensitivityX = 2.5f;
    private float cameraSensitivityY = 2.5f;

    private float fieldOfView = 60f;

    Vector3 prevForward;
    Vector3 dir;

    private bool wasLooking = false;


    // Start is called before the first frame update
    void Start()
    {
        moveScript = GameObject.Find("rigged-dude").GetComponent<PlayerMovement>();
        pHealth = GameObject.Find("rigged-dude").GetComponent<HealthSystem>();
        hamster = GameObject.Find("Root_Hamster_Idle");
        dude = GameObject.Find("rigged-dude");
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        prevForward = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 noZoomVec = new Vector3(dude.transform.position.x, dude.transform.position.y + 5, dude.transform.position.z);
        Vector3 zoomVec = new Vector3(dude.transform.position.x, dude.transform.position.y + 7, dude.transform.position.z);

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

            //transform.forward = -Vector3.RotateTowards(transform.position, dir, 1f, 1f);
            cameraSensitivityX = 1.5f;
            cameraSensitivityY = 1.5f;
            wasLooking = true;
        }
        
        cam.fieldOfView = fieldOfView;
        RotateCamera();
    }

    private void RotateCamera()
    {
        float pitch_clamped = 0;
        float mx;
        float my = 0;

        mx = Input.GetAxis("Mouse X");
        if(!wasLooking) my = Input.GetAxis("Mouse Y");

        // yaw and pitch values change determined on 
        // mousex and mousey movement and applied sensitivity to both
        yaw += mx * cameraSensitivityX;
        if (!wasLooking)  pitch -= my * cameraSensitivityY;

        //clamp pitch, so camera doesn't rotate too far low or high to seem weird
        pitch_clamped = Mathf.Clamp(pitch, 0f, 90f);
        //saves axis movement of x and y mouse movement

        // use the clamped pitch and yaw to rotate camera rig, entered in as euler angles through Quaternion class
        if (wasLooking) 
        {
            pitch_clamped = 0;
            /*transform.rotation = Quaternion.identity;
            if(hamster.transform.position.x > dude.transform.position.x) yaw = 90;
            if (hamster.transform.position.x < dude.transform.position.x) yaw = 90;
            if (hamster.transform.position.z > dude.transform.position.z) yaw = 0;
            if (hamster.transform.position.z < dude.transform.position.z) yaw = 180;*/
            wasLooking = false;
        }

        transform.rotation = Quaternion.Euler(pitch_clamped, yaw, 0);

    }
}
