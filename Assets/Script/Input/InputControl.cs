using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputControl : MonoBehaviour
{
    public Transform transtoMove;
    public float speedModifier = .01f;
    public float xMin = -10f;
    public float xMax = 10f;
    public bool localMovement;
    private Touch curTouch;
    private Vector3 newPos = Vector3.zero;
    private Animator ballAnimator;
    private Rigidbody rb;
    private bool isTouching = false;
    private void Start()
    {
        ballAnimator = transform.GetChild(0).GetComponent<Animator>();
        rb = transform.GetChild(0).GetComponent<Rigidbody>();
    }
    private void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            curTouch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(curTouch.fingerId))
            {
                if (curTouch.phase == TouchPhase.Began)
                {
                    isTouching = true;
                    ballAnimator.SetBool("BallFire", true);
                }
                else if (curTouch.phase == TouchPhase.Ended || curTouch.phase == TouchPhase.Canceled)
                {
                    isTouching = false;
                    ballAnimator.SetBool("BallFire", false);
                }
                if (isTouching && curTouch.phase == TouchPhase.Moved)
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
        }
    }
}
