using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HamsterController : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nm;
    private float attackDis = 12.5f;
    public string HamState = "Idle";
    public bool IsAlerted = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("rigged-dude");
        nm = GetComponent<NavMeshAgent>();

        HamState = "Idle";
        nm.stoppingDistance = attackDis;
        nm.updateRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis <= 70 && dis >= attackDis && !IsAlerted)
        {
            HamState = "Chase";
            nm.isStopped = false;
            nm.SetDestination(player.transform.position);
        }
        else if (dis < attackDis || IsAlerted)
        {
            HamState = "Attack";
            nm.isStopped = true;
        }
        else
        {
            HamState = "Idle";
            nm.isStopped = true;
        }
        
    }
}
