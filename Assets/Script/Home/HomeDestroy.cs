using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDestroy : MonoBehaviour
{
    public ParticleSystem deathParticles;
    public string targetLayerName = "Last Home";
    private bool ifControl = false;
    private bool camZoomBool = false;


    private void Update()
    {
        if (camZoomBool == true)
        {
            float smoothness = 1.5f;
            GameObject camZoom = GameObject.Find("CameraTarget");
            camZoom.transform.position = Vector3.Lerp(camZoom.transform.position, transform.position, smoothness * Time.deltaTime);
        }
    }

    public void HomeControl()
    {
        int count = CountObjectsOnLayer(targetLayerName);
        if (transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue <= 0)
        {
            if (gameObject.layer == 7)
            {
                if (count == 1 && ifControl == false)
                {
                    camZoomBool = true;
                    GameObject countdownParent = GameObject.Find("Score");
                    countdownParent.transform.GetChild(1).gameObject.SetActive(true);
                    countdownParent.transform.GetChild(1).GetChild(0).GetComponent<Animator>().SetTrigger("Victory");
                    GameObject.Find("Ball Blue").GetComponent<Animator>().SetBool("BallFire", false);
                    GameObject.Find("Ball and canvas").GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
                    ifControl = true;
                }
                else if (count > 1)
                {
                    Destroy();
                }
            }
            else if (gameObject.layer != 7)
            {
                Destroy();
            }
        }
    }

    int CountObjectsOnLayer(string layerName)
    {
        int count = 0;
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == LayerMask.NameToLayer(layerName))
            {
                count++;
            }
        }

        return count;
    }
    public void Destroy()
    {
        Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}