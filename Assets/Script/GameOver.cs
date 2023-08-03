using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool gameoverControl = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy Big")
        {
            Destroy(other.gameObject);
            if (gameoverControl == false)
            {
                GameObject.Find("Ball Blue").GetComponent<Animator>().SetBool("BallFire", false);
                GameObject.Find("Ball and canvas").GetComponent<InputControl>().enabled = false;
                GameObject.Find("Blue And Yellow Parent").GetComponent<TransformEx>().DestroyChild();
                DiamondCounter.instance.Diamonds = 0;
                GoldCounter.instance.Gold = 0;
                GameObject.Find("Defeat parent").GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);

                gameoverControl = true;
            }
        }
    }
}
