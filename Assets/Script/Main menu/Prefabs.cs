using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public PrefabData prefabData;
    public GameObject[] prefabs;
    private bool prefabSpawn = false;
    public GameObject newPrefab;
    private int lastIndex;
    private GameObject topColorCube;
    public Material myCustomMaterial;


    private void Awake()
    {
        if (prefabData.firstSpawn == false)
        {
            SpawnPrefab();
            prefabData.firstSpawn = true;
        }
    }

    private void Update()
    {
        PrefabSpawn();
    }

    private void SpawnPrefab()
    {
        newPrefab = Instantiate(prefabs[prefabData.prefabIndex], transform.position, Quaternion.identity);
        lastIndex = newPrefab.transform.childCount - 1;
        GameObject topCube = GameObject.Find("TopCube").gameObject;
        GameObject botCube = GameObject.Find("BotCube").gameObject;
        GameObject prefabsControl = GameObject.Find("Prefabs counter control").gameObject;

        newPrefab.transform.GetChild(prefabData.i).GetChild(1).gameObject.gameObject.SetActive(true);
        newPrefab.transform.GetChild(prefabData.i).GetComponent<UpdateBarRanges>().enabled = true;

        if (prefabData.firstSpawn == false)
        {
            for (int i = 0; i < prefabData.i; i++)
            {
                newPrefab.transform.GetChild(i).gameObject.GetComponent<Renderer>().material = myCustomMaterial;
            }
        }

        DontDestroyOnLoad(newPrefab);
        DontDestroyOnLoad(topCube);
        DontDestroyOnLoad(botCube);
        DontDestroyOnLoad(prefabsControl);
    }

    private void PrefabSpawn()
    {
        if (prefabData.imageCounter <= 0 && !prefabSpawn && newPrefab.transform.GetChild(lastIndex).GetChild(1).gameObject.activeSelf)
        {
            StartCoroutine(PrefabSpawnSecond());
            prefabSpawn = true;
        }
    }

    IEnumerator PrefabBoolSecond()
    {
        yield return new WaitForSeconds(3);
        prefabSpawn = false;
    }
    IEnumerator PrefabSpawnSecond()
    {
        yield return new WaitForSeconds(2.2f);
        Destroy(newPrefab);
        prefabData.prefabIndex++;
        if (prefabData.prefabIndex >= prefabs.Length)
        {
            prefabData.prefabIndex = 0;
        }
        topColorCube = GameObject.Find("TopCube").GetComponent<Transform>().gameObject;
        prefabData.currentPosition.y = 0.17f;
        topColorCube.transform.position = prefabData.currentPosition;
        DiamondCounterAnimationMainMenu diamondCounterAnimationMainMenu;
        diamondCounterAnimationMainMenu = GameObject.Find("Animate diamond").GetComponent<DiamondCounterAnimationMainMenu>();
        diamondCounterAnimationMainMenu.PrefabReferenceIReset();
        SpawnPrefab();
        diamondCounterAnimationMainMenu.PrefabReference();
        StartCoroutine(PrefabBoolSecond());
    }
}