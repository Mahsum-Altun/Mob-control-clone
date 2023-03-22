using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEx : MonoBehaviour
{
    public void DestroyChild()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
