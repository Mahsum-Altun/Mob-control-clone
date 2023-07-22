using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCounter : MonoBehaviour
{
    public static DiamondCounter instance;
    private int _c = 0;
    public int Diamonds
    {
        get { return _c; }
        set
        {
            _c = value;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
