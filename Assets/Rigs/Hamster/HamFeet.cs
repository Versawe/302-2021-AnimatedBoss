using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamFeet : MonoBehaviour
{
    Vector3 startPos;
    private float zStay;
    public float yMove1 = 0.05f;
    public float yMove2 = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //float zMove = Mathf.Sin(Time.time)
        float yMove = Mathf.Sin(Time.time * 5f *yMove1) * yMove2;
        Vector3 walkVec = new Vector3(startPos.x, Mathf.Clamp(yMove, 0, 15), startPos.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.001f);
    }
}
