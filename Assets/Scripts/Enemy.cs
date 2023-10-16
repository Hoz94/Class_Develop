using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public static Enemy _Instance;
    [SerializeField]
    SkillDamage SD;
    Status status;
    Transform player;
    int MaxHP;
    int HP;
    float Atk;
    public NavMeshAgent nvAgent;
    float nowSpeed;
    private Vector3 dir;
    Animator _ani;
    public float dist;
    float Attackdist;
    int minGold;
    int MidGold;
    int MaxGold;
    bool isDead;
    bool isAttack;
    CapsuleCollider cc;

    public int EnemyDeathCount;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        nvAgent = GetComponent<NavMeshAgent>();
        _ani = GetComponent<Animator>();
        status = player.GetComponent<Status>();
        cc = GetComponent<CapsuleCollider>();
        _Instance = this;
        MaxHP = 50;
        HP = 50;
        Atk = 1f;
        nowSpeed = 4.5f;
        isDead = false;
        isAttack = false;
        Attackdist = 2f;
        EnemyDeathCount = 0;
        minGold = 50;
        MidGold = 100;
        MaxGold = 150;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.gameObject.transform.position, player.position);

        if (isDead)
        {
            return;
        }

        if (HP <= 0)
        {
            cc.enabled = false;
            Death();
        }
        if (nvAgent.speed >= 13f)
        {
            nowSpeed = 13f;
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (!isAttack && dist != 0)
            {
                Trace();
            }
        }
    }

    void Trace()
    {
        _ani.SetBool("isRun", true);
        _ani.SetBool("isAttack", false);
        nvAgent.angularSpeed = 5000000 * Time.deltaTime;
        nvAgent.acceleration = 8000000 * Time.deltaTime;
        nvAgent.speed = nowSpeed;
        dir = player.position;
        nvAgent.SetDestination(dir);
        if (dist <= Attackdist)
        {
            isAttack = true;
            transform.LookAt(dir);
            StartCoroutine(Attackco());
        }

    }

    IEnumerator Attackco()
    {
        _ani.SetBool("isAttack", true);
        _ani.SetBool("isRun", false);
        status.CurHp -= Atk;
        nvAgent.speed = 0;
        nvAgent.velocity = Vector3.zero;
        nvAgent.acceleration = 0;
        nvAgent.angularSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        isAttack = false;

    }

    void Death()
    {
        GameManager._Instance.KillEnemyCountMethod();
        isDead = true;
        StartCoroutine(DeathCo());
        int Ran = Random.Range(0, 10);
        if (Ran < 7) // (0~6) 70% 
        {
            player.gameObject.GetComponent<Player>().GetGold(minGold);
        }
        else if (Ran < 9) // (7, 8) 20%
        {
            player.gameObject.GetComponent<Player>().GetGold(MidGold);
        }

        else if (Ran < 10) // (9) 10%
        {
            player.gameObject.GetComponent<Player>().GetGold(MaxGold);
        }

    }

    IEnumerator DeathCo()
    {
        _ani.SetTrigger("isDead");
        nvAgent.speed = nowSpeed;
        nvAgent.velocity = Vector3.zero;
        nvAgent.acceleration = 0;
        nvAgent.angularSpeed = 0;

        yield return new WaitForSeconds(1.5f);
        cc.enabled = true;
        HP = MaxHP;
        isDead = false;
        _ani.SetBool("isRun", true);
        this.gameObject.SetActive(false);
    }
    public void OnHit() // 기본공격
    {
        HP -= status.Atk;
    }


    public void OnHit(int SkillDamage) // 일반스킬, 필살기
    {
        HP -= SkillDamage;
    }

    public void SetHealth(int AddHp)
    {
        if (MaxHP <= 3000)
        {
            MaxHP += AddHp;
            HP += AddHp;
        }
    }

    public void SetSpeed(float speed)
    {
        nowSpeed = nvAgent.speed + speed;

    }
}