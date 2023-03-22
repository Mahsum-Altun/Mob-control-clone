using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testvalue : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text diamondUIText;
    // Start is called before the first frame update
    void Start()
    {
        diamondUIText.text = DiamondCounter.instance.Diamonds.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
