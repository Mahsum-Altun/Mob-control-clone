using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDestroy : MonoBehaviour
{
    public ParticleSystem deathParticles;
    public void Destroy()
    {
        Instantiate(deathParticles, transform.position, transform.rotation);
        GameObject.Find("Ball and canvas").GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        this.gameObject.SetActive(false);
    }
}
