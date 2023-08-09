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
    private AudioSource ballFireSound;
    public AudioClip bigSpawnSound;
    private BallWalk ballWalk;
    private void Start()
    {
        ballWalk = transform.root.GetComponent<BallWalk>();
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
        }
        else if (energyBarAttack.currentEnergy == 100)
        {
            GameObject myBig = Instantiate(big, spawnPoint.transform.position, spawnPoint.transform.rotation);
            myBig.transform.parent = parent.transform;
            ballFireSound.PlayOneShot(bigSpawnSound);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "waypoints")
        {
            ballWalk.coroutine = true;
        }
        if (other.gameObject.tag == "TouchControl")
        {
            GameObject.Find("Ball and canvas").GetComponent<InputControl>().enabled = true;
            ballWalk.soundControl = false;
        }
    }
}
