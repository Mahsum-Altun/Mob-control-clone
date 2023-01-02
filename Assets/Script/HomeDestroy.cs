using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDestroy : MonoBehaviour
{
    public ParticleSystem deathParticles;
    public void Destroy()
    {
        Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
