using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DiamondCounterAnimationMainMenu : MonoBehaviour
{
    public PrefabData prefabData;
    private Prefabs prefabs;
    [Header("UI references")]
    //[SerializeField] TMPro.TMP_Text diamondUIText;
    [SerializeField] GameObject animatedDiamondPrefab;
    [SerializeField] Transform target;

    [Space]
    [Header("Available diamond : (diamond to pool)")]
    [SerializeField] int maxDiamond;
    Queue<GameObject> diamondQueue = new Queue<GameObject>();

    [Space]
    [Header("Animation settings")]
    [SerializeField][Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField][Range(0.9f, 2f)] float maxAnimDuration;

    [SerializeField] Ease easeType;

    Vector3 targetPosition;


    public bool isPaused = false;
    public TMPro.TMP_Text diamondUIText;

    ObjectColorChange objectColorChange;

    private void Awake()
    {
        objectColorChange = FindObjectOfType<ObjectColorChange>();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        prefabs = GameObject.Find("Prefabs counter control").GetComponent<Prefabs>();
        PrefabReference();
        diamondUIText.text = Mathf.FloorToInt(prefabData.imageCounter).ToString();

        //Prepare Pool
        PrepareDiamonds();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            prefabs = GameObject.Find("Prefabs counter control").GetComponent<Prefabs>();
            PrefabReference();
            objectColorChange = FindObjectOfType<ObjectColorChange>();
        }
    }

    void PrepareDiamonds()
    {
        GameObject diamond;
        for (int i = 0; i < maxDiamond; i++)
        {
            diamond = Instantiate(animatedDiamondPrefab);
            diamond.transform.parent = transform;
            diamond.SetActive(false);
            diamondQueue.Enqueue(diamond);
        }
    }

    void AnimateMainMenu(Vector3 collectedDiamondPosition, int amount)
    {
        if (!isPaused && prefabData.imageCounter >= 0)
        {
            for (int i = 0; i < amount; i++)
            {
                //Check if there's diamond in the pool
                if (diamondQueue.Count > 0)
                {
                    //extract a diamond from the pool
                    GameObject diamond = diamondQueue.Dequeue();
                    diamond.SetActive(true);
                    prefabData.imageCounter--;
                    DiamondCounter.instance.Diamonds--;

                    //moce diamond to the collected diamond pos
                    diamond.transform.position = collectedDiamondPosition;

                    //Animate diamond to target position
                    float duration = Random.Range(minAnimDuration, maxAnimDuration);
                    diamond.transform.DOMove(targetPosition, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        //executes whenever coin reach target position
                        diamond.SetActive(false);
                        diamondQueue.Enqueue(diamond);
                        if (prefabData.imageCounter >= 0)
                        {
                            diamondUIText.text = Mathf.FloorToInt(prefabData.imageCounter).ToString();
                            objectColorChange.CubeMovement();
                        }
                    });
                }
            }
        }
    }

    public void PrefabReference()
    {
        diamondUIText = prefabs.newPrefab.transform.GetChild(prefabData.i).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMPro.TMP_Text>();
        target = prefabs.newPrefab.transform.GetChild(prefabData.i).GetComponent<Transform>();
        targetPosition = target.position;
    }
    public void PrefabReferenceIReset()
    {
        prefabData.i = 0;
    }
    public void PrefabReferenceIPlus()
    {
        prefabData.i++;
    }

    public void AddDiamondMainMenu()
    {
        AnimateMainMenu(transform.position, 1);
    }
}
