using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class PlayerUIManager : MonoBehaviour
{
    public ShopManager ShopManager;
    public Player player;
    public Text goldText;
    public Slider HPslider;
    public Canvas PlayerUICanvas;
    public Slider GoalSlider;
    float GoalGold = 5000000;
    public Image Skill1;
    public Image Skill2;
    public Image Skill3;
    public Image SpecialSkill;
    public Boss boss;
    public Slider Boss1Slider;
    public Slider Boss2Slider;
    // Start is called before the first frame update
    void Start()
    {
        HPslider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Boss1Slider.value: " + Boss1Slider.value);
        Debug.Log("Boss2Slider.value: " + Boss2Slider.value);
        printGold();
        if (Time.timeScale == 1)
        {
            PlayerUICanvas.gameObject.SetActive(true);
            HandleHP();
            printGoalValue();
        }

        if (ShopManager.Skill1IsOpen)
        {
            Skill1.gameObject.SetActive(true);
            HandleSkill1();
        }

        if (ShopManager.Skill2IsOpen)
        {
            Skill2.gameObject.SetActive(true);
            HandleSkill2();
        }

        if (ShopManager.Skill3IsOpen)
        {
            Skill3.gameObject.SetActive(true);
            HandleSkill3();
        }

        if(player!=null)
        {
            SpecialSkill.gameObject.SetActive(true);
            Skill skill = player.gameObject.GetComponent<Skill>();
            SpecialSkill.fillAmount = skill.SpecialSkillTime / skill.SpecialSkillCool;
        }

        if(ShopManager.bossSpawn==true)
        {
            Boss1Slider.gameObject.SetActive(true);
            Boss2Slider.gameObject.SetActive(false);
            BossHP();
        }
    }


    void printGoalValue()
    {
        GoalSlider.value = player.gold / GoalGold;
    }

    void printGold()
    {
        float gold = player.gold;

        goldText.text = "¸ðÀº °ñµå : " + gold.ToString("N0");
    }

    void BossHP()
    {
        
        Boss1Slider.value = boss.Hp / boss.MaxHp;
        
/*        if(boss.Hp<=250000f)
        {
            Boss1Slider.gameObject.SetActive(false);
            Boss2Slider.gameObject.SetActive(true);
            Boss2Slider.value = boss.Hp / 250000f;

        }*/
    }

    void HandleHP()
    {
        Status status = player.gameObject.GetComponent<Status>();
        HPslider.value = status.CurHp / status.MaxHp;
    }

    void HandleSkill1()
    {
        Skill skill=player.gameObject.GetComponent<Skill>();
        Skill1.fillAmount = skill.Skill1Time / skill.Skill1Cool;
    }

    void HandleSkill2()
    {
        Skill skill = player.gameObject.GetComponent<Skill>();
        Skill2.fillAmount = skill.Skill2Time / skill.Skill2Cool;
    }

    void HandleSkill3()
    {
        Skill skill = player.gameObject.GetComponent<Skill>();
        Skill3.fillAmount = skill.Skill3Time / skill.Skill3Cool;
    }

}