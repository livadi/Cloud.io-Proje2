using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botexcar : MonoBehaviour
{
   public GameObject fire;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"||collision.gameObject.tag=="botplayer")
        {
            
            fire.SetActive(true);
        }
        else if(collision.gameObject.tag == "rain")
        {
            Destroy(gameObject, 2);
        }
    }
}
