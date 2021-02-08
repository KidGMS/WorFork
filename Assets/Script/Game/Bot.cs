using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public GameObject Hand;//���� ���� ��� ���������
    public GameObject Spear;//����� ����
    bool hit;//�������� ��������
    bool genAngle;//�������� ��������� ���� ������
    float AngleRandom;//���� ������ ����� �����
    public SpriteRenderer SpearSprite;//������ ����� � ���� ����
    public bool isLive;//������ ����� ����
    private void Start()
    {
        isLive = true;
        Hand.transform.rotation = Quaternion.Euler(0, 0, 180);
    }
    void Update()
    {
        if (isLive == true)
        {
            if (hit == false)
            {
                if (genAngle == false)
                {
                    AngleRandom = Random.Range(130, 210);//��������� ���� ������ ���� �����
                    genAngle = true;
                }
                Hand.transform.rotation = Quaternion.Slerp(Hand.transform.rotation, Quaternion.Euler(0, 0, AngleRandom), Time.deltaTime * 2f);//���������
                if (Mathf.CeilToInt(Hand.transform.eulerAngles.z) - Mathf.CeilToInt(AngleRandom) == 1 || Mathf.CeilToInt(Hand.transform.eulerAngles.z) - Mathf.CeilToInt(AngleRandom) == 0) hit = true; // ������� ��� ��������


            }
            if (hit == true)
            {
                if (GameObject.FindGameObjectWithTag("SpearBot") == null)
                {
                    Bot_Shot();//�������
                }
                else
                {
                    SpearSprite.enabled = enabled;
                }
            }
        }

    }
    void Bot_Shot()
    {
        SpearSprite.enabled = false;
        var SpearInst = Instantiate(Spear, new Vector2(Hand.transform.position.x, Hand.transform.position.y + 0.4f), Hand.transform.rotation);
        SpearInst.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * FindObjectOfType<Event>().ShotPowerBot);
        hit = false;
        genAngle = false;
    }
}
