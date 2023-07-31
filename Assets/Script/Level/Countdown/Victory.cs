using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject number3;
    private Animator number3Anim;
    public void VictoryObject()
    {
        number3.SetActive(true);
        number3Anim = number3.GetComponent<Animator>();
        number3Anim.SetTrigger("3");
        gameObject.SetActive(false);
    }
}
