using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    PlayerMovement pMove;
    public float zMove1 = 2;
    public float zMove2 = 2;
    public float yMove1 = 1f;
    public float yMove2 = 1;

    public float xStay = 0.5f;
    public float yStay = 0f;

    public Quaternion startingRot;
    public Vector3 startingPos;
    public float startX = 1.5f;
    private float startY = 3;
    private float startZ = 0;

    private float backToStartTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponentInParent<PlayerMovement>();
        startingRot = transform.localRotation;
        startingPos = new Vector3(startX, startY, startZ);

        transform.localPosition = startingPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (pMove.State == "Idle") HandIdle();
        else if (pMove.State == "Walk") HandWalking();

        backToStartTimer -= 1 * Time.deltaTime;
    }

    private void HandAim()
    {
        Vector3 AimVec;
        if (gameObject.name == "IKLeftHand") AimVec = new Vector3(-0.75f, 4.5f, 3f);
        else AimVec = new Vector3(0.75f, 4.5f, 3f);

        transform.localPosition = AnimMath.Slide(transform.localPosition, AimVec, 0.01f);
    }
    private void HandIdle()
    {
        zMove1 = 0.25f;
        zMove2 = 0.01f;
        yMove1 = 0.25f;
        yMove2 = 0.01f;
        yStay = 3;

        if (gameObject.name == "IKLeftHand")
        {
            xStay = -1f;
        }
        else
        {
            xStay = 1f;
        }

        float zMove = Mathf.Sin(Time.time * zMove1) * zMove2;
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        float xMove = Mathf.Sin(Time.time * 5f) * 0.25f;

        Vector3 idleVec = new Vector3(xStay + xMove, yStay + yMove, zMove);
        if (backToStartTimer > 0 && pMove.State != "Walk") transform.localPosition = AnimMath.Slide(transform.localPosition, startingPos, 0.01f);
        else transform.localPosition = AnimMath.Slide(transform.localPosition, idleVec, 0.05f);
    }

    private void HandWalking()
    {
        zMove2 = 15f;
        yMove1 = 0.55f;
        yMove2 = 0.05f;
        yStay = 3;

        if (gameObject.name == "IKLeftHand") 
        {
            zMove1 = -6;
            xStay = -2.5f;
        }
        else
        {
            xStay = 2.5f;
            zMove1 = 6f;
        }


        float zMove = Mathf.Sin(Time.time * zMove1) * zMove2;
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        float xMove = Mathf.Sin(Time.time * 1f) * 0.25f;
        Vector3 walkVec = new Vector3(xStay + xMove, yStay + yMove, zMove);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.5f);
    }
}
