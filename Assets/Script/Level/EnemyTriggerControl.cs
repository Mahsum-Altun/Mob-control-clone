using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerControl : MonoBehaviour
{
    private GameObject dangerStripObject;
    public List<GameObject> enemyList = new List<GameObject>();

    private void Start()
    {
        dangerStripObject = transform.parent.GetChild(3).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy Big")
        {
            if (!enemyList.Contains(other.gameObject))
            {
                enemyList.Add(other.gameObject);
                UpdateDangerStrip();
            }
        }
    }

    private void Update()
    {
        for (int i = enemyList.Count - 1; i >= 0; i--)
        {
            if (enemyList[i] == null)
            {
                enemyList.RemoveAt(i);
                UpdateDangerStrip();
            }
        }
    }

    private void UpdateDangerStrip()
    {
        dangerStripObject.gameObject.SetActive(enemyList.Count > 0);
    }
}
