using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int[] scoreValue;
    int score;
    public GameObject small;
    public GameObject big;
    Transform spawn;
    int index = -1;
    GameObject enemyParent;
    private Rigidbody rb;
    public float rbSpeed;
    private AudioSource enemySound;

    // Start is called before the first frame update
    void Start()
    {
        enemySound = GetComponent<AudioSource>();
        spawn = transform.GetChild(0).GetChild(8).GetComponent<Transform>();
        enemyParent = GameObject.Find("Enemy parent").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        score = transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue;
        for (int i = 0; i < scoreValue.Length && index == -1; i++)
        {
            if (scoreValue[i] == score)
            {
                EnemySpawn();
                enemySound.Play();
                index = i;
            }
        }
        CheckScoreValue();
    }
    void CheckScoreValue()
    {
        if (index != -1 && score != scoreValue[index])
        {
            index = -1;
        }
    }
    void EnemySpawn()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject enemySmall1 = Instantiate(small, spawn.transform.position, spawn.transform.rotation);
            enemySmall1.transform.parent = enemyParent.transform;
            rb = enemySmall1.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * rbSpeed);
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject enemyBig1 = Instantiate(big, spawn.transform.position, spawn.transform.rotation);
            enemyBig1.transform.parent = enemyParent.transform;
            rb = enemyBig1.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * rbSpeed);
        }
    }
}
