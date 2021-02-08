using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    public GameObject Hand; //Рука которой наводим и бросаем копье
    public GameObject Spear; //Копье
    public SpriteRenderer SpearSprite;//Спрайт копья в руке игрока
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
            if (Input.GetMouseButton(0) && Time.timeScale != 0)//При зажатой кнопке мыши наводим копье двигая мыш по "Y"
            {
                Guidance();//Наведение
            }
            if (GameObject.FindGameObjectWithTag("SpearPlayer") == null)//Стреляем только если копья нет на сцене
            {
                SpearSprite.enabled = enabled; //Имитация копья в руке игрока (1)
                if (Input.GetKeyDown(KeyCode.Space)) //Бросок на пробел
                {
                    Shot();//Выстрел
                }
            }
            else
            {
                SpearSprite.enabled = false; //При броске пропадает из руки (1)
            }
        }
    }
    void Guidance()
    {
        //Наведение копья
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Hand.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(worldPosition.y * 60, 130, 210));
    }   
    void Shot()
    {
        //Выстрел(бросок)
        var SpearInst = Instantiate(Spear, new Vector2(Hand.transform.position.x, Hand.transform.position.y + 0.4f), Hand.transform.rotation);
        SpearInst.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * FindObjectOfType<Event>().ShotPowerPlayer);
    }
}
