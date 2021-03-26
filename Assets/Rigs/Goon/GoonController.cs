using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoonController : MonoBehaviour
{

    public enum States
    {
        Idle,
        Walk
    }

    private CharacterController pawn;

    public Vector3 walkScale = Vector3.one;

    public AnimationCurve ankleRotationCurve;

    public float stepSpeed = 5;
    public float moveSpeed = 5;

    public States state { get; private set; }

    public Vector3 moveDir { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        pawn = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDir = transform.forward * v + transform.right * h;

        if(moveDir.sqrMagnitude > 1) moveDir.Normalize();

        pawn.SimpleMove(moveDir * moveSpeed);

        state = (moveDir.sqrMagnitude > .1f) ? States.Walk : States.Idle;

    }
}
