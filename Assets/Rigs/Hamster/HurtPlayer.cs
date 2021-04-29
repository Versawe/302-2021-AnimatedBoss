using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    HealthSystem hs;
    private float damageDelay = 1f;

    private void Start()
    {
        hs = null;
    }

    private void Update()
    {
        if (hs)
        {
            damageDelay -= 1 * Time.deltaTime;
            if (damageDelay <= 0)
            {
                hs.TakeDamage(10f);
                damageDelay = 1f;
            }
 
        }
        else
        {
            damageDelay = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hs = other.GetComponent<HealthSystem>();
        }
        else
        {
            print("no");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hs = null;
        }
    }
}
