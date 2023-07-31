using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zero : MonoBehaviour
{
    public void LastHomeDetroy()
    {
        GameObject lastHomeObject = GameObject.FindObjectOfType<HomeDestroy>()?.gameObject;

        if (lastHomeObject != null)
        {
            lastHomeObject.GetComponent<HomeDestroy>()?.Destroy();
        }
        else
        {
            Debug.LogWarning("The object with the tag 'Last Home' could not be found.");
        }
    }
    public void SkorePanel()
    {
        GameObject scoreCanvas = GameObject.Find("Score");
        scoreCanvas.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
