using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextReference : MonoBehaviour
{
    private TMPro.TextMeshProUGUI goldUIText;
    private TMPro.TextMeshProUGUI diamondUIText;
    private int startGoldValue = 0;
    private int startDiamondValue = 0;
    private float timeElapsed;
    private float animationDuration = 1.5f;

    public void TextReferenceDiamond()
    {
        diamondUIText = GameObject.Find("Diamond score text").GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void TextReferenceGold()
    {
        goldUIText = GameObject.Find("Gold score text").GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void Gold()
    {
        StartCoroutine(AnimateGoldScoreText());
    }

    private IEnumerator AnimateGoldScoreText()
    {
        while (timeElapsed < animationDuration)
        {
            timeElapsed += Time.deltaTime;

            float progress = timeElapsed / animationDuration;
            int newGoldValue = Mathf.FloorToInt(Mathf.Lerp(startGoldValue, GoldCounter.instance.levelGold, progress));

            goldUIText.text = newGoldValue.ToString();

            yield return null;
        }

        goldUIText.text = Mathf.FloorToInt(GoldCounter.instance.levelGold).ToString();
    }
    public void Diamond()
    {
        StartCoroutine(AnimateDiamondScoreText());
    }
    private IEnumerator AnimateDiamondScoreText()
    {
        while (timeElapsed < animationDuration)
        {
            timeElapsed += Time.deltaTime;

            float progress = timeElapsed / animationDuration;
            int newDiamondValue = Mathf.FloorToInt(Mathf.Lerp(startDiamondValue, DiamondCounter.instance.Diamonds, progress));

            diamondUIText.text = newDiamondValue.ToString();

            yield return null;
        }

        diamondUIText.text = Mathf.FloorToInt(DiamondCounter.instance.Diamonds).ToString();
    }
}
