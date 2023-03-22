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

    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.GetChild(0).GetChild(8).GetComponent<Transform>();
        enemyParent = transform.GetChild(0).GetChild(9).gameObject;
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
        for (int i = 0; i < 10; i++)
        {
            GameObject enemySmall1 = Instantiate(small, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), small.transform.rotation);
            enemySmall1.transform.parent = enemyParent.transform;
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject enemyBig1 = Instantiate(big, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), big.transform.rotation);
            enemyBig1.transform.parent = enemyParent.transform;
        }
    }
}
