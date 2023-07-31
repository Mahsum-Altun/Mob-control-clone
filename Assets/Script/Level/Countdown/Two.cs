using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : MonoBehaviour
{
    public GameObject number1;
    private Animator number1Anim;
    public void Number2()
    {
        number1.SetActive(true);
        number1Anim = number1.GetComponent<Animator>();
        number1Anim.SetTrigger("1");
        gameObject.SetActive(false);
    }
}
