using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStack : MonoBehaviour
{
    public PrefabData prefabData;
    private GameObject topColorCube;
    private DiamondCounterAnimationMainMenu diamondCounterAnimationMainMenu;
    // Array representing the children of the prefab
    public Transform[] children;

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
        topColorCube = GameObject.Find("TopCube").GetComponent<Transform>().gameObject;
        prefabData.currentPosition.y = 0.02f;
        topColorCube.transform.position = prefabData.currentPosition;

        diamondCounterAnimationMainMenu = GameObject.Find("Animate diamond").GetComponent<DiamondCounterAnimationMainMenu>();
        diamondCounterAnimationMainMenu.PrefabReferenceIPlus();
        diamondCounterAnimationMainMenu.PrefabReference();

        children[prefabData.i].GetChild(1).gameObject.SetActive(true);
        children[prefabData.i].GetComponent<UpdateBarRanges>().enabled = true;
    }
}
