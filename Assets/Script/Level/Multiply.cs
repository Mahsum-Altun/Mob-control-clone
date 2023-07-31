using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply : MonoBehaviour
{
    public GameObject multiplyXText;
    private TMPro.TextMeshProUGUI diamondUIText;
    private TMPro.TextMeshProUGUI goldUIText;
    private float animationDuration = 0.7f;
    private float timeElapsed;
    private int startGoldValue = 0;
    private int startDiamondValue = 0;

    public void XMultiply()
    {
        GameObject.Find("Arrow").GetComponent<Animator>().speed = 0f;
        multiplyXText.transform.GetChild(0).gameObject.SetActive(true);
        multiplyXText.transform.GetChild(1).gameObject.SetActive(true);
        multiplyXText.GetComponent<Animator>().enabled = true;
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
            int newDiamondValue = Mathf.FloorToInt(Mathf.Lerp(startDiamondValue, DiamondCounter.instance.Diamonds, progress));
            int newGoldValue = Mathf.FloorToInt(Mathf.Lerp(startGoldValue, GoldCounter.instance.Gold, progress));

            diamondUIText.text = newDiamondValue.ToString();
            goldUIText.text = newGoldValue.ToString();


            yield return null;
        }

        diamondUIText.text = Mathf.FloorToInt(DiamondCounter.instance.Diamonds).ToString();
        goldUIText.text = Mathf.FloorToInt(GoldCounter.instance.Gold).ToString();
    }
}
