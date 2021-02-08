using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Event : MonoBehaviour
{
    public GameObject Bot;
    public GameObject Platform;
    public GameObject Coin;
    public GameObject Spear;
    private int CoinSpawn;
    GameObject PlatformInst;
    GameObject BotInst;
    public Text cCoin;
    public Text nKillText;
    public Image l1,l2,l3;
    public GameObject GameOver;
    [Header("���� ������ ����� ������")]
    public int ShotPowerPlayer;
    [Header("���� ������ ����� ����")]
    public int ShotPowerBot;
    [Header("���������� ������ �����")]
    public int nKill;
    [Header("�� ������")]
    public int hPoint;
    public int coinisPlayer;
    void Start()
    {
        Time.timeScale = 1;
        hPoint = 3;
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Bot") == null)
        {
            Destroy(PlatformInst);
            CreateBot();//�������� ����
        }
        if (FindObjectOfType<ShotControl>().isKill == true)
        {
            Time.timeScale = 0;
            GameOver.active = true;
           
        }
    }
    void CreateBot()
    {
        PlatformInst = Instantiate(Platform, new Vector3(Random.Range(-2, 7), Random.Range(-2.3f,1.2f), -1), Quaternion.identity);
        BotInst = Instantiate(Bot, new Vector3(PlatformInst.transform.position.x, PlatformInst.transform.position.y + 0.9f, -1), Quaternion.identity);
        CoinSpawn = Random.Range(1,10);
        if(CoinSpawn > 7)
        {
            CreateCoin();
        }
    }
    void CreateCoin()
    {
        Instantiate(Coin, new Vector3(Random.Range(-3, 8), 6, -1), Quaternion.identity);
    }
}
