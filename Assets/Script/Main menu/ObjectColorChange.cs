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
        prefabData.cubeTransform.position = prefabData.currentPosition;
    }

    public void CubeMovement()
    {
        prefabData.cubeTransform = topCube.transform;
        prefabData.currentPosition = prefabData.cubeTransform.position;
        prefabData.currentPosition.y += 0.001f * cubeSpeed * Time.deltaTime;
        prefabData.cubeTransform.position = prefabData.currentPosition;
    }
}
