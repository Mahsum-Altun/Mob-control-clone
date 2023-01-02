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
        StartCoroutine("DestroyLevel");
    }
    IEnumerator DestroyLevel()
    {
        yield return new WaitForSeconds(2.5f);
        GameObject.Find("Ball Parent").GetComponent<BallWalk>().coroutine = true;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
