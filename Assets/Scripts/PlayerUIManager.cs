using UnityEngine;
using UnityEngine.UI;
public class PlayerUIManager : MonoBehaviour
{
    public ShopManager ShopManager;
    public Player player;
    public Text goldText;
    public Slider HPslider;
    public Canvas PlayerUICanvas;
    public Slider GoalSlider;
    float GoalGold = 10000000;
    public Image Skill1;
    public Image Skill2;
    public Image Skill3;
    public Image SpecialSkill;
    public Text CurPlayTimeText;
    public float CurPlayTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        HPslider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CurPlayTime += Time.deltaTime;
        printGold();
        if (Time.timeScale == 1)
        {
            PlayerUICanvas.gameObject.SetActive(true);
            HandleHP();
            printGoalValue();
            HandlePlayTime();
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

        if (player != null)
        {
            SpecialSkill.gameObject.SetActive(true);
            Skill skill = player.gameObject.GetComponent<Skill>();
            SpecialSkill.fillAmount = skill.SpecialSkillTime / skill.SpecialSkillCool;
        }
    }


    void printGoalValue()
    {
        GoalSlider.value = player.gold / GoalGold;
    }

    void printGold()
    {
        float gold = player.gold;

        goldText.text = "모은 골드 : " + gold.ToString("N0");
    }

    void HandlePlayTime()
    {
        CurPlayTimeText.text = "플레이 타임 : "+((float)CurPlayTime / (float)60).ToString("N0")+"분 " + ((float)CurPlayTime % (float)60).ToString("N0")+"초";
    }

    void HandleHP()
    {
        Status status = player.gameObject.GetComponent<Status>();
        HPslider.value = status.CurHp / status.MaxHp;
    }

    void HandleSkill1()
    {
        Skill skill = player.gameObject.GetComponent<Skill>();
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