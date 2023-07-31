using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondandGoldOriginalValue : MonoBehaviour
{
    public void OriginalScore()
    {
        GoldCounter.instance.OriginalGold();
        DiamondCounter.instance.OriginalDiamond();
    }
}
