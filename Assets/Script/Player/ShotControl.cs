using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    public GameObject Hand; //���� ������� ������� � ������� �����
    public GameObject Spear; //�����
    public SpriteRenderer SpearSprite;//������ ����� � ���� ������
    public bool isKill;
    private void Start()
    {
        isKill = false;
        Hand.transform.rotation = Quaternion.Euler(0, 0, 180);
    }
    void Update()
    {
        if (isKill == false)
        {
            if (Input.GetMouseButton(0) && Time.timeScale != 0)//��� ������� ������ ���� ������� ����� ������ ��� �� "Y"
            {
                Guidance();//���������
            }
            if (GameObject.FindGameObjectWithTag("SpearPlayer") == null)//�������� ������ ���� ����� ��� �� �����
            {
                SpearSprite.enabled = enabled; //�������� ����� � ���� ������ (1)
                if (Input.GetKeyDown(KeyCode.Space)) //������ �� ������
                {
                    Shot();//�������
                }
            }
            else
            {
                SpearSprite.enabled = false; //��� ������ ��������� �� ���� (1)
            }
        }
    }
    void Guidance()
    {
        //��������� �����
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Hand.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(worldPosition.y * 60, 130, 210));
    }   
    void Shot()
    {
        //�������(������)
        var SpearInst = Instantiate(Spear, new Vector2(Hand.transform.position.x, Hand.transform.position.y + 0.4f), Hand.transform.rotation);
        SpearInst.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * FindObjectOfType<Event>().ShotPowerPlayer);
    }
}
