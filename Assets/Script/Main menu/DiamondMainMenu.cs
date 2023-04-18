using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMainMenu : MonoBehaviour
{
    TMPro.TMP_Text diamondUIText;
    public float imageCounter;
    [SerializeField] float counterSpeed;
    ObjectColorChange objectColorChange;
    private bool counter = false;

    // Start is called before the first frame update
    void Start()
    {
        diamondUIText = GetComponent<TMPro.TMP_Text>();
        objectColorChange = FindObjectOfType<ObjectColorChange>();
    }

    // Update is called once per frame
    void Update()
    {
        diamondUIText.text = Mathf.FloorToInt(imageCounter).ToString();
        if (Input.GetMouseButton(0))
        {
            if (DiamondCounter.instance.Diamonds > 1)
            {
                imageCounter -= counterSpeed * Time.deltaTime;
                DiamondCounter.instance.Diamonds -= counterSpeed * Time.deltaTime;
                objectColorChange.CubeMovement();
            }
        }
        if (imageCounter <= 0 && counter == false)
        {
            GameObject prefab = transform.root.gameObject;
            ObjectStack objectStack = prefab.GetComponent<ObjectStack>();
            objectStack.ObjectColorCounter();
            counter = true;
        }
        else
        {
            counter = false;
        }
    }
}
