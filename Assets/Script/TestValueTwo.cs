using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestValueTwo : MonoBehaviour
{
    public int sceneNumber;
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
