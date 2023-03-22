using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject[] enemyDirectionTarget;
    private Transform[] enemyDirectionTargetTransform;
    public ParticleSystem deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnemyTriggerControl");
        agent = GetComponent<NavMeshAgent>();
        enemyDirectionTarget = GameObject.FindGameObjectsWithTag("EnemyDirectionTarget");
        enemyDirectionTargetTransform = new Transform[enemyDirectionTarget.Length];
        for (int i = 0; i < enemyDirectionTarget.Length; i++)
        {
            enemyDirectionTargetTransform[i] = enemyDirectionTarget[i].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChooseTarget();
    }
    private void OnTriggerEnter(Collider other)
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
        NavMeshPath path = null;
        NavMeshPath shortestPatch = null;
        for (int i = 0; i < enemyDirectionTargetTransform.Length; i++)
        {
            if (enemyDirectionTargetTransform[i] == null)
            {
                continue;
            }
            path = new NavMeshPath();
            if (NavMesh.CalculatePath(transform.position, enemyDirectionTargetTransform[i].position, agent.areaMask, path))
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
    IEnumerator EnemyTriggerControl()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Collider>().isTrigger = true;
    }
}
