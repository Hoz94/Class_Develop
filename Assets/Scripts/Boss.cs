using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Status status;
    const float firstpaze=250000f;
    public float MaxHp;
    public float Hp;
    int DropGold = 300000;
    NavMeshAgent nvAgent;
    Transform player;
    public float Atk;
    public float JumpAtk;
    private Vector3 dir;
    public float dist;
    public float Attackdist;
    bool isDead;
    bool isAttack;
    bool isJumpAttack;
    CapsuleCollider cc;
    Animator ani;
    float Jumpcooltime;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        status = player.GetComponent<Status>();
        cc = GetComponent<CapsuleCollider>();
        nvAgent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        MaxHp = 500000f;
        Hp = 500000f;
        DropGold = 300000;
        Atk = 80f;
        JumpAtk = 100f;
        Attackdist = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.gameObject.transform.position, player.position);
        Jumpcooltime += Time.deltaTime;
        if (isDead)
        {
            return;
        }
        HandleBossHP();
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (!isAttack && dist != 0)
            {
                if (firstpaze <= Hp)
                {
                    Trace();
                }
                else if (Hp < firstpaze)
                {
                    Run();
                }
            }
        }
    }


    void Run()
    {
        ani.SetBool("isRun", true);
        ani.SetBool("isAttack", false);
        nvAgent.angularSpeed = 5000000f * Time.deltaTime;
        nvAgent.acceleration = 8000000f * Time.deltaTime;
        nvAgent.speed = 14f;
        dir = player.position;
        nvAgent.SetDestination(dir);
        if (dist <= Attackdist && Jumpcooltime < 15f)
        {
            isAttack = true;
            transform.LookAt(dir);
            StartCoroutine(RunAttackCo());
        }
        else if (dist >= 5f && Jumpcooltime >= 15f)
        {
            isJumpAttack = true;
            transform.LookAt(dir);
            StartCoroutine(JumpAttackCo());
            Jumpcooltime = 0f;
        }
    }

    void Trace()
    {
        ani.SetBool("isWalk", true);
        ani.SetBool("isAttack", false);
        nvAgent.angularSpeed = 5000000f * Time.deltaTime;
        nvAgent.acceleration = 8000000f * Time.deltaTime;
        nvAgent.speed = 7f;
        dir = player.position;
        nvAgent.SetDestination(dir);
        if (dist <= Attackdist)
        {
            isAttack = true;
            transform.LookAt(dir);
            StartCoroutine(AttackCo());
        }
    }

    IEnumerator JumpAttackCo()
    {
        ani.SetBool("isJump", true);
        ani.SetBool("isRun", false);
        yield return new WaitForSeconds(1.5f);
        this.transform.position = player.position;
        status.CurHp -= JumpAtk;
        yield return new WaitForSeconds(1f);
        ani.SetBool("isJump", false);
        ani.SetBool("isRun", true);

        isJumpAttack = false;
    }

    IEnumerator RunAttackCo()
    {
        ani.SetBool("isAttack", true);
        ani.SetBool("isRun", false);
        status.CurHp -= Atk;
        nvAgent.velocity = Vector3.zero;
        nvAgent.speed = 0f;
        nvAgent.acceleration = 0f;
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }

    IEnumerator AttackCo()
    {
        ani.SetBool("isAttack", true);
        ani.SetBool("isWalk", false);
        status.CurHp -= Atk;
        nvAgent.velocity = Vector3.zero;
        nvAgent.speed = 0f;
        nvAgent.acceleration = 0f;
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }

    IEnumerator DeathCo()
    {
        nvAgent.velocity = Vector3.zero;
        nvAgent.speed = 0f;
        nvAgent.acceleration = 0f;
        ani.SetTrigger("isDead");
        yield return new WaitForSeconds(2.5f);
        // 비활성화 전에 DropGold 획득 및 제거
        player.gameObject.GetComponent<Player>().GetGold(DropGold);
        Destroy(this.gameObject);
    }

    void Death()
    {
        GameObject gameObject = GameObject.Find("ShopUIManager");
        ShopManager shopmanager = gameObject.GetComponent<ShopManager>();
        shopmanager.bossSpawn = false;
        StopAllCoroutines();
        isDead = true;
        StartCoroutine(DeathCo());
        cc.enabled = false;
    }

    public void OnHit()
    {
        Hp -= status.Atk;
        if (Hp <= 0)
        {
            ShopManager._instance.Boss1.value = 0f;
            Death();
        }
    }

    public void OnHit(int skilldamage)
    {
        Hp -= skilldamage;
        if (Hp <= 0)
        {
            ShopManager._instance.Boss1.value = 0f;
            Death();
        }
    }

    public void HandleBossHP()
    {
        GameObject obj = GameObject.Find("ShopUIManager");
        Slider Boss1 = obj.GetComponent<ShopManager>().BossHPSlider();
        Boss1.value = Hp / MaxHp;
    }
}