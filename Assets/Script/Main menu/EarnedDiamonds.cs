using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnedDiamonds : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text diamondUIText;

    // Update is called once per frame
    void Update()
    {
        diamondUIText.text = Mathf.FloorToInt(DiamondCounter.instance.Diamonds).ToString("n0");
    }
}
