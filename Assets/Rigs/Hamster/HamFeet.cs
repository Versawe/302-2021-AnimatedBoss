using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HamFeet : MonoBehaviour
{
    Vector3 startPos;
    private float zStay;
    public float yMove1 = 0.05f;
    public float yMove2 = 0.05f;
    public float zMove1 = 0.05f;
    public float zMove2 = 0.05f;
    public float zClamp1 = 0;
    public float zClamp2 = 10;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //FeetWalk();
    }

    private void FeetWalk()
    {
        float zMove = Mathf.Sin(Time.time * 2f * zMove1) * zMove2;
        float yMove = Mathf.Sin(Time.time * 5f * yMove1) * yMove2;
        Vector3 walkVec = new Vector3(startPos.x + Mathf.Clamp(zMove, startPos.z + zClamp1, zClamp2), startPos.y + Mathf.Clamp(yMove, 0, 15), startPos.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.001f);
    }
}
