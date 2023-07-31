using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theree : MonoBehaviour
{
    public GameObject number2;
    private Animator number2Anim;
    public void Number3()
    {
        number2.SetActive(true);
        number2Anim = number2.GetComponent<Animator>();
        number2Anim.SetTrigger("2");
        gameObject.SetActive(false);
    }
}
