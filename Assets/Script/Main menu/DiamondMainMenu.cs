using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondMainMenu : MonoBehaviour
{
    //TMPro.TMP_Text diamondUIText;
    ObjectColorChange objectColorChange;
    private bool counter = false;
    public PrefabData prefabData;
    DiamondCounterAnimationMainMenu diamondCounterAnimationMainMenu;

    private void Awake()
    {
        //diamondUIText = GetComponent<TMPro.TMP_Text>();
        GameObject animateDiamond = GameObject.Find("Animate diamond");
        diamondCounterAnimationMainMenu = animateDiamond.GetComponent<DiamondCounterAnimationMainMenu>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            //diamondUIText = GetComponent<TMPro.TMP_Text>();
            objectColorChange = FindObjectOfType<ObjectColorChange>();
            GameObject animateDiamond = GameObject.Find("Animate diamond");
            diamondCounterAnimationMainMenu = animateDiamond.GetComponent<DiamondCounterAnimationMainMenu>();
        }
    }

    void Update()
    {
        //diamondUIText.text = Mathf.FloorToInt(prefabData.imageCounter).ToString();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (DiamondCounter.instance.Diamonds > 0)
                {
                    diamondCounterAnimationMainMenu.AddDiamondMainMenu();
                }
                else
                {
                    DiamondCounter.instance.Diamonds = 0;
                }
            }
        }

        if (prefabData.imageCounter <= 0 && counter == false)
        {
            diamondCounterAnimationMainMenu.isPaused = true;
            prefabData.imageCounter = 0;
            StartCoroutine(PauseLoopForSeconds(1.6f));
        }
        else
        {
            counter = false;
            diamondCounterAnimationMainMenu.isPaused = false;
        }

    }
    IEnumerator PauseLoopForSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
        prefabData.imageCounter = 100;
        GameObject prefab = transform.root.gameObject;
        ObjectStack objectStack = prefab.GetComponent<ObjectStack>();
        objectStack.ObjectColorCounter();
        counter = true;
    }
}
