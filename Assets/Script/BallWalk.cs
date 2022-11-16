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
    public bool loopWayPoints = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    IEnumerator Patrol()
    {
        agent.SetDestination(wayPoints[wayPoint].position);
        while (true)
        {
            if (Vector3.Distance(wayPoints[wayPoint].position, transform.position) < 2)
            {
                if (wayPoint == wayPoints.Length - 1)
                {
                    if (loopWayPoints)
                    {
                        wayPoint = 0;
                        agent.SetDestination(wayPoints[0].position);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    wayPoint++;
                    agent.SetDestination(wayPoints[wayPoint].position);
                }
            }
            yield return new WaitForSeconds(.5f);
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutine) { StartCoroutine("Patrol"); }
    }
}
