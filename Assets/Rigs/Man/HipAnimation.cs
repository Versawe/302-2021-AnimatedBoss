using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipAnimation : MonoBehaviour
{
    public float yMove1 = 3f;
    public float yMove2 = 0.25f;

    public Vector3 startingPos;

    public Quaternion startingRot;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.localPosition;
        startingRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        HipWalking();
    }

    private void HipWalking()
    {
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        Vector3 walkVec = new Vector3(transform.localPosition.x, transform.localPosition.y + yMove, transform.localPosition.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.05f);
    }
}
