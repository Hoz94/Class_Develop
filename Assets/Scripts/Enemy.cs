using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using Debug = UnityEngine.Debug;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    SkillDamage SD;
    Status status;
    Transform player;
    public int MaxHP = 50;
    public int HP = 50;
    public float Atk = 1;
    public NavMeshAgent nvAgent;
    public float nowSpeed = 4.5f;
    private Vector3 dir;
    Animator _ani;
    public float dist;
    public float Attackdist = 2f;
    public float minGold=50f;
    public float MidGold=100f;
    public float MaxGold=150f;
    bool isDead;
    bool isAttack;
    CapsuleCollider cc;
    Skill skill;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        nvAgent = GetComponent<NavMeshAgent>();
        _ani = GetComponent<Animator>();
        status = player.GetComponent<Status>();
        cc = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }

        if (HP <= 0)
        {
            cc.enabled = false;
            Death();
        }
        dist = Vector3.Distance(this.gameObject.transform.position, player.position);

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
        MaxHP += AddHp;
        HP += AddHp;
    }

    public void SetSpeed(float speed)
    {
        nowSpeed=nvAgent.speed + speed;
    }
}