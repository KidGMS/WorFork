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
        Ballistics_adjustments(); // ������������� ���������� �����, ��� ���������� ���������� ������.
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject); //����������� ����� ��� ������������ 
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject); //����������� ����� ��� ������ �� �����
    }
    void Ballistics_adjustments()
    {
        Vector2 dir = spear.velocity;//�������� �����
        float ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //������� ����
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);//������� 
    }    
}
