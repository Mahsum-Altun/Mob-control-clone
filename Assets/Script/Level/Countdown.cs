using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject[] numbers;
    private Animator animator;
    private GameObject myGameObject;
    private int startGoldValue = 0;
    private int startDiamondValue = 0;
    private float timeElapsed;
    private TMPro.TextMeshProUGUI diamondUIText;
    private TMPro.TextMeshProUGUI goldUIText;
    private float animationDuration = 2.0f;

    public void Victory()
    {
        numbers[1].SetActive(true);
        animator = numbers[1].GetComponent<Animator>();
        animator.SetTrigger("3");
        numbers[0].SetActive(false);
    }
    public void Number3()
    {
        numbers[2].SetActive(true);
        animator = numbers[2].GetComponent<Animator>();
        animator.SetTrigger("2");
        numbers[1].SetActive(false);
    }
    public void Number2()
    {
        numbers[3].SetActive(true);
        animator = numbers[3].GetComponent<Animator>();
        animator.SetTrigger("1");
        numbers[2].SetActive(false);
    }
    public void Number1()
    {
        numbers[4].SetActive(true);
        animator = numbers[4].GetComponent<Animator>();
        animator.SetTrigger("0");
        numbers[3].SetActive(false);
    }
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
        diamondUIText = GameObject.Find("Diamond score text").GetComponent<TMPro.TextMeshProUGUI>();
        goldUIText = GameObject.Find("Gold score text").GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine(AnimateScoreText());
    }
    private IEnumerator AnimateScoreText()
    {
        while (timeElapsed < animationDuration)
        {
            timeElapsed += Time.deltaTime;

            float progress = timeElapsed / animationDuration;
            int newGoldValue = Mathf.FloorToInt(Mathf.Lerp(startGoldValue, GoldCounter.instance.Gold, progress));
            int newDiamondValue = Mathf.FloorToInt(Mathf.Lerp(startDiamondValue, DiamondCounter.instance.Diamonds, progress));

            diamondUIText.text = newDiamondValue.ToString();
            goldUIText.text = newGoldValue.ToString();

            yield return null;
        }

        diamondUIText.text = Mathf.FloorToInt(DiamondCounter.instance.Diamonds).ToString();
        goldUIText.text = Mathf.FloorToInt(GoldCounter.instance.Gold).ToString();
    }
}
