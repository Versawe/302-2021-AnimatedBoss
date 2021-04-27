using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamHead : MonoBehaviour
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
        float xRot = Mathf.Sin(Time.time * 1) * 20;
        float yRot = Mathf.Sin(Time.time * 0.75f) * 25;

        transform.localRotation = Quaternion.Euler(startRot.x + xRot, startRot.y + yRot, startRot.z);
    }
}
