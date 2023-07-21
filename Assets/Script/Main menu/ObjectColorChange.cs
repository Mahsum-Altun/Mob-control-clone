using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColorChange : MonoBehaviour
{
    private GameObject topCube;
    public float cubeSpeed;
    public PrefabData prefabData;

    private void Start()
    {
        topCube = gameObject;
        topCube.transform.position = prefabData.currentPosition;
    }

    public void CubeMovement()
    {
        prefabData.currentPosition.y += 0.001f * cubeSpeed * Time.deltaTime;
        topCube.transform.position = prefabData.currentPosition;
    }
}
