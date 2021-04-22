using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFoot : MonoBehaviour
{
    public float xMove1 = 3;
    public float xMove2 = 4;
    public float yMove1 = 3;
    public float yMove2 = 3;
    public Vector3 startingRot;
    // Start is called before the first frame update
    void Start()
    {
        startingRot = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        float xMove = Mathf.Sin(Time.time * xMove1) * xMove2;

        float yMove = Mathf.Sin(Time.time * yMove1) * yMove2;

        Vector3 walkVec = new Vector3(0, yMove, xMove);

        transform.localPosition = AnimMath.Slide(transform.localPosition, walkVec, 0.25f);
    }
}
