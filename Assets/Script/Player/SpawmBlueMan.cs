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

    private void Start()
    {
        energyBarAttack = GetComponent<EnergyBarAttack>();
    }
    public void Spawn()
    {
        if (energyBarAttack.currentEnergy != 0)
        {
            GameObject mySmall = Instantiate(small, spawnPoint.transform.position, spawnPoint.transform.rotation);
            mySmall.transform.parent = parent.transform;
            rb = mySmall.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * rbSpeed);
        }
        else if (energyBarAttack.currentEnergy == 0)
        {
            GameObject myBig = Instantiate(big, spawnPoint.transform.position, spawnPoint.transform.rotation);
            myBig.transform.parent = parent.transform;
            rb = myBig.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * rbSpeed);
        }
    }
}
