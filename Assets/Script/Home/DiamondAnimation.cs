using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondAnimation : MonoBehaviour
{
    private Animator diamondAnimator;
    // Start is called before the first frame update
    void Start()
    {
        diamondAnimator = GetComponent<Animator>();
    }
    public void DiamondShake()
    {
        diamondAnimator.SetTrigger("Diamond Plus");
    }
}
