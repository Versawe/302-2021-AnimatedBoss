using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamHead : MonoBehaviour
{
    private float xRot1 = 15;
    private float xRot2 = 20;
    Quaternion startRot;
    Vector3 startPos;
    HamsterController hc;
    // Start is called before the first frame update
    void Start()
    {
        hc = GetComponentInParent<HamsterController>();
        startRot = transform.localRotation;
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (hc.HamState == "Idle") HeadIdle();
        else if (hc.HamState == "Chase") HeadWalk();
        else if (hc.HamState == "Attack") HeadAttack();
    }

    private void HeadIdle()
    {
        float xRot = Mathf.Sin(Time.time * 1) * 20;
        float yRot = Mathf.Sin(Time.time * 0.75f) * 25;

        transform.localPosition = AnimMath.Slide(transform.localPosition, startPos, 0.01f);
        transform.localRotation = AnimMath.Slide(transform.localRotation, Quaternion.Euler(startRot.x + xRot, startRot.y + yRot, startRot.z), 0.01f);
    }

    private void HeadWalk()
    {
        float xRot = Mathf.Sin(Time.time * 5) * 15;
        float yRot = Mathf.Sin(Time.time * 5 ) * 30;

        transform.localPosition = AnimMath.Slide(transform.localPosition, startPos, 0.01f);
        transform.localRotation = AnimMath.Slide(transform.localRotation, Quaternion.Euler(startRot.x + xRot, startRot.y + yRot, startRot.z), 0.01f);
    }

    private void HeadAttack()
    {
        transform.localRotation = AnimMath.Slide(transform.localRotation, startRot, 0.01f);
        float zRot = Mathf.Sin(Time.time * 50) * 0.005f;
        Vector3 attackVec = new Vector3(startPos.x, startPos.y + zRot, startPos.z);
        transform.localPosition = AnimMath.Slide(transform.localPosition, attackVec, 0.01f);
    }
}
