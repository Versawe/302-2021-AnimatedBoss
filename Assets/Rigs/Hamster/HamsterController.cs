using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HamsterController : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nm;

    public string HamState = "Idle";
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("rigged-dude");
        nm = GetComponent<NavMeshAgent>();

        HamState = "Idle";
        nm.stoppingDistance = 4f;
        nm.updateRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis <= 40)
        {
            HamState = "Chase";
            nm.SetDestination(player.transform.position);
        }
        else
        {
            HamState = "Idle";
        }
        
    }
}
