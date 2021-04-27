using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AnimationFoot : MonoBehaviour
{
    PlayerMovement pMove;
    public float zMove1 = 3;
    public float zMove2 = 4;
    public float yMove1 = 2;
    public float yMove2 = 2;

    public float xStay = 0.5f;
    public Vector3 startingPos;
    public Quaternion startingRot;
    private float backToStartTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponentInParent<PlayerMovement>();
        startingPos = transform.localPosition;
        startingRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (pMove.State == "Idle") FootIdle();
        else if (pMove.State == "Walk") FootWalking();

        backToStartTimer -= 1 * Time.deltaTime;
        
    }

    private void FootIdle()
    {
        zMove1 = 0f;
        zMove2 = 0f;
        yMove1 = 0.1f;
        yMove2 = 0.01f;

        float zMove = Mathf.Sin(Time.time * zMove1) * zMove2;
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;

        Vector3 idleVec = new Vector3(xStay, yMove + transform.localPosition.y, zMove);
        if (backToStartTimer > 0 && pMove.State != "Walk") transform.localPosition = AnimMath.Slide(transform.localPosition, startingPos, 0.01f);
        else transform.localPosition = AnimMath.Slide(transform.localPosition, idleVec, 0.5f);
    }

    private void FootWalking()
    {
        backToStartTimer = 1;
        zMove2 = 4f;
        yMove2 = 2f;

        if (gameObject.name == "IKLeftFoot")
        {
            zMove1 = -6;
            yMove1 = -2;
            xStay = -0.6411617f;
        }
        else
        {
            zMove1 = 6;
            yMove1 = 2;
            xStay = 0.6411617f;
        }

        float zMove = Mathf.Sin(Time.time * 2 * zMove1) * zMove2;
        float yMove = Mathf.Sin(Time.time * 5 * yMove1) * yMove2;
        Vector3 walkVec = new Vector3(xStay, Mathf.Clamp(yMove, 0.5f, 5), zMove);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.25f);
    }
}
