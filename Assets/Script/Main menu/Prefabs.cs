using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public GameObject[] prefabs;
    private int i = 0;
    private DiamondMainMenu diamondMainMenu;
    private bool prefabSpawn = false;
    private GameObject newPrefab;


    private void Start()
    {
        SpawnPrefab();
    }

    private void Update()
    {
        PrefabSpawn();
    }

    private void SpawnPrefab()
    {
        int lastIndex = prefabs[i].transform.childCount - 1;
        newPrefab = Instantiate(prefabs[i], transform.position, Quaternion.identity);
        diamondMainMenu = newPrefab.transform.GetChild(lastIndex).GetChild(1).GetChild(0).GetChild(0).GetComponent<DiamondMainMenu>();
    }

    private void PrefabSpawn()
    {
        if (diamondMainMenu.imageCounter <= 95 && !prefabSpawn)
        {
            Destroy(newPrefab);
            i++;
            if (i >= prefabs.Length)
            {
                i = 0;
            }
            SpawnPrefab();
            StartCoroutine(PrefabBoolSecond());
            prefabSpawn = true;
        }
    }

    IEnumerator PrefabBoolSecond()
    {
        yield return new WaitForSeconds(2);
        prefabSpawn = false;
    }
}