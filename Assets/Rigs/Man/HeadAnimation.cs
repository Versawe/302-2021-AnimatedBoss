using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour
{
    public float xMove1 = 3f;
    public float xMove2 = 0.25f;
    
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
        HeadWalking();
    }

    private void HeadWalking()
    {
        xMove1 = 5f;
        xMove2 = 0.01f;
        yMove1 = 5f;
        yMove2 = 0.01f;

        float xMove = Mathf.Sin(Time.time * xMove1) * xMove2;
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        Vector3 walkVec = new Vector3(transform.localPosition.x + xMove, transform.localPosition.y + yMove, transform.localPosition.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.05f);
    }
}
