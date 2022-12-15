using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHome : MonoBehaviour
{
    public int scoreValue = 50;
    TMPro.TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreValue;
    }
}
