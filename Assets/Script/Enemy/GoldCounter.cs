using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    public int goldValue = 0;
    TMPro.TMP_Text gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = "" + goldValue;
    }
}
