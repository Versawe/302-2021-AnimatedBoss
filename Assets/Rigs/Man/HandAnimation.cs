using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    public float zMove1 = 2;
    public float zMove2 = 2;
    public float yMove1 = 1f;
    public float yMove2 = 1;

    public float xStay = 0.5f;

    public Vector3 startingRot;
    public float startX = 1.5f;
    private float startY = 3;
    private float startZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        startingRot = new Vector3(startX, startY, startZ);

        transform.localPosition = startingRot;
    }

    // Update is called once per frame
    void Update()
    {
        HandWalking();
    }

    private void HandWalking()
    {
        float zMove = Mathf.Sin(Time.time * zMove1) * zMove2;
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        float xMove = Mathf.Sin(Time.time * 1f) * 0.25f;
        Vector3 walkVec = new Vector3(xStay + xMove, yMove + transform.localPosition.y, zMove);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.5f);
    }
}
