using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHomeControl : MonoBehaviour
{
    public GameObject missionLevel;
    private GameObject homeChildControl;

    private void Start()
    {
        homeChildControl = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (homeChildControl.transform.childCount == 0)
        {
            missionLevel.GetComponent<MissionCompleted>().missionFinished = true;
            missionLevel.GetComponent<MissionCompleted>().NexMission();
            GameObject.Find("Ball and canvas").GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        }
    }
}
