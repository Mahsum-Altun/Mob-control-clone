using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiamondCounterAnimationLevel : MonoBehaviour
{
    [Header("UI references")]
    [SerializeField] TMPro.TMP_Text diamondUIText;
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



    private void Awake()
    {
        //Prepare Pool
        PrepareDiamonds();
    }
    private void Update()
    {
        targetPosition = target.position;
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

    void Animate(Vector3 collectedDiamondPosition, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //Check if there's diamond in the pool
            if (diamondQueue.Count > 0)
            {
                //extract a diamond from the pool
                GameObject diamond = diamondQueue.Dequeue();
                diamond.SetActive(true);

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

                    DiamondCounter.instance.Diamonds++;
                    diamondUIText.text = Mathf.FloorToInt(DiamondCounter.instance.Diamonds).ToString();
                    GameObject.Find("Diamond").GetComponent<DiamondAnimation>().DiamondShake();
                });
            }
        }
    }

    public void AddDiamond(Vector3 collectedDiamondPosition, int amount)
    {
        Animate(collectedDiamondPosition, amount);
    }
}
