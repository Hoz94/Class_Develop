using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Player player;
    public GameObject ShopUI;

    bool shopopen;
    int MaxSpeed = 15;
    int MaxAtk = 300;
    int MaxHpPlus = 1000;
    int Lotto1 = 3000;
    int Lotto2 = 10000;
    int Lotto3 = 50000;

    public GameObject StatsUI;
    public GameObject SKillsUI;
    public GameObject EnemyUI;
    public GameObject GambleUI;

    string[] NotEnoughTip = new string[] { "���� �����鼭 �峭ġ�� ȥ����!", "���� ���� �ε�� ���� �� �ߴ�..", "���� ���� ��.." };
    string[] EnoughTip = new string[] { "���� ������ ����� ���� ���δ�.", "�̰͹ۿ� ���ֳĴ� ��ġ�̴�..", "�� �ְ� �� �Ծ���..","�뷡�� �˷� �� ������ �� ����." }; 
    public Text NotEnoughTipText;
    public Text EnoughTipText;
    public Text CurGoldText;
    public Text NotEnoughUpgradeMoney;
    public Text NoMoreUpgrade;
    public Text GGwanglotto;
    public Text Successlotto;
    

    float StatsUpgradeMoney = 1000f; // ���� ���׷��̵� ���

    float BtnCooltime = 0f;
    float textoffcooltime = 0f;

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
    public float SkillUpgradeGold = 3000f;

    public float MonUpgradeGold = 3000f;
    public float BossSpawnGold = 10000f;

    // Update is called once per frame
    void Update()
    {
        BtnCooltime -= Time.unscaledDeltaTime;
        Shop(); // ���� ���� �ݱ�
        ViewGold(); // �������� ��� ���̱�
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
        CurGoldText.text = "��� : " + p.gold.ToString();
    }


    public void onclickStatsButton() // ���� ��
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
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(false);
        if (BtnCooltime <= 0f)
        {
            if (player.gold < 1000)
            {
                int ran = Random.Range(0, NotEnoughTip.Length);
                switch(ran)
                {
                    case 0:
                        NotEnoughTipText.text = NotEnoughTip[0];
                        break;
                    case 1:
                        NotEnoughTipText.text = NotEnoughTip[1];
                        break;
                    case 2:
                        NotEnoughTipText.text = NotEnoughTip[2];
                        break;
                }
                NotEnoughTipText.gameObject.SetActive(true);
                StartCoroutine(NotEnoughTipCo());
            }
            if (player.gold >= 1000)
            {
                int ran = Random.Range(0, EnoughTip.Length);
                switch(ran)
                {
                    case 0:
                        EnoughTipText.text = EnoughTip[0];
                        break;
                    case 1:
                        EnoughTipText.text= EnoughTip[1];
                        break;
                    case 2:
                        EnoughTipText.text = EnoughTip[2];
                        break;
                    case 3:
                        EnoughTipText.text = EnoughTip[3];
                        break;
                }
                player.gold -= 1000;
                EnoughTipText.gameObject.SetActive(true);
                StartCoroutine(EnoughTipCo());
            }
            BtnCooltime = 1.5f;
        }
    }

    
    IEnumerator LottoTextCo() // �ζ� �� or ��÷ �ؽ�Ʈ ���ִ� ��Ÿ��
    {
        yield return new WaitForSecondsRealtime(1f);
        GGwanglotto.gameObject.SetActive(false);
        Successlotto.gameObject.SetActive(false);
    }
    IEnumerator NotEnoughTipCo() // �� �� �� �ܾ׿� ���� �ؽ�Ʈ ���ִ� ��Ÿ��
    {
        yield return new WaitForSecondsRealtime(1.5f);
        NotEnoughTipText.gameObject.SetActive(false);
    }
    IEnumerator EnoughTipCo() // �� �� �� �ܾ׿� ���� �ؽ�Ʈ ���ִ� ��Ÿ��
    {
        yield return new WaitForSecondsRealtime(1f);
        EnoughTipText.gameObject.SetActive(false);
    }

    IEnumerator NoMoreUpgradeCo() // ���׷��̵� �ִ�ġ�� �� �ؽ�Ʈ ���ִ� ��Ÿ��
    {
        yield return new WaitForSecondsRealtime(0.8f);
        NoMoreUpgrade.gameObject.SetActive(false);
    }

    IEnumerator NotEnoughGoldCo() // ���׷��̵� ��� ���� �� �ؽ�Ʈ ���ִ� ��Ÿ��
    {
        yield return new WaitForSecondsRealtime(0.8f);
        NotEnoughUpgradeMoney.gameObject.SetActive(false);
    }

    public void onclickAtkBtn() // �⺻ ���� ���� 
    {
        Status status = player.gameObject.GetComponent<Status>();
        if (BtnCooltime <= 0f)
        {
            if (status.Atk < MaxAtk)
            {
                if (player.gold >= StatsUpgradeMoney)
                {
                    player.gold -= StatsUpgradeMoney;
                    status.Atk += 10;
                }

                else if (player.gold < StatsUpgradeMoney)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }
            else if (status.Atk == MaxAtk)
            {
                NoMoreUpgrade.gameObject.SetActive(true);
                StartCoroutine(NoMoreUpgradeCo());
            }
            BtnCooltime = 1f;
        }
    }

    public void onclickWalkSpdBtn() // �̼� ����
    {
        if (BtnCooltime <= 0f)
        {
            Status status = player.gameObject.GetComponent<Status>();
            if (status.Spd < MaxSpeed)
            {
                if (player.gold >= StatsUpgradeMoney)
                {
                    player.gold -= StatsUpgradeMoney;
                    status.Spd += 1;
                }
                else if (player.gold < StatsUpgradeMoney)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }
            }
            else if (status.Spd == MaxSpeed)
            {
                NoMoreUpgrade.gameObject.SetActive(true);
                StartCoroutine(NoMoreUpgradeCo());
            }
            BtnCooltime = 1f;
        }
    }

    public void onclickMaxHpBtn() // �ִ� ü�� ����
    {
        Status status = player.gameObject.GetComponent<Status>();
        if (BtnCooltime <= 0f)
        {
            if (status.MaxHp < MaxHpPlus)
            {
                if (player.gold >= StatsUpgradeMoney)
                {
                    player.gold -= StatsUpgradeMoney;
                    status.MaxHp += 50;
                }
                else if (player.gold < StatsUpgradeMoney)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }
            }
            else if (status.MaxHp == MaxHpPlus)
            {
                NoMoreUpgrade.gameObject.SetActive(true);
                StartCoroutine(NoMoreUpgradeCo());
            }
            BtnCooltime = 1f;
        }
    }

    public void onclickHpPotionBtn() // ���� ����
    {
        Status status = player.gameObject.GetComponent<Status>();
        if (BtnCooltime <= 0f)
        {
            if (player.gold >= StatsUpgradeMoney)
            {
                player.gold -= StatsUpgradeMoney;
                status.CurHp += 10;
            }
            else if (player.gold < StatsUpgradeMoney)
            {
                NotEnoughUpgradeMoney.gameObject.SetActive(true);
                StartCoroutine(NotEnoughGoldCo());
            }
            BtnCooltime = 1f;
        }


    }

    public void onclickSkill1Btn() // ��ų 1 ��ư ���׷��̵� ��ư
    {
        if (BtnCooltime <= 0f)
        {
            // ����
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }


            }

            // �˻�
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // �ҹ�
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }
            }

            // ����
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // �ٶ���
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }
            }
            BtnCooltime = 1f;
        }
        
    }

    public void onclickSkill2Btn() // ��ų 2 ��ư ���׷��̵� ��ư
    {
        if (BtnCooltime <= 0f)
        {    // ����
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // �˻�
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // ����
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // �ٶ���
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // �ҹ�
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }
            BtnCooltime = 1f;
        }
    }

    public void onclickSkill3Btn() // ��ų 3 ���׷��̵� ��ư
    {
        if (BtnCooltime <= 0f)
        {
            // ����
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // �˻�
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // ����
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // �ٶ���
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }

            }

            // �ҹ�
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
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                }
                else if (player.gold < SkillUpgradeGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }
            }
            BtnCooltime = 1f;
        }
    }

    public void onclickMonSpdBtn()
    {
        if(BtnCooltime<=0f)
        {
            if(player.gold>=MonUpgradeGold)
            {

            }

            else if(player.gold < MonUpgradeGold)
            {

            }
            BtnCooltime = 1f;
        }
    }
    public void onclickMonLvupBtn()
    {
        if (BtnCooltime <= 0f)
        {
            if (player.gold >= MonUpgradeGold)
            {

            }

            else if (player.gold < MonUpgradeGold)
            {

            }
            BtnCooltime = 1f;
        }
    }

    public void onclickMonSpawnSpdBtn()
    {
        if (BtnCooltime <= 0f)
        {
            if (player.gold >= MonUpgradeGold)
            {

            }

            else if (player.gold < MonUpgradeGold)
            {

            }
            BtnCooltime = 1f;
        }
    }

    public void onclickBossSpdBtn()
    {

    }

    public void onLottoclick1() // �ζ� 1 Ŭ��
    {
        if (BtnCooltime <= 0)
        {
            if (player.gold >= Lotto1)
            {
                player.gold -= Lotto1;
                int a = Random.Range(1, 100);
                if (a <= 45)
                {
                    player.gold += Lotto1 * 2;
                    Successlotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
                }
                else
                {
                    GGwanglotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
                }
                
            }
            else if (player.gold < Lotto1)
            {
                NotEnoughUpgradeMoney.gameObject.SetActive(true);
                StartCoroutine(NotEnoughGoldCo());
            }
            BtnCooltime = 0.7f;
        }
    }

    public void onLottoclick2() // �ζ� 2 Ŭ��
    {
        if (BtnCooltime <= 0)
        {
            if (player.gold >= Lotto2)
            {
                player.gold -= Lotto2;
                int a = Random.Range(1, 100);
                if (a<=5)
                {
                    player.gold += Lotto2 * 5;
                    Successlotto.gameObject.SetActive(true);
                }
                else
                {
                    GGwanglotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
                }
            }
            else if (player.gold < Lotto2)
            {
                NotEnoughUpgradeMoney.gameObject.SetActive(true);
                StartCoroutine(NotEnoughGoldCo());
            }
            BtnCooltime = 0.7f;
        }
    }

    public void onLottoclick3() // �ζ� 3 Ŭ��
    {
        if (BtnCooltime <= 0)
        {
            if (player.gold >= Lotto3)
            {
                player.gold -= Lotto3;
                int a = Random.Range(1, 100);
                if (a<=1)
                {
                    player.gold += Lotto3 * 10;
                    Successlotto.gameObject.SetActive(true);
                }
                else
                {
                    GGwanglotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
                }
            }
            
            else if(player.gold<Lotto3)
            {
                NotEnoughUpgradeMoney.gameObject.SetActive(true);
                StartCoroutine(NotEnoughGoldCo());
            }
            BtnCooltime = 0.7f;
        }
    }
}
