using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public Player player;
    public GameObject ShopUI;
    bool shopopen;
    public GameObject StatsUI;
    public GameObject SKillsUI;
    public GameObject EnemyUI;
    public GameObject GambleUI;
    public Text NotEnoughTipText;
    public Text EnoughTipText;
    public float BtnCooltime = 0f;
    int SoldierSkill1 = 0;
    int SoldierSkill2 = 0;
    int SoldierSkill3 = 0;
    int WorriorSkill1 = 0;
    int WorriorSkill2 = 0;
    int WorriorSkill3 = 0;
    int FireMagicianSkill1 = 0;
    int FireMagicianSkill2 = 0;
    int FireMagicianSkill3 = 0;
    int WaterMagicianSkill1 = 0;
    int WaterMagicianSkill2 = 0;
    int WaterMagicianSkill3 = 0;
    int WindMagicianSkill1 = 0;
    int WindMagicianSkill2 = 0;
    int WindMagicianSkill3 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BtnCooltime -= Time.unscaledDeltaTime;
        if (Input.GetKeyDown(KeyCode.Escape) && shopopen == false)
        {
            Time.timeScale = 0;
            ShopUI.SetActive(true);
            StatsUI.SetActive(false);
            SKillsUI.SetActive(false);
            EnemyUI.SetActive(false);
            GambleUI.SetActive(false);
            shopopen = true;
        } // ���� ����

        else if (Input.GetKeyDown(KeyCode.Escape) && shopopen == true)
        {
            Time.timeScale = 1;
            ShopUI.SetActive(false);
            StatsUI.SetActive(false);
            SKillsUI.SetActive(false);
            EnemyUI.SetActive(false);
            GambleUI.SetActive(false);
            shopopen = false;
        } // ���� �ݱ�
    }

    public void onclickStatsButton() //���� ��
    {
        StatsUI.SetActive(true);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(false);
    }

    public void onclickSkillsButton() //��ų ��
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(true);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(false);
    }

    public void onclickEnemyButton()
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(true);
        GambleUI.SetActive(false);
    } //���� ��

    public void onclickGamebleButton()
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(true);
    } // ���� ��

    public void onclickTipButton()
    {
        if (BtnCooltime <= 0f)
        {
            if (player.gold <= 1000)
            {
                NotEnoughTipText.gameObject.SetActive(true);
                StartCoroutine(NotEnoughTipCo());
            }
            if (player.gold >= 1000)
            {
                player.gold -= 1000;
                EnoughTipText.gameObject.SetActive(true);
                StartCoroutine(EnoughTipCo());
            }
            BtnCooltime = 1.7f;
        }
    } // �� ��

    IEnumerator NotEnoughTipCo()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        NotEnoughTipText.gameObject.SetActive(false);
    } // �� �� �� �ܾ׿� ���� �ؽ�Ʈ ���ִ� ��Ÿ��

    IEnumerator EnoughTipCo()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        EnoughTipText.gameObject.SetActive(false);
    } // �� �� �� �ܾ׿� ���� �ؽ�Ʈ ���ִ� ��Ÿ��

    
    public void onclickAtkBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Atk += 10;
    } // �⺻ ���� ���� 

    public void onclickWalkSpdBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Spd += 1;
    } // �̼� ����

    public void onclickMaxHpBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.MaxHp += 30;
    } // �ִ� ü�� ����

    public void onclickHpPotionBtn() 
    {
        Status status = player.gameObject.GetComponent<Status>();
        if (status.CurHp <= status.MaxHp)
        {
            status.CurHp += 10;
            if(status.CurHp > status.MaxHp)
            {
                status.CurHp = status.MaxHp;
            }
        }
    } // ���� ����

    public void onclickSkill1Btn() // ��ų 1 ��ư
    {
        
        if(player.tag=="Soldier")
        {
            if(SoldierSkill1==0)
            {
                
            }

            if(SoldierSkill1==1) 
            {
                
            }

            if(SoldierSkill1==2)
            {

            }
        }

        if(player.tag=="Worrior")
        {

        }

        if(player.tag=="FireMagician")
        {

        }

        if(player.tag=="WaterMagician")
        {

        }

        if(player.tag=="WindMagician")
        {

        }
    }

    public void onclickSkill2Btn() // ��ų 2 ��ư
    {
        if (player.tag == "Soldier")
        {

        }

        if (player.tag == "Worrior")
        {

        }

        if (player.tag == "FireMagician")
        {

        }

        if (player.tag == "WaterMagician")
        {

        }

        if (player.tag == "WindMagician")
        {

        }
    }

    public void onclickSkill3Btn() // ��ų 3 ��ư
    {
        if (player.tag == "Soldier")
        {

        }

        if (player.tag == "Worrior")
        {

        }

        if (player.tag == "FireMagician")
        {

        }

        if (player.tag == "WaterMagician")
        {

        }

        if (player.tag == "WindMagician")
        {

        }
    }
}
