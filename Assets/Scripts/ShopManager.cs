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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    public void onclickStatsButton()
    {
        StatsUI.SetActive(true);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(false);
    }

    public void onclickSkillsButton()
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
    }

    public void onclickGamebleButton()
    {
        StatsUI.SetActive(false);
        SKillsUI.SetActive(false);
        EnemyUI.SetActive(false);
        GambleUI.SetActive(true);
    }

    public void onclickTipButton()
    {

        if (player.gold<=1000)
        {           
            NotEnoughTipText.gameObject.SetActive(true);
            StartCoroutine(NotEnoughTipCo());
        }
        if(player.gold>=1000)
        {
            player.gold -= 1000;
            EnoughTipText.gameObject.SetActive(true);
            StartCoroutine(EnoughTipCo());
        }
    }

    IEnumerator NotEnoughTipCo()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        NotEnoughTipText.gameObject.SetActive(false);
    }

    IEnumerator EnoughTipCo()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        EnoughTipText.gameObject.SetActive(false);
    }

    public void onclickAtkBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Atk += 10;
    }

    public void onclickWalkSpdBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.Spd += 1;
    }

    public void onclickMaxHpBtn()
    {
        Status status = player.gameObject.GetComponent<Status>();
        status.MaxHp += 30;
    }

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
    }

}
