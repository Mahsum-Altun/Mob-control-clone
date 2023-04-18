using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStack : MonoBehaviour
{
    private Transform topColorCube;
    public void ObjectColorCounter()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int counter = int.Parse(transform.GetChild(i).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMPro.TMP_Text>().text);

            if (counter <= 0)
            {
                //Old prefab
                transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<UpdateBarRanges>().enabled = false;
                topColorCube = GameObject.Find("TopCube").GetComponent<Transform>().transform;
                Vector3 pos = topColorCube.position;
                pos.y = 0f;
                topColorCube.position = pos;

                //New prefab
                transform.GetChild(i + 1).GetChild(1).gameObject.SetActive(true);
                transform.GetChild(i + 1).GetComponent<UpdateBarRanges>().enabled = true;
            }
        }
    }
}
