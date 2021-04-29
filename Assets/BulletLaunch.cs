using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaunch : MonoBehaviour
{
    BulletSpawn bs;
    Rigidbody rb;
    private float thrust = 5000;
    private float lifeTimer = 5f;
    HamsterController hc;
    // Start is called before the first frame update
    void Start()
    {
        bs = GameObject.Find("IKRightHand").GetComponent<BulletSpawn>();
        rb = GetComponent<Rigidbody>();
        hc = GameObject.Find("Root_Hamster_Idle").GetComponent<HamsterController>();
        rb.AddForce(bs.facingDirection * thrust, ForceMode.Force);
  
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= 1 * Time.deltaTime;
        if (lifeTimer <= 0) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hurt")
        {
            if (other.gameObject.GetComponent<HealthSystem>())
            {
                other.gameObject.GetComponent<HealthSystem>().TakeDamage(10f);
                //print(other.gameObject.GetComponent<HealthSystem>().health);
                Destroy(gameObject);
            }
        }
    }
}
