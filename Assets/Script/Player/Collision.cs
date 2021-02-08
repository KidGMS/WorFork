using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private GameObject[] parts;
    private void Start()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "player")
        {
            if (coll.gameObject.tag == "SpearBot")
            {
                FindObjectOfType<Event>().hPoint--;
                if (FindObjectOfType<Event>().hPoint == 2) FindObjectOfType<Event>().l3.enabled = false;
                if (FindObjectOfType<Event>().hPoint == 1) FindObjectOfType<Event>().l2.enabled = false;
                if (FindObjectOfType<Event>().hPoint == 0) FindObjectOfType<Event>().l1.enabled = false;
                if (FindObjectOfType<Event>().hPoint <= 0)
                {
                    
                    FindObjectOfType<ShotControl>().isKill = true;
                    parts = GameObject.FindGameObjectsWithTag("player");
                    //Цикл для разморозка rb игрока
                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    }
                    parts[0].GetComponentInParent<Rigidbody2D>().AddForce(-Vector2.right * 0.05f);
                }
            }
        }
    }

}
