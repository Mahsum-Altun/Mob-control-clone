using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour
{
    private GameObject[] targets;
    private Transform[] targetTransforms;
    public ParticleSystem deathParticles;
    private Rigidbody rb;
    public float moveSpeed;
    public float initialSpeed;
    public float targetSpeed;
    public float duration;
    private float distanceThreshold;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject[] enemyDirectionTarget = GameObject.FindGameObjectsWithTag("EnemyDirectionTarget");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Small");

        targets = new GameObject[enemyDirectionTarget.Length + enemies.Length];
        enemyDirectionTarget.CopyTo(targets, 0);
        enemies.CopyTo(targets, enemyDirectionTarget.Length);

        targetTransforms = new Transform[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            targetTransforms[i] = targets[i].transform;
        }
        moveSpeed = initialSpeed;
        Invoke("ChangeSpeed", duration);
        initialRotation = transform.rotation;
    }
    void ChangeSpeed()
    {
        moveSpeed = targetSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ChooseTarget();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6 || gameObject.layer == 3)
        {
            if (tag == "Enemy")
            {
                DeathWithParticlesSmall();
            }
            else if (tag == "Enemy Big")
            {
                DeathWithParticlesBig();
            }
        }
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
            Vector3 targetDirection = selectedTarget.position - transform.position;
            targetDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = targetRotation;
            Vector3 movementDirection = transform.forward;
            rb.velocity = movementDirection * moveSpeed * Time.deltaTime;
        }
        if (selectedTarget != null)
        {
            Vector3 movementDirection = transform.forward;
            rb.velocity = movementDirection * moveSpeed * Time.deltaTime;
            if (selectedTarget.gameObject.tag == "EnemyDirectionTarget")
            {
                distanceThreshold = 40;
            }
            else if (selectedTarget.gameObject.tag == "Small")
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
