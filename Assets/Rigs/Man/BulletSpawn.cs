using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    PlayerMovement pMove;
    public GameObject bullet;

    public Vector3 facingDirection;
    // Start is called before the first frame update
    void Start()
    {
        pMove = GameObject.Find("rigged-dude").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        facingDirection = transform.forward;

        if (pMove.leftMousePressed)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
