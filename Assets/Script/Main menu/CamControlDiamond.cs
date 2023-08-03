using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamControlDiamond : MonoBehaviour
{
    private RectTransform canvasRectTransform;
    private bool canvasActiveControl = false;
    public GameObject canvasUI;

    void Start()
    {
        canvasRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (DiamondCounter.instance.Diamonds > 0)
        {
            transform.GetChild(0).GetComponent<RawImage>().enabled = true;
            transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(PauseCamForSeconds1(1.7f));
        }
        else
        {
            StartCoroutine(PauseCamForSeconds2(1.7f));
        }

    }
    IEnumerator PauseLoopForSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
    IEnumerator PauseCamForSeconds1(float duration)
    {
        yield return new WaitForSeconds(duration);
        Vector3 newPosition = canvasRectTransform.localPosition;
        float newHeight = 2.3f;
        newPosition.y = newHeight;

        float newDepth = -3.77f;
        newPosition.z = newDepth;
        canvasRectTransform.localPosition = newPosition;
    }
    IEnumerator PauseCamForSeconds2(float duration)
    {
        yield return new WaitForSeconds(duration);

        Vector3 newPosition = canvasRectTransform.localPosition;
        float newHeight = 1.34f;
        newPosition.y = newHeight;

        float newDepth = -2.05f;
        newPosition.z = newDepth;
        canvasRectTransform.localPosition = newPosition;
        transform.GetChild(0).GetComponent<RawImage>().enabled = false;
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        if (canvasActiveControl == false)
        {
            canvasUI.gameObject.SetActive(true);
            canvasActiveControl = true;
        }
    }
}
