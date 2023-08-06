using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    public static GoldCounter instance;
    private int _c = 0;
    public int originalGold;
    public int levelGold = 0;
    public PrefabData prefabData;
    public int Gold
    {
        get { return _c; }
        set
        {
            _c = value;
        }
    }
    private void Awake()
    {
        Gold = prefabData.goldValue;
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
    public void OriginalGold()
    {
        originalGold = levelGold;
    }
}
