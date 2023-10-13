using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    Status status;
    public int Hp = 100000;
    NavMeshAgent nvAgent;
    Transform player;
    public float Atk = 80f;
    private Vector3 dir;
    public float dist;
    public float Attackdist = 2f;
    bool isDead;
    bool isAttack;
    bool isTrace;
    CapsuleCollider cc;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        status=player.GetComponent<Status>();
        cc=GetComponent<CapsuleCollider>();
        nvAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        ani=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        dist = Vector3.Distance(this.gameObject.transform.position, player.position);


        if(Hp<=0)
        {
            cc.enabled = false;
/*            Death();*/
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
        nvAgent.speed = 10f;
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
        nvAgent.velocity = Vector3.zero;
        nvAgent.speed = 0f;
        nvAgent.acceleration = 0f;
        status.CurHp -= Atk;
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }

    IEnumerator DeathCo()
    {

        yield return new WaitForSeconds(1.5f);
    }

    public void OnHit(int Atk)
    {
        Hp -= Atk;
    }
}
