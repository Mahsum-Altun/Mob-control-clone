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
    public float halfWidth;
    public ParticleSystem deathParticles;

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
        if (other.gameObject.tag == "X4")
        {
            if (tag == "Small" || tag == "Small X2")
            {
                tag = "Small No X";
                StartCoroutine("X4spawnSmall");
            }
            else if (tag == "Big" || tag == "Big X2")
            {
                tag = "Big No X";
                StartCoroutine("X4spawnBig");
            }
        }
        else if (other.gameObject.tag == "X3")
        {
            if (tag == "Small" || tag == "Small X2")
            {
                tag = "Small No X";
                StartCoroutine("X3spawnSmall");
            }
            else if (tag == "Big" || tag == "Big X2")
            {
                tag = "Big No X";
                StartCoroutine("X3spawnBig");
            }
        }
        else if (other.gameObject.tag == "X2")
        {
            if (tag == "Small")
            {
                tag = "Small X2";
                StartCoroutine("X2spawnSmall");
            }
            else if (tag == "Big")
            {
                tag = "Big X2";
                StartCoroutine("X2spawnBig");
            }
        }
        if (other.gameObject.tag == "Home")
        {
            if (gameObject.layer == 6)
            {
                DeathWithParticlesSmall();
                other.transform.GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue -= 1;
                other.transform.GetComponent<HomeAnimation>().HomeAttack();
                if (other.transform.GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue == 0)
                {
                    other.transform.root.GetChild(0).GetChild(1).GetComponent<MissionCompleted>().missionFinished = true;
                    other.transform.root.GetChild(0).GetChild(1).transform.parent = null;
                    other.transform.parent.GetComponent<HomeDestroy>().Destroy();
                }
            }
            else if (gameObject.layer == 3)
            {
                DeathWithParticlesBig();
                other.transform.GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue -= 1;
                other.transform.GetComponent<HomeAnimation>().HomeAttack();
                if (other.transform.GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue == 0)
                {
                    other.transform.root.GetChild(0).GetChild(1).GetComponent<MissionCompleted>().missionFinished = true;
                    other.transform.root.GetChild(0).GetChild(1).transform.parent = null;
                    other.transform.parent.GetComponent<HomeDestroy>().Destroy();
                }
            }

        }
    }
    IEnumerator X4spawnSmall()
    {
        yield return null;
        GameObject mySmall1 = Instantiate(small, new Vector3(small.transform.position.x, small.transform.position.y, small.transform.position.z + halfWidth), small.transform.rotation);
        GameObject mySmall2 = Instantiate(small, new Vector3(small.transform.position.x, small.transform.position.y, small.transform.position.z + halfWidth), small.transform.rotation);
        GameObject mySmall3 = Instantiate(small, new Vector3(small.transform.position.x, small.transform.position.y, small.transform.position.z + halfWidth), small.transform.rotation);
        mySmall1.transform.parent = parent.transform;
        mySmall1.tag = "Small No X";
        mySmall2.transform.parent = parent.transform;
        mySmall2.tag = "Small No X";
        mySmall3.transform.parent = parent.transform;
        mySmall3.tag = "Small No X";
    }
    IEnumerator X4spawnBig()
    {
        yield return null;
        GameObject myBig1 = Instantiate(big, new Vector3(big.transform.position.x, big.transform.position.y, big.transform.position.z + halfWidth), big.transform.rotation);
        GameObject myBig2 = Instantiate(big, new Vector3(big.transform.position.x, big.transform.position.y, big.transform.position.z + halfWidth), big.transform.rotation);
        GameObject myBig3 = Instantiate(big, new Vector3(big.transform.position.x, big.transform.position.y, big.transform.position.z + halfWidth), big.transform.rotation);
        myBig1.transform.parent = parent.transform;
        myBig1.tag = "Big No X";
        myBig2.transform.parent = parent.transform;
        myBig2.tag = "Big No X";
        myBig3.transform.parent = parent.transform;
        myBig3.tag = "Big No X";
    }
    IEnumerator X3spawnSmall()
    {
        yield return null;
        GameObject mySmall1 = Instantiate(small, new Vector3(small.transform.position.x, small.transform.position.y, small.transform.position.z + halfWidth), small.transform.rotation);
        GameObject mySmall2 = Instantiate(small, new Vector3(small.transform.position.x, small.transform.position.y, small.transform.position.z + halfWidth), small.transform.rotation);
        mySmall1.transform.parent = parent.transform;
        mySmall1.tag = "Small No X";
        mySmall2.transform.parent = parent.transform;
        mySmall2.tag = "Small No X";
    }
    IEnumerator X3spawnBig()
    {
        yield return null;
        GameObject myBig1 = Instantiate(big, new Vector3(big.transform.position.x, big.transform.position.y, big.transform.position.z + halfWidth), big.transform.rotation);
        GameObject myBig2 = Instantiate(big, new Vector3(big.transform.position.x, big.transform.position.y, big.transform.position.z + halfWidth), big.transform.rotation);
        myBig1.transform.parent = parent.transform;
        myBig1.tag = "Big No X";
        myBig2.transform.parent = parent.transform;
        myBig2.tag = "Big No X";
    }
    IEnumerator X2spawnSmall()
    {
        yield return null;
        GameObject mySmall1 = Instantiate(small, new Vector3(small.transform.position.x + halfWidth, small.transform.position.y, small.transform.position.z + halfWidth), small.transform.rotation);
        mySmall1.transform.parent = parent.transform;
        mySmall1.tag = "Small X2";
    }
    IEnumerator X2spawnBig()
    {
        yield return null;
        GameObject myBig1 = Instantiate(big, new Vector3(big.transform.position.x, big.transform.position.y, big.transform.position.z + halfWidth), big.transform.rotation);
        myBig1.transform.parent = parent.transform;
        myBig1.tag = "Big X2";
    }
    private void DeathWithParticlesSmall()
    {
        Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void DeathWithParticlesBig()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        StartCoroutine("BigScale");
    }
    IEnumerator BigScale()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
