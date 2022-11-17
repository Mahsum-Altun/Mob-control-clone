using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerTarget : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject home1;
    public GameObject home2;
    public GameObject home3;
    public GameObject homeParent;
    public bool homeDestroy2 = false;
    public bool homeDestroy3 = false;
    public GameObject spawnPoint;
    public GameObject parent;
    public GameObject small;
    public GameObject big;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        homeParent = GameObject.Find("Home Parent");
        home1 = homeParent.transform.GetChild(0).gameObject;
        home2 = homeParent.transform.GetChild(1).gameObject;
        home3 = homeParent.transform.GetChild(2).gameObject;
        parent = GameObject.Find("Blue And Yellow Parent");
    }
    private void Update()
    {
        if (homeDestroy2 == true && homeDestroy3 == false)
        {
            agent.SetDestination(home3.transform.position);
        }
        else if (homeDestroy2 == false && homeDestroy3 == true)
        {
            agent.SetDestination(home2.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            agent.SetDestination(home1.transform.position);
        }
        else if (other.gameObject.tag == "Road 2")
        {
            agent.SetDestination(home2.transform.position);
        }
        else if (other.gameObject.tag == "Road 3")
        {
            agent.SetDestination(home3.transform.position);
        }
        if (other.gameObject.tag == "X4 Home1" || other.gameObject.tag == "X4 Home2" || other.gameObject.tag == "X4 Home3")
        {
            if (tag == "Small")
            {
                StartCoroutine("XspawnSmall");
            }
            else if (tag == "Big")
            {
                StartCoroutine("XspawnBig");
            }
        }
    }
    IEnumerator XspawnSmall()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject mySmall1 = Instantiate(small, small.transform.position, small.transform.rotation);
        GameObject mySmall2 = Instantiate(small, small.transform.position, small.transform.rotation);
        GameObject mySmall3 = Instantiate(small, small.transform.position, small.transform.rotation);
        mySmall1.transform.parent = parent.transform;
        mySmall2.transform.parent = parent.transform;
        mySmall3.transform.parent = parent.transform;
    }
    IEnumerator XspawnBig()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject myBig1 = Instantiate(big, big.transform.position, big.transform.rotation);
        GameObject myBig2 = Instantiate(big, big.transform.position, big.transform.rotation);
        GameObject myBig3 = Instantiate(big, big.transform.position, big.transform.rotation);
        myBig1.transform.parent = parent.transform;
        myBig2.transform.parent = parent.transform;
        myBig3.transform.parent = parent.transform;
    }
}
