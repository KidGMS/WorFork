using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCollision : MonoBehaviour
{
    private GameObject[] parts;
    private void Start()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Bot" && coll.gameObject.tag != "Platform" && coll.gameObject.tag != "footer")
        {
            parts = GameObject.FindGameObjectsWithTag("Bot");
            //���� ��� ���������� rb ����
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            parts[0].GetComponentInParent<Rigidbody2D>().AddForce(Vector2.right * 0.05f);//��� ������� (���� � ���� ������ ����� ��� ��������)
            FindObjectOfType<Bot>().isLive = false;//������
            FindObjectOfType<Event>().nKill++;
            FindObjectOfType<Event>().nKillText.text = FindObjectOfType<Event>().nKill.ToString();
            Destroy(GameObject.Find("Bot(Clone)"),3f);//�������� ����
        }
    }
}
