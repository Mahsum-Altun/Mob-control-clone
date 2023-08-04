using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondMainMenu : MonoBehaviour
{
    ObjectColorChange objectColorChange;
    public PrefabData prefabData;
    DiamondCounterAnimationMainMenu diamondCounterAnimationMainMenu;
    private GameObject diamondTarget;
    private Animator animator;
    public bool isPausedControl = false;
    private AudioSource diamondTouchSound;
    private bool soundControl = false;

    private void Awake()
    {
        diamondTouchSound = transform.root.GetComponent<AudioSource>();
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
                    if (soundControl == false)
                    {
                        diamondTouchSound.Play();
                        soundControl = true;
                    }
                }
                else
                {
                    DiamondCounter.instance.Diamonds = 0;
                }
            }
            else
            {
                soundControl = false;
            }
        }

        if (prefabData.imageCounter <= 0 && isPausedControl == false)
        {
            diamondCounterAnimationMainMenu.isPaused = true;
            prefabData.imageCounter = 0;
            StartCoroutine(PauseLoopForSeconds(1.6f));
            isPausedControl = true;
        }

    }
    IEnumerator PauseLoopForSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
        prefabData.imageCounter = 100;
        diamondCounterAnimationMainMenu.isPausedControl = prefabData.imageCounter;
        GameObject prefab = transform.root.gameObject;
        ObjectStack objectStack = prefab.GetComponent<ObjectStack>();
        int lastIndex;
        lastIndex = prefab.transform.childCount - 1;
        if (!prefab.transform.GetChild(lastIndex).GetChild(1).gameObject.activeSelf)
        {
            objectStack.ObjectColorCounter();
            diamondCounterAnimationMainMenu.isPaused = false;
        }
        isPausedControl = false;
    }
}
