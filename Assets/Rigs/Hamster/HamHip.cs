using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class HamHip : MonoBehaviour
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
        startPos = transform.localPosition;
        startRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (hc.HamState == "Idle") HipIdle();
        else if (hc.HamState == "Chase") HipWalk();
        else if (hc.HamState == "Attack") HipAttack();
        else if (hc.HamState == "Death") HipDie();
    }

    private void HipIdle()
    {
        float xRot = Mathf.Sin(Time.time * xRot1) * xRot2;

        transform.localRotation = AnimMath.Slide(transform.localRotation, Quaternion.Euler(startRot.x + xRot, startRot.y, startRot.z), 0.01f);
    }

    private void HipWalk()
    {
        float xRot = Mathf.Sin(Time.time * 30) * 40;

        transform.localRotation = AnimMath.Slide(transform.localRotation, Quaternion.Euler(startRot.x + xRot, startRot.y, startRot.z), 0.01f);
    }

    private void HipAttack()
    {
        float zRot = Mathf.Sin(Time.time * 30) * 40;

        transform.localRotation = AnimMath.Slide(transform.localRotation, Quaternion.Euler(startRot.x, startRot.y, startRot.z + zRot), 0.01f);
    }

    private void HipDie()
    {
        Vector3 deadVec = new Vector3(startPos.x, startPos.y - 0.12f, startPos.z);
        transform.localRotation = AnimMath.Slide(transform.localRotation, Quaternion.Euler(startRot.x, startRot.y, startRot.z), 0.01f);
        transform.localPosition = AnimMath.Slide(transform.localPosition, deadVec, 0.01f);
    }
}
