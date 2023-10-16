using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager _instance;

    public Enemy enemy;
    public Player player;
    public PlayerUIManager playerUI;

    public bool bossSpawn = false;
    bool shopopen;
    int MaxSpeed = 15;
    int MaxAtk = 300;
    int MaxHpPlus = 1000;
    int Lotto1 = 3000;
    int Lotto2 = 3000;
    int Lotto3 = 3000;
    public int Lotto4 = 10000;
    int upGradeGoldLevel = 0;
    int upGradeSpdLevel = 0;
    int MaxUpGradeSpdLevel = 9;
    int MaxUpGradeGoldLevel = 10;

    public GameObject StatsUI;
    public GameObject SKillsUI;
    public GameObject EnemyUI;
    public GameObject LottoUI;
    public GameObject ShopUI;
    public GameObject BossPrefab;
    public GameObject Boss;
    public Slider Boss1;

    public Transform BossSpawnPoint;


    string[] NotEnoughTip = new string[] { "돈도 없으면서 장난치다 혼난다!", "돈이 없어 두들겨 맞을 뻔 했다..", "돈이 없는 걸.." };
    string[] EnoughTip = new string[] { "상점 주인의 기분이 좋아 보인다.", "이것밖에 안주냐는 눈치이다..", "돈 주고도 욕 먹었다..", "노래를 알려 줄 생각인 것 같다." };
    public Text NotEnoughTipText;
    public Text EnoughTipText;
    public Text CurGoldText;
    public Text NotEnoughUpgradeMoney;
    public Text NoMoreUpgrade;
    public Text GGwanglotto;
    public Text Successlotto;
    public Text CantUseHpPotion;
    public Text NoMoreSpawnBoss;
    public bool Skill1IsOpen = false;
    public bool Skill2IsOpen = false;
    public bool Skill3IsOpen = false;

    int StatsUpgradeMoney = 3000; // 스탯 업그레이드 비용

    float BtnCooltime = 0f;
    public int maxBosscount = 0;
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

    public int HpPotionMoney = 5000;
    public int SkillUpgradeGold = 3000; // 스킬 업그레이드 비용
    public int MonUpgradeGold = 3000; // 몬스터 업그레이드 비용
    public int BossSpawnGold = 100000; // 보스 스폰 비용

    private void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        BtnCooltime -= Time.unscaledDeltaTime; // timescale이 0일때도 시간이 감.
        Shop(); // 상점 열고 닫기
        ViewGold(); // 상점내부에 현재 골드 보이기

        if (Boss1.gameObject.activeSelf == true && maxBosscount == 1)
        {
            Boss = Instantiate(BossPrefab, BossSpawnPoint.position, transform.rotation);
            maxBosscount = 0;
        }

        if(Boss==null)
        {
            Boss1.gameObject.SetActive(false);
        }
        
    }

    public void Shop()
    {
        if (Input.GetKeyDown(KeyCode.U) && shopopen == false)
        {
            Time.timeScale = 0;
            ShopUI.SetActive(true);
            StatsUI.SetActive(false);
            SKillsUI.SetActive(false);
            EnemyUI.SetActive(false);
            LottoUI.SetActive(false);
            shopopen = true;
        }
        else if (Input.GetKeyDown(KeyCode.U) && shopopen == true)
        {
            Time.timeScale = 1;
            ShopUI.SetActive(false);
            StatsUI.SetActive(false);
            SKillsUI.SetActive(false);
            EnemyUI.SetActive(false);
            LottoUI.SetActive(false);
            shopopen = false;
        }
    } // 상점 열고 닫기

    public void ViewGold() // 스탯 탭
    {
        Player p = player.GetComponent<Player>();
        CurGoldText.text = "골드 : " + p.gold.ToString("N0");
    }

    public void onclickStatsButton() // 스탯 탭
    {
        StatsUI.SetActive(true);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        LottoUI.SetActive(false);

    }

    public void onclickSkillsButton() // 스킬 탭
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(true);
        EnemyUI.SetActive(false);
        LottoUI.SetActive(false);

    }

    public void onclickEnemyButton() // 적 탭
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(true);
        LottoUI.SetActive(false);

    }

    
    public void onclickGamebleButton() // 도박 탭
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        LottoUI.SetActive(true);

    }

    public void onclickTipButton() // 팁 탭
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        LottoUI.SetActive(false);
        if (BtnCooltime <= 0f)
        {
            if (player.gold < 1000)
            {
                int ran = Random.Range(0, NotEnoughTip.Length);
                switch (ran)
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
                switch (ran)
                {
                    case 0:
                        EnoughTipText.text = EnoughTip[0];
                        break;
                    case 1:
                        EnoughTipText.text = EnoughTip[1];
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
            BtnCooltime = 1.3f;
        }
    }


    IEnumerator CantRecoveryHp()
    {
        yield return new WaitForSecondsRealtime(1f);
        CantUseHpPotion.gameObject.SetActive(false);
    }
    IEnumerator LottoTextCo() // 로또 꽝 or 당첨 텍스트 없애는 쿨타임
    {
        yield return new WaitForSecondsRealtime(1f);
        GGwanglotto.gameObject.SetActive(false);
        Successlotto.gameObject.SetActive(false);
    }

    IEnumerator NotEnoughTipCo() // 팁 줄 때 잔액에 따른 텍스트 없애는 쿨타임
    {
        yield return new WaitForSecondsRealtime(1f);
        NotEnoughTipText.gameObject.SetActive(false);
    }

    IEnumerator EnoughTipCo() // 팁 줄 때 잔액에 따른 텍스트 없애는 쿨타임
    {
        yield return new WaitForSecondsRealtime(1f);
        EnoughTipText.gameObject.SetActive(false);
    }

    IEnumerator NoMoreUpgradeCo() // 업그레이드 최대치일 때 텍스트 없애는 쿨타임
    {
        yield return new WaitForSecondsRealtime(1f);
        NoMoreUpgrade.gameObject.SetActive(false);
    }

    IEnumerator NotEnoughGoldCo() // 업그레이드 비용 없을 때 텍스트 없애는 쿨타임
    {
        yield return new WaitForSecondsRealtime(1f);
        NotEnoughUpgradeMoney.gameObject.SetActive(false);
    }

    IEnumerator NoMoreBossCo()
    {
        yield return new WaitForSecondsRealtime(1f);
        NoMoreSpawnBoss.gameObject.SetActive(false);
    }

    public void onclickAtkBtn() // 기본 공격 증가 
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
            BtnCooltime = 1.3f;
        }
    }

    public void onclickWalkSpdBtn() // 이속 증가
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
            BtnCooltime = 1.3f;
        }
    }

    public void onclickMaxHpBtn() // 최대 체력 증가
    {
        Status status = player.gameObject.GetComponent<Status>();
        if (BtnCooltime <= 0f)
        {
            if (status.MaxHp < MaxHpPlus)
            {
                if (player.gold >= 5000)
                {
                    player.gold -= 5000;
                    status.MaxHp += 100;
                }
                else if (player.gold < 5000)
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
            BtnCooltime = 1.3f;
        }
    }

    public void onclickHpPotionBtn() // 물약 포션
    {
        Status status = player.gameObject.GetComponent<Status>();
        if (BtnCooltime <= 0f)
        {
            if (player.gold >= HpPotionMoney)
            {
                if (status.CurHp < status.MaxHp)
                {
                    player.gold -= HpPotionMoney;
                    status.CurHp += 50;
                    if (status.CurHp >= status.MaxHp)
                    {
                        status.CurHp = status.MaxHp;
                    }
                }
                else if (status.CurHp == status.MaxHp) // 현재 체력이 최대체력과 같을 때 회복 사용 불가 텍스트 노출
                {
                    CantUseHpPotion.gameObject.SetActive(true);
                    StartCoroutine(CantRecoveryHp());
                }
            }
            else if (player.gold < HpPotionMoney)
            {
                NotEnoughUpgradeMoney.gameObject.SetActive(true);
                StartCoroutine(NotEnoughGoldCo());
            }
            BtnCooltime = 1.3f;
        }


    }

    public void onclickSkill1Btn() // 스킬 1 버튼 업그레이드 버튼
    {
        if (BtnCooltime <= 0f)
        {
            // 군인
            if (player.tag == "Soldier")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill1IsOpen = true;
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

            // 검사
            if (player.tag == "Worrior")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill1IsOpen = true;
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

            // 불법
            if (player.tag == "FireMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill1IsOpen = true;
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

            // 물법
            if (player.tag == "WaterMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill1IsOpen = true;
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

            // 바람법
            if (player.tag == "WindMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill1IsOpen = true;
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
            BtnCooltime = 1.3f;
        }

    }

    public void onclickSkill2Btn() // 스킬 2 버튼 업그레이드 버튼
    {
        if (BtnCooltime <= 0f)
        {    // 군인
            if (player.tag == "Soldier")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill2IsOpen = true;
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

            // 검사
            if (player.tag == "Worrior")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill2IsOpen = true;
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

            // 물법
            if (player.tag == "WaterMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill2IsOpen = true;
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

            // 바람법
            if (player.tag == "WindMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill2IsOpen = true;
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

            // 불법
            if (player.tag == "FireMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill2IsOpen = true;
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
            BtnCooltime = 1.3f;
        }
    }

    public void onclickSkill3Btn() // 스킬 3 버튼 업그레이드 버튼
    {
        if (BtnCooltime <= 0f)
        {
            // 군인
            if (player.tag == "Soldier")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill3IsOpen = true;
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

            // 검사
            if (player.tag == "Worrior")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill3IsOpen = true;
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

            // 물법
            if (player.tag == "WaterMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill3IsOpen = true;
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

            // 바람법
            if (player.tag == "WindMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill3IsOpen = true;
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

            // 불법
            if (player.tag == "FireMagician")
            {
                if (player.gold >= SkillUpgradeGold)
                {
                    Skill3IsOpen = true;
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
            BtnCooltime = 1.3f;
        }
    }

    public void onclickMonSpdBtn() // 몬스터 이속 증가
    {
        if (BtnCooltime <= 0f)
        {
            GameObject PoolingMangerobj = GameObject.Find("PoolingManager");
            if (PoolingMangerobj != null)
            {
                PoolingManager poolingmanager = PoolingMangerobj.GetComponent<PoolingManager>();
                if (poolingmanager != null)
                {
                    if (upGradeSpdLevel < MaxUpGradeSpdLevel)
                    {
                        if (player.gold >= MonUpgradeGold)
                        {
                            ++upGradeSpdLevel;
                            player.gold -= MonUpgradeGold;
                            poolingmanager.AddSpeed = 1 * upGradeSpdLevel;
                        }

                        else if (player.gold < MonUpgradeGold)
                        {
                            NotEnoughUpgradeMoney.gameObject.SetActive(true);
                            StartCoroutine(NotEnoughGoldCo());
                        }
                    }

                    else if (upGradeSpdLevel == MaxUpGradeSpdLevel)
                    {
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                    BtnCooltime = 1.3f;
                }
            }
        }
    }

    public void onclickMonLvupBtn() // 몬스터 레벨 증가 (획득 골드 증가)
    {
        if (BtnCooltime <= 0f)
        {
            GameObject PoolingMangerobj = GameObject.Find("PoolingManager");
            if (PoolingMangerobj != null)
            {
                PoolingManager poolingmanager = PoolingMangerobj.GetComponent<PoolingManager>();
                if (poolingmanager != null)
                {
                    if (upGradeGoldLevel < MaxUpGradeGoldLevel)
                    {

                        if (player.gold >= MonUpgradeGold)
                        {
                            ++upGradeGoldLevel;
                            player.gold -= MonUpgradeGold;
                            player.Addmoney += 50 * upGradeGoldLevel;
                            poolingmanager.AddHp = 100 * upGradeGoldLevel;
                        }

                        else if (player.gold < MonUpgradeGold)
                        {
                            NotEnoughUpgradeMoney.gameObject.SetActive(true);
                            StartCoroutine(NotEnoughGoldCo());
                        }
                    }

                    else if (upGradeGoldLevel == MaxUpGradeGoldLevel)
                    {
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                    BtnCooltime = 1.3f;
                }
            }
        }
    }

    public void onclickMonSpawnSpdBtn() // 몹 스폰속도 증가
    {
        if (BtnCooltime <= 0f)
        {
            GameObject spawnEnemiesobj = GameObject.Find("SpawnEnemies");
            if (spawnEnemiesobj != null)
            {
                SpawnEnemies spawnEnemies = spawnEnemiesobj.GetComponent<SpawnEnemies>();
                if (spawnEnemies != null)
                {
                    if (0.1f < spawnEnemies.spawnInterval)
                    {
                        if (player.gold >= MonUpgradeGold)
                        {
                            player.gold -= MonUpgradeGold;
                            spawnEnemies.spawnInterval -= 0.1f;
                        }

                        else if (player.gold < MonUpgradeGold)
                        {
                            NotEnoughUpgradeMoney.gameObject.SetActive(true);
                            StartCoroutine(NotEnoughGoldCo());
                        }

                    }
                    else if (spawnEnemies.spawnInterval <= 0.1f)
                    {
                        NoMoreUpgrade.gameObject.SetActive(true);
                        StartCoroutine(NoMoreUpgradeCo());
                    }
                    BtnCooltime = 1.3f;
                }
            }
        }
    }

    public void onclickBossSpawnBtn() // 보스 몹 스폰 (대량 골드 획득)
    {
        if (BtnCooltime <= 0f)
        {
            if (Boss1.gameObject.activeSelf == false)
            {
                if (player.gold >= BossSpawnGold)
                {
                    Boss1.gameObject.SetActive(true);
                    maxBosscount++;
                    bossSpawn = true;
                    player.gold -= BossSpawnGold;
                }

                else if (player.gold < BossSpawnGold)
                {
                    NotEnoughUpgradeMoney.gameObject.SetActive(true);
                    StartCoroutine(NotEnoughGoldCo());
                }
            }

            else if (Boss1.gameObject.activeSelf == true)
            {
                NoMoreSpawnBoss.gameObject.SetActive(true);
                StartCoroutine(NoMoreBossCo());
            }
            BtnCooltime = 1.3f;
            return;
        }

    }

    public void onLottoclick1() // 로또 1 클릭
    {
        if (BtnCooltime <= 0)
        {
            if (player.gold >= Lotto1)
            {
                player.gold -= Lotto1;
                int a = Random.Range(1, 100);
                if (a <= 40)
                {
                    player.gold += Lotto1 * 5;
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
            BtnCooltime = 1.3f;
        }
    }

    public void onLottoclick2() // 로또 2 클릭
    {
        if (BtnCooltime <= 0)
        {
            if (player.gold >= Lotto2)
            {
                player.gold -= Lotto2;
                int a = Random.Range(1, 100);
                if (a <= 10)
                {
                    player.gold += Lotto2 * 10;
                    Successlotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
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
            BtnCooltime = 1.3f;
        }
    }

    public void onLottoclick3() // 로또 3 클릭
    {
        if (BtnCooltime <= 0)
        {
            if (player.gold >= Lotto3)
            {
                player.gold -= Lotto3;
                int a = Random.Range(1, 100);
                if (a <= 1)
                {
                    player.gold += Lotto3 * 100;
                    Successlotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
                }
                else
                {
                    GGwanglotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
                }
            }

            else if (player.gold < Lotto3)
            {
                NotEnoughUpgradeMoney.gameObject.SetActive(true);
                StartCoroutine(NotEnoughGoldCo());
            }
            BtnCooltime = 1.3f;
        }
    }

    public void onLottoclick4() // 로또 4 클릭
    {
        if (BtnCooltime <= 0)
        {
            if (player.gold >= Lotto4)
            {
                player.gold -= Lotto4;
                int a = Random.Range(1, 1000);
                if (a <= 1)
                {
                    player.gold += Lotto4 * 1000;
                    Successlotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
                }
                else
                {
                    GGwanglotto.gameObject.SetActive(true);
                    StartCoroutine(LottoTextCo());
                }
            }

            else if (player.gold < Lotto4)
            {
                NotEnoughUpgradeMoney.gameObject.SetActive(true);
                StartCoroutine(NotEnoughGoldCo());
            }
            BtnCooltime = 1.3f;
        }
    }

    public void QuitShop() // 상점 닫기
    {
        Time.timeScale = 1;
        ShopUI.SetActive(false);
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        LottoUI.SetActive(false);
        shopopen = false;
    }

    public Slider BossHPSlider()
    {
        return Boss1;
    }
}