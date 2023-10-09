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
        } // 상점 열기

        else if (Input.GetKeyDown(KeyCode.Escape) && shopopen == true)
        {
            Time.timeScale = 1;
            ShopUI.SetActive(false);
            StatsUI.SetActive(false);
            SKillsUI.SetActive(false);
            EnemyUI.SetActive(false);
            GambleUI.SetActive(false);
            shopopen = false;
        } // 상점 닫기
    }

    public void onclickStatsButton() //스탯 탭
    {
        StatsUI.SetActive(true);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(false);
    }

    public void onclickSkillsButton() //스킬 탭
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
    } //몬스터 탭

    public void onclickGamebleButton()
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(true);
    } // 도박 탭

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
    } // 팁 탭

    IEnumerator NotEnoughTipCo()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        NotEnoughTipText.gameObject.SetActive(false);
    } // 팁 줄 때 잔액에 따른 텍스트 없애는 쿨타임

    IEnumerator EnoughTipCo()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        EnoughTipText.gameObject.SetActive(false);
    } // 팁 줄 때 잔액에 따른 텍스트 없애는 쿨타임

    
    public void onclickAtkBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Atk += 10;
    } // 기본 공격 증가 

    public void onclickWalkSpdBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Spd += 1;
    } // 이속 증가

    public void onclickMaxHpBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.MaxHp += 30;
    } // 최대 체력 증가

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
    } // 물약 포션

    public void onclickSkill1Btn() // 스킬 1 버튼
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

    public void onclickSkill2Btn() // 스킬 2 버튼
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

    public void onclickSkill3Btn() // 스킬 3 버튼
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
