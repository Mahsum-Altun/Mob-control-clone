using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColorChange : MonoBehaviour
{
    private GameObject topCube;
    public float cubeSpeed;
    public PrefabData prefabData;
    public bool cubeMove = false;

    private void Start()
    {
        topCube = gameObject;
        topCube.transform.position = prefabData.currentPosition;
    }

    public void CubeMovement()
    {
        prefabData.currentPosition.y += 0.004f;
        topCube.transform.position = prefabData.currentPosition;
    }
}
