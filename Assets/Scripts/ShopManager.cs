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

    public void onclickEnemyButton() //���� ��
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(true);
        GambleUI.SetActive(false);
    }

    public void onclickGamebleButton() // ���� ��
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(true);
    }

    public void onclickTipButton() // �� ��
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

    IEnumerator NotEnoughTipCo() // �� �� �� �ܾ׿� ���� �ؽ�Ʈ ���ִ� ��Ÿ��
    {
        yield return new WaitForSecondsRealtime(1.5f);
        NotEnoughTipText.gameObject.SetActive(false);
    }
    IEnumerator EnoughTipCo() // �� �� �� �ܾ׿� ���� �ؽ�Ʈ ���ִ� ��Ÿ��
    {
        yield return new WaitForSecondsRealtime(1.5f);
        EnoughTipText.gameObject.SetActive(false);
    }


    public void onclickAtkBtn() // �⺻ ���� ���� 
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Atk += 10;
    }

    public void onclickWalkSpdBtn() // �̼� ����
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Spd += 1;
    }

    public void onclickMaxHpBtn() // �ִ� ü�� ����
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.MaxHp += 30;
    }

    public void onclickHpPotionBtn() // ���� ����
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

    public void onclickSkill1Btn() // ��ų 1 ��ư
    {
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

    public void onclickSkill2Btn()
    {
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
    }

    public void onclickSkill3Btn()
    {
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
    }


}
