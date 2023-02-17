using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDestroy : MonoBehaviour
{
    public ParticleSystem deathParticles;

    private void Update()
    {
        if (transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<ScoreHome>().scoreValue <= 0)
        {
            Destroy();
        }
    }
    public void Destroy()
    {
        Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
