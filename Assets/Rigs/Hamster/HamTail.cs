using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamTail : MonoBehaviour
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
        float xRot = Mathf.Sin(Time.time * 1) * 15;

        transform.localRotation = Quaternion.Euler(startRot.x + xRot, startRot.y, startRot.z);
    }
}
