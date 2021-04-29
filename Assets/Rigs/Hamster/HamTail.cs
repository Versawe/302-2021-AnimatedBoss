using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamTail : MonoBehaviour
{
    private float xIntensity = 2;
    private float yIntensity = 4;
    private float zIntensity = 5;
    
    Quaternion startRot;

    HamsterController hc;
    // Start is called before the first frame update
    void Start()
    {
        hc = GetComponentInParent<HamsterController>();
        startRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (hc.HamState == "Idle") TailIdle();
        else if (hc.HamState == "Chase" || hc.HamState == "Attack") TailWalk();
    }

    private void TailIdle()
    {
        float xRot = Mathf.Sin(Time.time * xIntensity * 1) * 25;
        float yRot = Mathf.Sin(Time.time * yIntensity * 1) * 25;
        float zRot = Mathf.Sin(Time.time * zIntensity * 1) * 25;

        transform.localRotation = AnimMath.Slide(transform.localRotation, Quaternion.Euler(startRot.x + xRot, startRot.y + yRot, startRot.z +zRot), 0.01f);
    }

    private void TailWalk()
    {
        float xRot = Mathf.Sin(Time.time * xIntensity * 10) * 5;
        float yRot = Mathf.Sin(Time.time * yIntensity * 5) * 15;
        float zRot = Mathf.Sin(Time.time * zIntensity * 2) * 15;

        transform.localRotation = AnimMath.Slide(transform.localRotation, Quaternion.Euler(startRot.x + xRot, startRot.y + yRot, startRot.z + zRot), 0.01f);
    }
}
