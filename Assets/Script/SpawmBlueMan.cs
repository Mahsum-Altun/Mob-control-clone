using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawmBlueMan : MonoBehaviour
{
    public GameObject small;
    public GameObject big;
    public GameObject spawnPoint;
    public GameObject parent;
    private NavMeshAgent agent;
    EnergyBarAttack energyBarAttack;
    public void Spawn()
    {
        if (energyBarAttack.currentEnergy != 100)
        {
            GameObject mySmall = Instantiate(small, spawnPoint.transform.position, spawnPoint.transform.rotation);
            mySmall.transform.parent = parent.transform;
            agent = mySmall.GetComponent<NavMeshAgent>();
            agent.speed = 40f;
            StartCoroutine("AgentSpeed");
        }
        else
        {
            GameObject myBig = Instantiate(big, spawnPoint.transform.position, spawnPoint.transform.rotation);
            myBig.transform.parent = parent.transform;
            agent = myBig.GetComponent<NavMeshAgent>();
            agent.speed = 40f;
            StartCoroutine("AgentSpeed");
        }
    }
    IEnumerator AgentSpeed()
    {
        yield return new WaitForSeconds(0.3f);
        agent.speed = 10f;
    }
}
