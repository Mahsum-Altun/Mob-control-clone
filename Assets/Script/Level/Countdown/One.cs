using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One : MonoBehaviour
{
   public GameObject number0;
    private Animator number0Anim;
    public void Number1()
    {
        number0.SetActive(true);
        number0Anim = number0.GetComponent<Animator>();
        number0Anim.SetTrigger("0");
        gameObject.SetActive(false);
    }
}
