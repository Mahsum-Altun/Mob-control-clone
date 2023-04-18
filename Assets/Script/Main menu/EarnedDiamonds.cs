using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnedDiamonds : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text diamondUIText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        diamondUIText.text = Mathf.FloorToInt(DiamondCounter.instance.Diamonds).ToString();
    }
}
