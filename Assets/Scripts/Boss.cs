using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    Status status;
    const int firstpaze = 1000000;
    public int Hp = 2000000;
    int DropGold = 500000;
    NavMeshAgent nvAgent;
    Transform player;
    public float Atk = 80f;
    public float JumpAtk = 100f;
    private Vector3 dir;
    public float dist;
    public float Attackdist = 2.5f;
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
        status=player.GetComponent<Status>();
        cc=GetComponent<CapsuleCollider>();
        nvAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        ani=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.gameObject.transform.position, player.position);
        Jumpcooltime += Time.deltaTime;
        if(isDead)
        {
            return;
        }

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

                else if(Hp< firstpaze)
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
        if (dist <= Attackdist)
        {
            isAttack = true;
            transform.LookAt(dir);
            StartCoroutine(RunAttackCo());
        }
        else if(dist>=Attackdist&&Jumpcooltime>=15f)
        {
            isJumpAttack = true;
            transform.LookAt(dir);
            StartCoroutine(JumpAttackCo());
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
        if(dist<=Attackdist)
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
        yield return new WaitForSeconds(0.7f);
        this.gameObject.SetActive(false);
        /*nvAgent.velocity = Vector3.zero;
        nvAgent.speed = 0f;
        nvAgent.acceleration = 0f;*/
        yield return new WaitForSeconds(1.5f);
        this.transform.position = player.position;
        this.gameObject.SetActive(true);
        status.CurHp -= JumpAtk;
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
        ani.SetTrigger("isDead");
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    void Death()
    {
        isDead = true;
        StartCoroutine(DeathCo());
        player.gameObject.GetComponent<Player>().GetGold(DropGold);
        cc.enabled = false;
    }

    public void OnHit()
    {
        Hp -= status.Atk;
        if (Hp <= 0)
        {
            Death();
        }
    }

    public void OnHit(int skilldamage)
    {
        Hp -= skilldamage;
        if (Hp <= 0)
        {
            Death();
        }
    }
}
