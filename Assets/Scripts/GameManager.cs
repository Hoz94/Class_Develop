using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;
    public Transform PlayerSpawnPoint;
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

    public float Gametime; 
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawnPoint=GetComponent<Transform>();
        Time.timeScale = 0;
        _Instance = this;
        pr = GetComponent<Player>();
        player.tag = "Untagged";
        Gametime = 0;
        
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
    }

    void Option() // �ɼ�â ����
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
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

        Lobby._instance.GameStart();
        
    }

    public void OnReturnToGameBtn() // ���� ���ư���
    {
        Time.timeScale = 1;
    }

    public void OnQuitGameBtn() // ��������
    {
        Application.Quit();
    }


    public void KillEnemyCountMethod()
    {
        killedEnemyCount++;

    }


}
