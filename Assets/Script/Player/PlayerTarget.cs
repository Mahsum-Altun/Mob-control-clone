using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerTarget : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject parent;
    public GameObject small;
    public  GameObject big;
    public float halfWidth;
    public ParticleSystem deathParticles;
    private GameObject[] home;
    private Transform[] homeTransform;
    DiamondCounterAnimationLevel DiamondCounterAnimationLevel;
    private AudioSource destroySound;

    private void Awake()
    {
        GameObject animateDiamond = GameObject.Find("Animate diamond");
        DiamondCounterAnimationLevel = animateDiamond.GetComponent<DiamondCounterAnimationLevel>();
        home = GameObject.FindGameObjectsWithTag("Home");
        homeTransform = new Transform[home.Length];
        for (int i = 0; i < home.Length; i++)
        {
            homeTransform[i] = home[i].transform;
        }
    }
    private void Start()
    {
        destroySound = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        parent = GameObject.Find("Blue And Yellow Parent");
    }
    private void Update()
    {
        ChooseTarget();
    }
    public void ChooseTarget()
    {
        float closestTargetDistance = float.MaxValue;
        NavMeshPath path = null;
        NavMeshPath shortestPatch = null;
        for (int i = 0; i < homeTransform.Length; i++)
        {
            if (homeTransform[i] == null)
            {
                continue;
            }
            path = new NavMeshPath();
            if (NavMesh.CalculatePath(transform.position, homeTransform[i].position, agent.areaMask, path))
            {
                float distance = Vector3.Distance(transform.position, path.corners[0]);
                for (int j = 1; j < path.corners.Length; j++)
                {
                    distance += Vector3.Distance(path.corners[j - 1], path.corners[j]);
                }
                if (distance < closestTargetDistance)
                {
                    closestTargetDistance = distance;
                    shortestPatch = path;
                }
            }
        }
        if (shortestPatch != null)
        {
            agent.SetPath(shortestPatch);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
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
            DiamondCounterAnimationLevel.AddDiamond(transform.position, 1);
            if (gameObject.layer == 6)
            {
                DeathWithParticlesSmall();
                other.transform.GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue -= 1;
                other.transform.GetComponent<HomeAnimation>().HomeAttack();
                other.transform.parent.GetComponent<HomeDestroy>().HomeControl();
            }
            else if (gameObject.layer == 3)
            {
                DeathWithParticlesBig();
                other.transform.GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue -= 1;
                other.transform.GetComponent<HomeAnimation>().HomeAttack();
                other.transform.parent.GetComponent<HomeDestroy>().HomeControl();
            }

        }
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy Big")
        {
            GoldCounter.instance.Gold++;
            TMPro.TextMeshProUGUI goldUIText;
            goldUIText = GameObject.Find("Gold counter").GetComponent<TMPro.TextMeshProUGUI>();
            goldUIText.text = Mathf.FloorToInt(GoldCounter.instance.Gold).ToString("n0");
            if (gameObject.layer == 6)
            {
                DeathWithParticlesSmall();
            }
            else if (gameObject.layer == 3)
            {
                DeathWithParticlesBig();
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
        destroySound.Play();
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
