using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BallWalk : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] wayPoints;
    int wayPoint = 0;
    public bool coroutine = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if (coroutine)
        {
            agent.SetDestination(wayPoints[wayPoint].position);
            coroutine = false;
            if (Vector3.Distance(wayPoints[wayPoint].position, transform.position) < 5)
            {
                wayPoint++;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "waypoints")
        {
            coroutine = true;
        }
        if (other.gameObject.tag == "TouchControl")
        {
            GameObject.Find("Ball and canvas").GetComponent<InputControl>().enabled = true;
        }
    }
}
