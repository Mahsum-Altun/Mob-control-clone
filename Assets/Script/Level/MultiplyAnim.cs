using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyAnim : MonoBehaviour
{
    public void XOneAndAHalf()
    {
        GoldCounter.instance.levelGold = 0;
        DiamondCounter.instance.Diamonds = 0;
        GoldCounter.instance.levelGold = (int)(GoldCounter.instance.originalGold * 1.5f);
        DiamondCounter.instance.Diamonds = (int)(DiamondCounter.instance.originalDiamond * 1.5f);
        Multiply multiplyScript = FindObjectOfType<Multiply>();
        if (multiplyScript != null)
        {
            multiplyScript.multiplyXText = GameObject.Find("x1.5 parent");
        }
        else
        {
            Debug.Log("Multiply script not found in the scene.");
        }
    }
    public void XTwo()
    {
        GoldCounter.instance.levelGold = 0;
        DiamondCounter.instance.Diamonds = 0;
        GoldCounter.instance.levelGold = (int)(GoldCounter.instance.originalGold * 2);
        DiamondCounter.instance.Diamonds = (int)(DiamondCounter.instance.originalDiamond * 2);
        Multiply multiplyScript = FindObjectOfType<Multiply>();
        if (multiplyScript != null)
        {
            multiplyScript.multiplyXText = GameObject.Find("x2 parent");
        }
        else
        {
            Debug.Log("Multiply script not found in the scene.");
        }
    }
    public void XThree()
    {
        GoldCounter.instance.levelGold = 0;
        DiamondCounter.instance.Diamonds = 0;
        GoldCounter.instance.levelGold = (int)(GoldCounter.instance.originalGold * 3);
        DiamondCounter.instance.Diamonds = (int)(DiamondCounter.instance.originalDiamond * 3);
        Multiply multiplyScript = FindObjectOfType<Multiply>();
        if (multiplyScript != null)
        {
            multiplyScript.multiplyXText = GameObject.Find("x3 parent");
        }
        else
        {
            Debug.Log("Multiply script not found in the scene.");
        }
    }
}
