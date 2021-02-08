using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public GameObject Hand;//Рука бота для наведения
    public GameObject Spear;//Копье бота
    bool hit;//Проверка выстрела
    bool genAngle;//Проверка получение угла броска
    float AngleRandom;//Угол броска ботом копья
    public SpriteRenderer SpearSprite;//Спрайт копья в руке бота
    public bool isLive;//Статус жизни бота
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
                    AngleRandom = Random.Range(130, 210);//Случайный угол броска коья ботом
                    genAngle = true;
                }
                Hand.transform.rotation = Quaternion.Slerp(Hand.transform.rotation, Quaternion.Euler(0, 0, AngleRandom), Time.deltaTime * 2f);//Наведение
                if (Mathf.CeilToInt(Hand.transform.eulerAngles.z) - Mathf.CeilToInt(AngleRandom) == 1 || Mathf.CeilToInt(Hand.transform.eulerAngles.z) - Mathf.CeilToInt(AngleRandom) == 0) hit = true; // Условие для выстрела


            }
            if (hit == true)
            {
                if (GameObject.FindGameObjectWithTag("SpearBot") == null)
                {
                    Bot_Shot();//Выстрел
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
