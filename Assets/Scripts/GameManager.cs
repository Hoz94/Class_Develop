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
    public Text MyAtk; // 현재 공격력
    public Text MySpd; // 현재 이동속도
    public Text MyMaxHp; // 현재 최대체력
    public Text GameTimeText; // 현재까지 게임시간
    public Text KillEnemyCount; // 현재까지 죽인 일반몹 수
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

    void Option()
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnGameInfoBtn() // 게임정보
    {
        Status stat = player.GetComponent<Status>();
        MyOptionDetail.gameObject.SetActive(true);
        MyAtk.text = "현재 공격력 : " + stat.Atk.ToString("N0");
        MySpd.text = "현재 이동속도 : " + stat.Spd.ToString("N0");
        MyMaxHp.text = "최대 생명력 : " + stat.MaxHp.ToString("N0");
        GameTimeText.text = "게임이용시간 : " + ((float)Gametime/(float)60).ToString("N0")+"분 "+ ((float)Gametime % (float)60).ToString("N0") + "초";
        KillEnemyCount.text = "죽인 적의 수(일반몬스터) : " + killedEnemyCount.ToString("N0") + " 마리";
    }


    public void OnNewClassChoiceBtn() // 직업 재선택
    {
        player.transform.position = PlayerSpawnPoint.position;
        
    }

    public void OnReturnToGameBtn() // 게임 돌아가기
    {
        Time.timeScale = 1;
    }

    public void OnQuitGameBtn() // 게임종료
    {
        Application.Quit();
    }


    public void KillEnemyCountMethod()
    {
        killedEnemyCount++;

    }


}
