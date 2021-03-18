using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GuardianMovement : MonoBehaviour
{
    public Animator anim;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Input.GetAxisRaw("Vertical");

        anim.SetFloat("current speed", speed);

        transform.position += transform.forward * speed * Time.deltaTime * 5;
    }
}
