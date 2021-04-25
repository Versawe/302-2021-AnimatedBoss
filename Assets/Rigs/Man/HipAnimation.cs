using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipAnimation : MonoBehaviour
{
    PlayerMovement pMove;
    public float yMove1 = 3f;
    public float yMove2 = 0.25f;

    public Vector3 startingPos;

    public Quaternion startingRot;
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
        HipWalkingAndIdle();
    }

    private void HipWalkingAndIdle()
    {
        yMove1 = 5f;
        yMove2 = 0.01f;

        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        Vector3 walkVec = new Vector3(transform.localPosition.x, transform.localPosition.y + yMove, transform.localPosition.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.05f);
    }
}
