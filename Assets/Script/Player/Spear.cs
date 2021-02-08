using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    Rigidbody2D spear;
    void Start()
    {
        spear = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Ballistics_adjustments(); // Корректировка баллистики копья, для правильной траектории полете.
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject); //Уничтожение копья при столкновении 
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject); //Уничтожение копья при вылете за карту
    }
    void Ballistics_adjustments()
    {
        Vector2 dir = spear.velocity;//Скорость копья
        float ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //Тангенс угла
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);//Доворот 
    }    
}
