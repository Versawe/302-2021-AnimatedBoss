using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Camera cam;
    private CharacterController cc;
    Vector3 inputDirection = new Vector3();

    private bool isTryingToMove = false;

    private float walkSpeed = 15;

    private float verticalVelocity = 0;
    private float gravityMultiplier = 30;
    private float jumpImpulse = 10;

    private float timeLeftGrounded = 0;

    public string State = "Idle";
    public bool isAiming = false;

    public bool isGrounded
    {
        get
        {
            return cc.isGrounded || timeLeftGrounded > 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }



    private void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal"); // strafing?
        float v = Input.GetAxis("Vertical"); // forward / backward

        bool isJumpHeld = Input.GetButton("Jump");
        bool onJumpPress = Input.GetButtonDown("Jump");

        isTryingToMove = (h != 0 || v != 0);
        if (isTryingToMove)
        {
            //turn to face correct direction
            float camYaw = cam.transform.eulerAngles.y;
            transform.rotation = AnimMath.Slide(transform.rotation, Quaternion.Euler(0, camYaw, 0), 0.02f);
        }

        inputDirection = transform.forward * v + transform.right * h;

        //applying gravity
        if(!cc.isGrounded) verticalVelocity += gravityMultiplier * Time.deltaTime;

        // adds lateral movement to vertical movement
        Vector3 moveDelta = inputDirection * walkSpeed + verticalVelocity * Vector3.down;

        //passes it all to the cc
        cc.Move(moveDelta * Time.deltaTime);
        if (cc.isGrounded)
        {
            verticalVelocity = 0;
            timeLeftGrounded = .2f;
        }

        if (isGrounded)
        {
            if (isJumpHeld)
            {
                verticalVelocity = -jumpImpulse;
                timeLeftGrounded = 0; // not on ground
            }
        }

        if (!isTryingToMove) State = "Idle";
        else State = "Walk";
    }
}
