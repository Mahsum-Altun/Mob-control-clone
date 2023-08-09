using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static int currentLevelIndex = 1;

    public void LoadNextLevel()
    {
        LoadLevel(currentLevelIndex);
        currentLevelIndex++;
        if (currentLevelIndex > 5)
        {
            currentLevelIndex = 1;
        }
    }

    private void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
