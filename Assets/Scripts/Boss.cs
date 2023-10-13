using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    Status status;
    public int Hp = 100000;
    int DropGold = 100000;
    NavMeshAgent nvAgent;
    Transform player;
    public float Atk = 80f;
    private Vector3 dir;
    public float dist;
    public float Attackdist = 2f;
    bool isDead;
    bool isAttack;
    CapsuleCollider cc;
    Animator ani;
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

        if (isDead)
        { 
            return; 
        }
        

        if(Hp<=0)
        {
            cc.enabled = false;
            Death();
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if(!isAttack&&dist!=0)
            Trace();
        }
    }

    void Trace()
    {
        ani.SetBool("isWalk", true);
        ani.SetBool("isAttack", false);
        nvAgent.angularSpeed = 5000000f * Time.deltaTime;
        nvAgent.acceleration = 8000000f * Time.deltaTime;
        nvAgent.speed = 14f;
        dir = player.position;
        nvAgent.SetDestination(dir);
        if(dist<=Attackdist)
        {
            isAttack = true;
            transform.LookAt(dir);
            StartCoroutine(AttackCo());
        }

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
    }

    void Death()
    {
        isDead = true;
        StartCoroutine(DeathCo());
        player.gameObject.GetComponent<Player>().GetGold(DropGold);
    }

    public void OnHit()
    {
        Hp -= status.Atk;
    }

    public void Onhit(int skilldamage)
    {
        Hp -= skilldamage;
    }
}
