using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAnimation : MonoBehaviour
{
    private  Animator homeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        homeAnimator = GetComponent<Animator>();
    }
    public void HomeAttack()
    {
        homeAnimator.SetTrigger("Home Attack");
    }
}
