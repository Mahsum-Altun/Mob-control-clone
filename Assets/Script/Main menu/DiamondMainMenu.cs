using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondMainMenu : MonoBehaviour
{
    ObjectColorChange objectColorChange;
    private bool counter = false;
    public PrefabData prefabData;
    DiamondCounterAnimationMainMenu diamondCounterAnimationMainMenu;
    private GameObject diamondTarget;
    private Animator animator;

    private void Awake()
    {
        diamondTarget = GameObject.Find("Diamond target");
        animator = diamondTarget.GetComponent<Animator>();
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
            objectColorChange = FindObjectOfType<ObjectColorChange>();
            diamondTarget = GameObject.Find("Diamond target");
            animator = diamondTarget.GetComponent<Animator>();
            GameObject animateDiamond = GameObject.Find("Animate diamond");
            diamondCounterAnimationMainMenu = animateDiamond.GetComponent<DiamondCounterAnimationMainMenu>();
        }
    }

    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Diamond target"))
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
