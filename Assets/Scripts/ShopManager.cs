using System.Collections;
using System.Collections.Generic;
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
    public Text CurGoldText;


    public float BtnCooltime = 0f;


    public int SoldierSkill1 = 0;
    public int SoldierSkill2 = 0;
    public int SoldierSkill3 = 0;
    public int WorriorSkill1 = 0;
    public int WorriorSkill2 = 0;
    public int WorriorSkill3 = 0;
    public int FireMagicianSkill1 = 0;
    public int FireMagicianSkill2 = 0;
    public int FireMagicianSkill3 = 0;
    public int WaterMagicianSkill1 = 0;
    public int WaterMagicianSkill2 = 0;
    public int WaterMagicianSkill3 = 0;
    public int WindMagicianSkill1 = 0;
    public int WindMagicianSkill2 = 0;
    public int WindMagicianSkill3 = 0;
    public int SkillUpgradeGold = 3000;

    // Update is called once per frame
    void Update()
    {
        BtnCooltime -= Time.unscaledDeltaTime;

        Shop(); // 상점 열고 닫기
        ViewGold(); // 상점내부 골드 보이기

    }
    public void Shop()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && shopopen == false)
        {
            Time.timeScale = 0;
            ShopUI.SetActive(true);
            StatsUI.SetActive(false);
            SKillsUI.SetActive(false);
            EnemyUI.SetActive(false);
            GambleUI.SetActive(false);
            shopopen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && shopopen == true)
        {
            Time.timeScale = 1;
            ShopUI.SetActive(false);
            StatsUI.SetActive(false);
            SKillsUI.SetActive(false);
            EnemyUI.SetActive(false);
            GambleUI.SetActive(false);
            shopopen = false;
        }
    }
    public void ViewGold()
    {
        Player p = player.GetComponent<Player>();
        CurGoldText.text = "골드 : " + p.gold.ToString();
    }


    public void onclickStatsButton() // 스탯 탭
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

    public void onclickEnemyButton() //몬스터 탭
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(true);
        GambleUI.SetActive(false);
    }

    public void onclickGamebleButton() // 도박 탭
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(true);
    }

    public void onclickTipButton() // 팁 탭
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
    }

    IEnumerator NotEnoughTipCo() // 팁 줄 때 잔액에 따른 텍스트 없애는 쿨타임
    {
        yield return new WaitForSecondsRealtime(1.5f);
        NotEnoughTipText.gameObject.SetActive(false);
    }
    IEnumerator EnoughTipCo() // 팁 줄 때 잔액에 따른 텍스트 없애는 쿨타임
    {
        yield return new WaitForSecondsRealtime(1.5f);
        EnoughTipText.gameObject.SetActive(false);
    }


    public void onclickAtkBtn() // 기본 공격 증가 
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Atk += 10;
    }

    public void onclickWalkSpdBtn() // 이속 증가
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Spd += 1;
    }

    public void onclickMaxHpBtn() // 최대 체력 증가
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.MaxHp += 30;
    }

    public void onclickHpPotionBtn() // 물약 포션
    {
        Status status = player.gameObject.GetComponent<Status>();
        if (status.CurHp <= status.MaxHp)
        {
            status.CurHp += 10;
            if (status.CurHp > status.MaxHp)
            {
                status.CurHp = status.MaxHp;
            }
        }
    }

    public void onclickSkill1Btn() // 스킬 1 버튼 업그레이드 버튼
    {
        // 군인
        if (player.tag == "Soldier")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (SoldierSkill1 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill1++;
                }

                else if (SoldierSkill1 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill1++;
                }

                else if (SoldierSkill1 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill1++;
                }

                else if (SoldierSkill1 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 검사
        if (player.tag == "Worrior")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WorriorSkill1 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill1++;
                }

                else if (WorriorSkill1 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill1++;
                }

                else if (WorriorSkill1 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill1++;
                }

                else if (WorriorSkill1 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 불법
        if (player.tag == "FireMagician")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (FireMagicianSkill1 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill1++;
                }

                else if (FireMagicianSkill1 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill1++;
                }

                else if (FireMagicianSkill1 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill1++;
                }

                else if (FireMagicianSkill1 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 물법
        if (player.tag == "WaterMagician")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WaterMagicianSkill1 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill1++;
                }

                else if (WaterMagicianSkill1 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill1++;
                }

                else if (WaterMagicianSkill1 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill1++;
                }

                else if (WaterMagicianSkill1 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 바람법
        if (player.tag == "WindMagician")       
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WindMagicianSkill1 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill1++;
                }

                else if (WindMagicianSkill1 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill1++;
                }

                else if (WindMagicianSkill1 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill1++;
                }

                else if (WindMagicianSkill1 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }
    }

    public void onclickSkill2Btn() // 스킬 2 버튼 업그레이드 버튼
    {
        // 군인
        if (player.tag == "Soldier")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (SoldierSkill2 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill2++;
                }

                else if (SoldierSkill2 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill2++;
                }

                else if (SoldierSkill2 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill2++;
                }

                else if (SoldierSkill2 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 검사
        if (player.tag == "Worrior")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WorriorSkill2 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill2++;
                }

                else if (WorriorSkill2 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill2++;
                }

                else if (WorriorSkill2 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill2++;
                }

                else if (WorriorSkill2 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 물법
        if (player.tag == "WaterMagician")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WaterMagicianSkill2 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill2++;
                }

                else if (WaterMagicianSkill2 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill2++;
                }

                else if (WaterMagicianSkill2 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill2++;
                }

                else if (WaterMagicianSkill2 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 바람법
        if (player.tag == "WindMagician")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WindMagicianSkill2 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill2++;
                }

                else if (WindMagicianSkill2 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill2++;
                }

                else if (WindMagicianSkill2 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill2++;
                }

                else if (WindMagicianSkill2 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 불법
        if (player.tag == "FireMagician")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (FireMagicianSkill2 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill2++;
                }

                else if (FireMagicianSkill2 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill2++;
                }

                else if (FireMagicianSkill2 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill2++;
                }

                else if (FireMagicianSkill2 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

    }

    public void onclickSkill3Btn() // 스킬 3 업그레이드 버튼
    {
        // 군인
        if (player.tag == "Soldier")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (SoldierSkill3 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill3++;
                }

                else if (SoldierSkill3 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill3++;
                }

                else if (SoldierSkill3 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    SoldierSkill3++;
                }

                else if (SoldierSkill3 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 검사
        if (player.tag == "Worrior")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WorriorSkill3 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill3++;
                }

                else if (WorriorSkill3 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill3++;
                }

                else if (WorriorSkill3 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WorriorSkill3++;
                }

                else if (WorriorSkill3 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 물법
        if (player.tag == "WaterMagician")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WaterMagicianSkill3 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill3++;
                }

                else if (WaterMagicianSkill3 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill3++;
                }

                else if (WaterMagicianSkill3 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WaterMagicianSkill3++;
                }

                else if (WaterMagicianSkill3 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 바람법
        if (player.tag == "WindMagician")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (WindMagicianSkill3 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill3++;
                }

                else if (WindMagicianSkill3 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill3++;
                }

                else if (WindMagicianSkill3 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    WindMagicianSkill3++;
                }

                else if (WindMagicianSkill3 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }

        // 불법
        if (player.tag == "FireMagician")
        {
            if (player.gold >= SkillUpgradeGold)
            {
                if (FireMagicianSkill3 == 0)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill3++;
                }

                else if (FireMagicianSkill3 == 1)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill3++;
                }

                else if (FireMagicianSkill3 == 2)
                {
                    player.gold -= SkillUpgradeGold;
                    FireMagicianSkill3++;
                }

                else if (FireMagicianSkill3 <= 3)
                {
                    return;
                }
            }

            else if (player.gold <= SkillUpgradeGold)
            {
                return;
            }
        }
    }



}
