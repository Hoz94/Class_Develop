using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    Player player;
    public Transform skillpos; // 스킬이 나가는 위치
    public GameObject SoldierSkillPrefab;
    public GameObject WorriorSkillPrefab;
    public GameObject FireMagicianSkillPrefab;
    public GameObject WaterMagicianSkillPrefab;
    public GameObject WindMagicianSkillPrefab;
    public GameObject SkillInput; // 인스턴스한것을 저장하는 오브젝트

    public float SpecialSkillCool = 15f; // 필살기 쿨타임
    public float SpecialSkillTime = 30f;
    public float Skill1Cool = 5f; // 1번스킬 쿨타임
    public float Skill2Cool = 8f; // 2번스킬 쿨타임
    public float Skill3Cool = 9f; // 3번스킬 쿨타임
    public float Skill1Time = 5f;
    public float Skill2Time = 8f;
    public float Skill3Time = 9f;

    // Start is called before the first frame update
    void Start()
    {
        player= GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpecialSkillCool == SpecialSkillTime)
        {
            SpecialSkill(); // 필살기 (Q로 사용)
        }

        ActiveSkill(); // 일반 스킬 사용 (1, 2, 3번)

        SkillCoolTime(); // 쿨타임 관리 메서드


    }

    void SpecialSkill() // 각 태그별 필살기
    {
        if (player.tag == "Soldier")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(SoldierSkillPrefab, transform.position, transform.rotation);
                SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
                Destroy(SkillInput, 15f);
                
            }
        }

        if (player.tag == "Worrior")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WorriorSkillPrefab, transform.position, transform.rotation);
                Destroy(SkillInput, 15f);
            }
        }

        if (player.tag == "FireMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(FireMagicianSkillPrefab, transform.position, transform.rotation);
                Destroy(SkillInput, 15f);
            }
        }

        if (player.tag == "WaterMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WaterMagicianSkillPrefab, transform.position, transform.rotation);
                SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                Destroy(SkillInput, 15f);
            }
        }

        if (player.tag == "WindMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WindMagicianSkillPrefab, skillpos.transform.position, transform.rotation);
                Destroy(SkillInput, 15f);
            }
        }
        
    }


    void ActiveSkill()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)&&Skill1Cool==Skill1Time) // 1번을 눌렀을 때
        {
            if (player.tag == "Soldier")
            {
                Skill1Time = 0f;
            }

            if (player.tag == "Worrior")
            {
                Skill1Time = 0f;
            }

            if (player.tag == "FireMagician")
            {
                Skill1Time = 0f;
            }

            if (player.tag == "WaterMagician")
            {
                Skill1Time = 0f;
            }

            if (player.tag == "WindMagician")
            {
                Skill1Time = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && Skill2Cool == Skill2Time) // 2번을 눌렀을 때
        {
            if (player.tag == "Soldier")
            {
                Skill2Time = 0f;
            }

            if (player.tag == "Worrior")
            {
                Skill2Time = 0f;
            }

            if (player.tag == "FireMagician")
            {
                Skill2Time = 0f;
            }

            if (player.tag == "WaterMagician")
            {
                Skill2Time = 0f;
            }

            if (player.tag == "WindMagician")
            {
                Skill2Time = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && Skill3Cool == Skill3Time) // 3번을 눌렀을 때
        {
            if (player.tag == "Soldier")
            {
                Skill3Time = 0f;
            }

            if (player.tag == "Worrior")
            {
                Skill3Time = 0f;
            }

            if (player.tag == "FireMagician")
            {
                Skill3Time = 0f;
            }

            if (player.tag == "WaterMagician")
            {
                Skill3Time = 0f;
            }

            if (player.tag == "WindMagician")
            {
                Skill3Time = 0f;
            }
            
        }
    }


    void SkillCoolTime() // 스킬 쿨타임
    {
        if (SpecialSkillTime <= SpecialSkillCool)
        {
            SpecialSkillTime += Time.deltaTime;
        }

        if (SpecialSkillTime >= SpecialSkillCool)
        {
            SpecialSkillTime = SpecialSkillCool;
        }

        if (Skill1Time<=Skill1Cool)
        {
            Skill1Time += Time.deltaTime;
        
        }

        if(Skill1Time>=Skill1Cool)
        {
            Skill1Time = Skill1Cool;
        }

        if (Skill2Time <= Skill2Cool)
        {
            Skill2Time += Time.deltaTime;

        }

        if (Skill2Time >= Skill2Cool)
        {
            Skill2Time = Skill2Cool;
        }

        if (Skill3Time <= Skill3Cool)
        {
            Skill3Time += Time.deltaTime;

        }

        if (Skill3Time >= Skill3Cool)
        {
            Skill3Time = Skill3Cool;
        }
    }

}
