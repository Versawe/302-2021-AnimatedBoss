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
    public Vector3 startingRot;
    // Start is called before the first frame update
    void Start()
    {
        startingRot = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        FootWalking();
    }

    private void FootWalking()
    {
        float zMove = Mathf.Sin(Time.time * zMove1) * zMove2;

        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;

        Vector3 walkVec = new Vector3(xStay, Mathf.Clamp(yMove, 0.5f, 5), zMove);

        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.25f);
    }
}
