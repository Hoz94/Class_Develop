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
    float GoalGold = 2000000;
    public Slider Skill1;
    public Slider Skill2;
    public Slider Skill3;
    // Start is called before the first frame update
    void Start()
    {
        HPslider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        printGold();
        if (Time.timeScale == 1)
        {
            PlayerUICanvas.gameObject.SetActive(true);
            HandleHP();
            printGoalValue();
        }

        /*if(ShopManager.Skill1IsOpen)
        {
            HandleSkill1();
        }

        if(ShopManager.Skill2IsOpen)
        {
            HandleSkill2();
        }

        if(ShopManager .Skill3IsOpen)
        {
            HandleSkill3();
        }*/
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

    void HandleHP()
    {
        Status status = player.gameObject.GetComponent<Status>();
        HPslider.value = status.CurHp / status.MaxHp;

    }

    void HandleSkill1()
    {
        Skill skill=player.gameObject.GetComponent<Skill>();
        Skill1.value = skill.Skill1Time / skill.Skill1Cool;
    }

    void HandleSkill2()
    {
        Skill skill = player.gameObject.GetComponent<Skill>();
        Skill2.value = skill.Skill2Time / skill.Skill2Cool;
    }

    void HandleSkill3()
    {
        Skill skill = player.gameObject.GetComponent<Skill>();
        Skill3.value = skill.Skill3Time / skill.Skill3Cool;
    }

}