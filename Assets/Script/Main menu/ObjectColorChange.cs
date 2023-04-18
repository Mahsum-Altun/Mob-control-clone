using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColorChange : MonoBehaviour
{
    private GameObject topCube;

    private void Start()
    {
        topCube = gameObject;
    }

    public void CubeMovement()
    {
        Transform cubeTransform = topCube.transform;
        Vector3 currentPosition = cubeTransform.position;
        currentPosition.y += 0.001f;
        cubeTransform.position = currentPosition;//0.21
    }
}
