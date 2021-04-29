using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour
{

    PlayerMovement pMove;
    HealthSystem pHealth;

    public float xMove1 = 3f;
    public float xMove2 = 0.25f;
    
    public float yMove1 = 3f;
    public float yMove2 = 0.25f;

    public Vector3 startingPos;

    public Quaternion startingRot;
    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponentInParent<PlayerMovement>();
        pHealth = GetComponentInParent<HealthSystem>();

        startingPos = transform.localPosition;
        startingRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (pMove.State == "Idle") HeadIdle();
        else if (pMove.State == "Walk") HeadWalking();
        else if (pHealth.isDying) HeadDying();
    }

    private void HeadIdle()
    {
        xMove1 = 0f;
        xMove2 = 0f;
        yMove1 = 0f;
        yMove2 = 0f;

        float xMove = Mathf.Sin(Time.time * xMove1) * xMove2;
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        Vector3 idleVec = new Vector3(startingPos.x + xMove, startingPos.y + yMove, startingPos.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, idleVec, 0.05f);
    }

    private void HeadWalking()
    {
        xMove1 = 5f;
        xMove2 = 0.01f;
        yMove1 = 5f;
        yMove2 = 0.01f;

        float xMove = Mathf.Sin(Time.time * xMove1) * xMove2;
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        Vector3 walkVec = new Vector3(startingPos.x + xMove, startingPos.y + yMove, startingPos.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.05f);
    }

    private void HeadDying()
    {
        // y4.9f z.22
        Vector3 dieVec = new Vector3(0, 4.9f, 0.22f);
        transform.localPosition = AnimMath.Slide(transform.localPosition, dieVec, 0.01f);
    }
}
