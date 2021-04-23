using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFoot : MonoBehaviour
{
    public float zMove1 = 3;
    public float zMove2 = 4;
    public float yMove1 = 2;
    public float yMove2 = 2;

    public float xStay = 0.5f;
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
        FootWalking();
    }

    private void FootWalking()
    {
        zMove2 = 4f;
        yMove2 = 2f;

        if (gameObject.name == "IKLeftFoot")
        {
            zMove1 = -3;
            yMove1 = -2;
            xStay = -0.6411617f;
        }
        else
        {
            zMove1 = 3;
            yMove1 = 2;
            xStay = 0.6411617f;
        }

        float zMove = Mathf.Sin(Time.time * zMove1) * zMove2;
        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;
        Vector3 walkVec = new Vector3(xStay, Mathf.Clamp(yMove, 0.5f, 5), zMove);
        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.25f);
    }
}
