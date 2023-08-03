using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawmBlueMan : MonoBehaviour
{
    public GameObject small;
    public GameObject big;
    public GameObject spawnPoint;
    public GameObject parent;
    EnergyBarAttack energyBarAttack;
    private Rigidbody rb;
    public float rbSpeed;
    private AudioSource ballFireSound;
    private void Start()
    {
        energyBarAttack = GetComponent<EnergyBarAttack>();
        ballFireSound = GetComponent<AudioSource>();
    }
    public void Spawn()
    {
        ballFireSound.Play();
        if (energyBarAttack.currentEnergy != 100)
        {
            GameObject mySmall = Instantiate(small, spawnPoint.transform.position, spawnPoint.transform.rotation);
            mySmall.transform.parent = parent.transform;
            rb = mySmall.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * rbSpeed);
        }
        else if (energyBarAttack.currentEnergy == 100)
        {
            GameObject myBig = Instantiate(big, spawnPoint.transform.position, spawnPoint.transform.rotation);
            myBig.transform.parent = parent.transform;
            rb = myBig.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * rbSpeed);
        }
    }
}
