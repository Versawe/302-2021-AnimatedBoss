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
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Mathf.Sin(Time.time * xRot1) * xRot2;

        transform.localRotation = Quaternion.Euler(startRot.x + xRot, startRot.y, startRot.z);
    }
}
