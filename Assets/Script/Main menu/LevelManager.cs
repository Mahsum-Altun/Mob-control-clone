using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static int currentLevelIndex = 1;

    public void Start()
    {
        Debug.Log(currentLevelIndex);
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex > 5)
        {
            currentLevelIndex = 1;
        }
        LoadLevel(1);
    }

    private void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
