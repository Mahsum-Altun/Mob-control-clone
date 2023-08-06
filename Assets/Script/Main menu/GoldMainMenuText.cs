using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMainMenuText : MonoBehaviour
{
    private TMPro.TextMeshProUGUI goldText;

    void Start()
    {
        goldText = GetComponent<TMPro.TextMeshProUGUI>();
        GoldCounter.instance.Gold += GoldCounter.instance.levelGold;
        GoldCounter.instance.levelGold = 0;
        goldText.text = Mathf.FloorToInt(GoldCounter.instance.Gold).ToString("n0");
    }
}
