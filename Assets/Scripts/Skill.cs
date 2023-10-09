using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public ShopManager shopManager;
    Player player;
    public Transform skillpos; // 스킬이 나가는 위치
    public GameObject SkillInput; // 인스턴스한것을 저장하는 오브젝트
    [Header ("각 직업별 필살기 프리팹")]
    public GameObject SoldierSpecialSkillPrefab;
    public GameObject WorriorSpecialSkillPrefab;
    public GameObject FireMagicianSpecialSkillPrefab;
    public GameObject WaterMagicianSpecialSkillPrefab;
    public GameObject WindMagicianSpecialSkillPrefab;
    
    [Header ("군인 1번 액티브스킬 프리팹")]
    public GameObject SoldierSkill1Prefab1;
    public GameObject SoldierSkill1Prefab2;
    public GameObject SoldierSkill1Prefab3;
    [Header("군인 2번 액티브스킬 프리팹")]
    public GameObject SoldierSkill2Prefab1;
    public GameObject SoldierSkill2Prefab2;
    public GameObject SoldierSkill2Prefab3;
    [Header("군인 3번 액티브스킬 프리팹")]
    public GameObject SoldierSkill3Prefab1;
    public GameObject SoldierSkill3Prefab2;
    public GameObject SoldierSkill3Prefab3;
    [Header("검사 액티브스킬 프리팹")]
    public GameObject WorriorSkill1Prefab;
    public GameObject WorriorSkill2Prefab;
    public GameObject WorriorSkill3Prefab;
    [Header("불법사 액티브스킬 프리팹")]
    public GameObject FireMagicianSkill1Prefab;
    public GameObject FireMagicianSkill2Prefab;
    public GameObject FireMagicianSkill3Prefab;
    [Header("물법사 액티브스킬 프리팹")]
    public GameObject WaterMagicianSkill1Prefab;
    public GameObject WaterMagicianSkill2Prefab;
    public GameObject WaterMagicianSkill3Prefab;
    [Header("바람법사 액티브스킬 프리팹")]
    public GameObject WindMagicianSkill1Prefab;
    public GameObject WindMagicianSkill2Prefab;
    public GameObject WindMagicianSkill3Prefab;

    [Header ("스킬 쿨타임")]
    public float SpecialSkillCool = 15f; // 필살기 쿨타임
    public float SpecialSkillTime = 0f;
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

    void SpecialSkill() // 각 직업별 필살기
    {
        if (player.tag == "Soldier")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(SoldierSpecialSkillPrefab, transform.position, transform.rotation);
                SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
                Destroy(SkillInput, 15f);
                
            }
        }

        if (player.tag == "Worrior")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WorriorSpecialSkillPrefab, transform.position, transform.rotation);
                Destroy(SkillInput, 15f);
            }
        }

        if (player.tag == "FireMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(FireMagicianSpecialSkillPrefab, transform.position, transform.rotation);
                Destroy(SkillInput, 15f);
            }
        }

        if (player.tag == "WaterMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WaterMagicianSpecialSkillPrefab, transform.position, transform.rotation);
                SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                Destroy(SkillInput, 15f);
            }
        }

        if (player.tag == "WindMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WindMagicianSpecialSkillPrefab, skillpos.transform.position, transform.rotation);
                Destroy(SkillInput, 15f);
            }
        }
        
    }


    void ActiveSkill()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)&&Skill1Cool==Skill1Time) // 1번 눌렀을 때
        {
            if (player.tag == "Soldier")
            {
                if(shopManager.SoldierSkill1==1)
                {
                    SkillInput=Instantiate(SoldierSkill1Prefab1, transform.position, transform.rotation);
                }

                if(shopManager.SoldierSkill1==2)
                {
                    SkillInput = Instantiate(SoldierSkill1Prefab2, transform.position, transform.rotation);
                }

                if (shopManager.SoldierSkill1 == 3)
                {
                    SkillInput = Instantiate(SoldierSkill1Prefab3, transform.position, transform.rotation);
                }
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
        } // 1번을 눌렀을 때

        if (Input.GetKeyDown(KeyCode.Alpha2) && Skill2Cool == Skill2Time) // 2번을 눌렀을 때
        {
            if (player.tag == "Soldier")
            {
                if (shopManager.SoldierSkill2 == 1)
                {
                    SkillInput = Instantiate(SoldierSkill2Prefab1, transform.position, transform.rotation);
                }

                if (shopManager.SoldierSkill2 == 2)
                {
                    SkillInput = Instantiate(SoldierSkill2Prefab2, transform.position, transform.rotation);
                }

                if (shopManager.SoldierSkill2 == 3)
                {
                    SkillInput = Instantiate(SoldierSkill2Prefab3, transform.position, transform.rotation);
                }
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
        }// 2번 눌렀을 때

        if (Input.GetKeyDown(KeyCode.Alpha3) && Skill3Cool == Skill3Time) // 3번을 눌렀을 때
        {
            if (player.tag == "Soldier")
            {
                if (shopManager.SoldierSkill3 == 1)
                {
                    SkillInput = Instantiate(SoldierSkill3Prefab1, transform.position, transform.rotation);
                }

/*                if (shopManager.SoldierSkill3 == 2)
                {
                    SkillInput = Instantiate(SoldierSkill3Prefab2, transform.position, transform.rotation);
                }*/

                if (shopManager.SoldierSkill3 == 3)
                {
                    SkillInput = Instantiate(SoldierSkill3Prefab3, transform.position, transform.rotation);
                    SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
                }
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
