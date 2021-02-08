using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "SpearPlayer")
        {
            FindObjectOfType<Event>().coinisPlayer++;
            FindObjectOfType<Event>().cCoin.text = FindObjectOfType<Event>().coinisPlayer.ToString();
        }
        Destroy(this.gameObject);
    }
}
