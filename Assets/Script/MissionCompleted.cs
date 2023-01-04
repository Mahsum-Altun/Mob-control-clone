using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCompleted : MonoBehaviour
{
    public float speed;
    public bool missionFinished = false;
    private void Update()
    {
        if (missionFinished == true)
        {
            MissionFinished();
        }
    }
    public void MissionFinished()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }
    public void NexMission()
    {
        StartCoroutine("DestroyLevel");
    }
    IEnumerator DestroyLevel()
    {
        GameObject.Find("Ball Parent").GetComponent<BallWalk>().coroutine = true;
        GameObject.Find("Ball and canvas").GetComponent<InputControl>().enabled = false;
        GameObject.Find("Blue And Yellow Parent").GetComponent<TransformEx>().DestroyChild();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
