using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStack : MonoBehaviour
{
    public PrefabData prefabData;
    private Transform topColorCube;
    private DiamondCounterAnimationMainMenu diamondCounterAnimationMainMenu;
    // Array representing the children of the prefab
    public Transform[] children;
    private Vector3 pos;
    // Variable to hold the index of the active child

    void Start()
    {
        // Assign the children of the prefab to the array
        children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i).transform;
        }
    }

    public void ObjectColorCounter()
    {
        children[prefabData.i].GetChild(1).gameObject.SetActive(false);
        children[prefabData.i].GetComponent<UpdateBarRanges>().enabled = false;
        topColorCube = GameObject.Find("TopCube").GetComponent<Transform>().transform;
        pos = topColorCube.position;
        pos.y = 0.17f;
        topColorCube.position = pos;

        diamondCounterAnimationMainMenu = GameObject.Find("Animate diamond").GetComponent<DiamondCounterAnimationMainMenu>();
        diamondCounterAnimationMainMenu.PrefabReferenceIPlus();
        diamondCounterAnimationMainMenu.PrefabReference();

        children[prefabData.i].GetChild(1).gameObject.SetActive(true);
        children[prefabData.i].GetComponent<UpdateBarRanges>().enabled = true;
    }
}
