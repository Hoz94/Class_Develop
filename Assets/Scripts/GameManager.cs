using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    Status status;
    public static GameManager _Instance;
    public GameObject player;
    public Player pr;
    public GameObject Pause;
    public Text MyAtk; // ���� ���ݷ�
    public Text MySpd; // ���� �̵��ӵ�
    public Text MyMaxHp; // ���� �ִ�ü��
    public Text MyCurHp; // ���� ü��
    public Text GameTimeText; // ������� ���ӽð�
    public Text KillEnemyCount; // ������� ���� �Ϲݸ� ��
    public Image MyOptionDetail;
    public int killedEnemyCount = 0;
    public Image WinImage;
    public Image GameOverImage;
    public float Gametime;
    float FillAmount;
    public float MaxAmount = 1f;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        status = player.GetComponent<Status>();
        Time.timeScale = 0;
        _Instance = this;
        pr = GetComponent<Player>();
        player.tag = "Untagged";
        Gametime = 0;
        FillAmount = 0f;
    }



    // Update is called once per frame
    void Update()
    {
        Gametime = Time.unscaledTime;
        if (Time.timeScale < 1)
        {
            Cursor.visible = true;
        }
        else if (Time.timeScale == 1)
        {
            Cursor.visible = false;
            Pause.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Escape)) 
        {
            Option();    
        }
        
        if(Player._instance.gold>=10000000)
        {
            FillAmount += Time.deltaTime;
            WinGame();   
        }
        if(status.CurHp<0)
        {
            FillAmount += Time.deltaTime;
            GameOver();
        }

    }

    void Option() // �ɼ�â ����
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
    }

    void WinGame()
    {
        WinImage.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void GameOver()
    {
        GameOverImage.fillAmount = FillAmount / MaxAmount;
        StartCoroutine(GameOverCo());   
    }

    public void OnGameInfoBtn() // ��������
    {
        Status stat = player.GetComponent<Status>();
        MyOptionDetail.gameObject.SetActive(true);
        MyAtk.text = "���� ���ݷ� : " + stat.Atk.ToString("N0");
        MySpd.text = "���� �̵��ӵ� : " + stat.Spd.ToString("N0");
        MyMaxHp.text = "�ִ� ü�� : " + stat.MaxHp.ToString("N0");
        MyCurHp.text = "���� ü�� : " + stat.CurHp.ToString("N0");
        GameTimeText.text = "�����̿�ð� : " + ((float)Gametime/(float)60).ToString("N0")+"�� "+ ((float)Gametime % (float)60).ToString("N0") + "��";
        KillEnemyCount.text = "���� ���� ��(�Ϲݸ���) : " + killedEnemyCount.ToString("N0") + " ����";
    }
    
    

    public void OnNewClassChoiceBtn() // ���� �缱��
    {
        SceneManager.LoadScene(0);
        
        
    }

    public void OnReturnToGameBtn() // ���� ���ư���
    {
        Time.timeScale = 1;
    }

    public void OnQuitGameBtn() // ��������
    {
        Application.Quit();
    }

    public void OnBackBtn()
    {
        MyOptionDetail.gameObject.SetActive(false);
        Option();
    }

    public void KillEnemyCountMethod() // ų �� �� ����
    {
        killedEnemyCount++;
    }

    IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(1f);
        GameOverImage.gameObject.SetActive(true);
        Time.timeScale = 0;
    }



}
