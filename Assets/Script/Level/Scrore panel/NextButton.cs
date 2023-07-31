using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public void OriginalScoreNext()
    {
        GoldCounter.instance.Gold = GoldCounter.instance.originalGold;
        DiamondCounter.instance.Diamonds = DiamondCounter.instance.originalDiamond;
    }
}
