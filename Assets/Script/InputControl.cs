using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public Transform transtoMove;
    public float speedModifier = .01f;
    public float xMin = -10f;
    public float xMax = 10f;
    public bool localMovement;
    private Touch curTouch;
    private Vector3 newPos = Vector3.zero;
    private AudioSource ballFireSound;
    private Animator ballAnimator;
    private Rigidbody rb;

    private void Start()
    {
        ballFireSound = GetComponent<AudioSource>();
        ballAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (!ballFireSound.isPlaying)
            {
                ballFireSound.Play();
            }
            ballAnimator.SetBool("BallFire", true);
            curTouch = Input.GetTouch(0);
            if (curTouch.phase == TouchPhase.Moved)
            {
                float newX = curTouch.deltaPosition.x * speedModifier * Time.deltaTime;
                newPos = localMovement ? transtoMove.localPosition : transtoMove.position;
                newPos.x += newX;
                newPos.x = Mathf.Clamp(newPos.x, xMin, xMax);
                if (localMovement)
                {
                    transtoMove.localPosition = newPos;
                }
                else
                {
                    transtoMove.position = newPos;
                }
            }
        }
        else
        {
            ballFireSound.Stop();
            ballAnimator.SetBool("BallFire", false);
        }
    }
}
