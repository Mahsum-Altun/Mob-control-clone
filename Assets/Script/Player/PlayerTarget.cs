using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerTarget : MonoBehaviour
{
    private GameObject parent;
    public GameObject small;
    public GameObject big;
    public float halfWidth;
    public ParticleSystem deathParticles;
    private GameObject[] targets;
    private Transform[] targetTransforms;
    DiamondCounterAnimationLevel DiamondCounterAnimationLevel;
    private AudioSource destroySound;
    private Animator animator;
    private Rigidbody rb;
    public float moveSpeed;
    public float initialSpeed;
    public float targetSpeed;
    public float duration;
    private float distanceThreshold;
    private Quaternion initialRotation;

    private void Awake()
    {
        GameObject animateDiamond = GameObject.Find("Animate diamond");
        DiamondCounterAnimationLevel = animateDiamond.GetComponent<DiamondCounterAnimationLevel>();

        GameObject[] homes = GameObject.FindGameObjectsWithTag("Home");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        targets = new GameObject[homes.Length + enemies.Length];
        homes.CopyTo(targets, 0);
        enemies.CopyTo(targets, homes.Length);

        targetTransforms = new Transform[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            targetTransforms[i] = targets[i].transform;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        destroySound = GetComponent<AudioSource>();
        parent = GameObject.Find("Blue And Yellow Parent");
        if (tag == "Small" || tag == "Big")
        {
            moveSpeed = initialSpeed;
        }
        Invoke("ChangeSpeed", duration);
        initialRotation = transform.rotation;
    }
    void ChangeSpeed()
    {
        moveSpeed = targetSpeed;
    }
    private void Update()
    {
        ChooseTarget();
    }
    public void ChooseTarget()
    {
        float closestTargetDistance = float.MaxValue;
        Transform selectedTarget = null;

        foreach (Transform target in targetTransforms)
        {
            if (target == null)
            {
                continue;
            }

            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0;
            float distance = targetDirection.magnitude;
            if (distance < closestTargetDistance)
            {
                closestTargetDistance = distance;
                selectedTarget = target;
            }
        }

        if (selectedTarget != null)
        {
            Vector3 movementDirection = transform.forward;
            rb.velocity = movementDirection * moveSpeed * Time.deltaTime;
            if (selectedTarget.gameObject.tag == "Home")
            {
                distanceThreshold = 40;
            }
            else if (selectedTarget.gameObject.tag == "Enemy")
            {
                distanceThreshold = 10;
            }
            if (closestTargetDistance < distanceThreshold)
            {
                Vector3 targetDirection = selectedTarget.position - transform.position;
                targetDirection.y = 0;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = targetRotation;
            }
            else
            {
                transform.rotation = initialRotation;
            }
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
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy Big")
        {
            GoldCounter.instance.levelGold++;
            TMPro.TextMeshProUGUI goldUIText;
            goldUIText = GameObject.Find("Gold counter").GetComponent<TMPro.TextMeshProUGUI>();
            goldUIText.text = Mathf.FloorToInt(GoldCounter.instance.levelGold).ToString("n0");
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
