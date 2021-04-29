using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HamsterController : MonoBehaviour
{
    HealthSystem hs;
    GameObject player;
    NavMeshAgent nm;
    public GameObject thisThang;

    private float attackDis = 12.5f;
    public string HamState = "Idle";
    public bool IsAlerted = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("rigged-dude");
        nm = GetComponent<NavMeshAgent>();
        hs = GetComponent<HealthSystem>();

        HamState = "Idle";
        nm.stoppingDistance = attackDis;
        nm.updateRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis <= 70 && hs.health > 0 && dis >= attackDis && hs.health > 0 && !IsAlerted && hs.health > 0)
        {
            HamState = "Chase";
            nm.isStopped = false;
            nm.SetDestination(player.transform.position);
        }
        else if (dis < attackDis && hs.health > 0 || IsAlerted && hs.health > 0)
        {
            HamState = "Attack";
            nm.isStopped = true;

            Vector3 dir = gameObject.transform.position - player.transform.position;
            Quaternion targetRot = Quaternion.LookRotation(-dir, Vector3.up);
            transform.rotation = AnimMath.Slide(transform.rotation, targetRot, 0.01f);
        } else if (hs.health <= 0)
        {
            HamState = "Death";
            nm.isStopped = true;
            thisThang.gameObject.SetActive(false);
        }
        else if(dis > 70 && hs.health > 0 && !IsAlerted && hs.health > 0)
        {
            HamState = "Idle";
            nm.isStopped = true;
        }
    }
}
