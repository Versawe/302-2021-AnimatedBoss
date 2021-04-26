using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipAnimation : MonoBehaviour
{
    PlayerMovement pMove;
    HealthSystem pHealth;

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
        if (pMove.State == "Idle" || pMove.State == "Walk") HipWalkingAndIdle();
        else if (pHealth.isDying) HipDying();
    }

    private void HipWalkingAndIdle()
    {
        yMove1 = 5f;
        yMove2 = 0.01f;

        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        Vector3 walkVec = new Vector3(transform.localPosition.x, transform.localPosition.y + yMove, transform.localPosition.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.05f);
    }

    private void HipDying()
    {
        //y2.6 z.5
        Vector3 dieVec = new Vector3(0, 2.6f, -0.5f);
        transform.localPosition = AnimMath.Slide(transform.localPosition, dieVec, 0.05f);
    } 
}
