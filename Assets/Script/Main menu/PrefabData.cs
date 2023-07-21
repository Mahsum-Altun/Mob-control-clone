using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPrefabData", menuName = "Prefab Data", order = 1)]
public class PrefabData : ScriptableObject
{
    public int prefabIndex = 0;
    public int imageCounter = 100;
    public bool firstSpawn = false;
    public int i = 0;
    public Vector3 currentPosition;
    private void OnDisable()
    {
        firstSpawn = false;
    }
}
