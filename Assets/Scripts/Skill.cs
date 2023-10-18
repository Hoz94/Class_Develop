using UnityEngine;

public class Skill : MonoBehaviour
{
    public ShopManager shopManager;
    Player player;
    public Transform skillpos; // 스킬이 나가는 위치
    public GameObject SkillInput; // 인스턴스한것을 저장하는 오브젝트

    [Header("각 직업별 필살기 프리팹")]
    public GameObject SoldierSpecialSkillPrefab;
    public GameObject WorriorSpecialSkillPrefab;
    public GameObject FireMagicianSpecialSkillPrefab;
    public GameObject WaterMagicianSpecialSkillPrefab;
    public GameObject WindMagicianSpecialSkillPrefab;
    [Header("군인 1번 액티브스킬 프리팹")]
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
    [Header("검사 1번 액티브스킬 프리팹")]
    public GameObject WorriorSkill1Prefab1;
    public GameObject WorriorSkill1Prefab2;
    public GameObject WorriorSkill1Prefab3;
    [Header("검사 2번 액티브스킬 프리팹")]
    public GameObject WorriorSkill2Prefab1;
    public GameObject WorriorSkill2Prefab2;
    public GameObject WorriorSkill2Prefab3;
    [Header("검사 3번 액티브스킬 프리팹")]
    public GameObject WorriorSkill3Prefab1;
    public GameObject WorriorSkill3Prefab2;
    public GameObject WorriorSkill3Prefab3;
    [Header("불법사 1번 액티브스킬 프리팹")]
    public GameObject FireMagicianSkill1Prefab1;
    public GameObject FireMagicianSkill1Prefab2;
    public GameObject FireMagicianSkill1Prefab3;
    [Header("불법사 2번 액티브스킬 프리팹")]
    public GameObject FireMagicianSkill2Prefab1;
    public GameObject FireMagicianSkill2Prefab2;
    public GameObject FireMagicianSkill2Prefab3;
    [Header("불법사 3번 액티브스킬 프리팹")]
    public GameObject FireMagicianSkill3Prefab1;
    public GameObject FireMagicianSkill3Prefab2;
    public GameObject FireMagicianSkill3Prefab3;
    [Header("물법사 1번 액티브스킬 프리팹")]
    public GameObject WaterMagicianSkill1Prefab1;
    public GameObject WaterMagicianSkill1Prefab2;
    public GameObject WaterMagicianSkill1Prefab3;
    [Header("물법사 2번 액티브스킬 프리팹")]
    public GameObject WaterMagicianSkill2Prefab1;
    public GameObject WaterMagicianSkill2Prefab2;
    public GameObject WaterMagicianSkill2Prefab3;
    [Header("물법사 3번 액티브스킬 프리팹")]
    public GameObject WaterMagicianSkill3Prefab1;
    public GameObject WaterMagicianSkill3Prefab2;
    public GameObject WaterMagicianSkill3Prefab3;
    [Header("바람법사 1번 액티브스킬 프리팹")]
    public GameObject WindMagicianSkill1Prefab1;
    public GameObject WindMagicianSkill1Prefab2;
    public GameObject WindMagicianSkill1Prefab3;
    [Header("바람법사 2번 액티브스킬 프리팹")]
    public GameObject WindMagicianSkill2Prefab1;
    public GameObject WindMagicianSkill2Prefab2;
    public GameObject WindMagicianSkill2Prefab3;
    [Header("바람법사 3번 액티브스킬 프리팹")]
    public GameObject WindMagicianSkill3Prefab1;
    public GameObject WindMagicianSkill3Prefab2;
    public GameObject WindMagicianSkill3Prefab3;

    [Header("스킬 쿨타임")]
    public float SpecialSkillCool = 30f; // 필살기 쿨타임
    public float SpecialSkillTime = 30f;
    public float Skill1Cool = 5f; // 1번스킬 쿨타임
    public float Skill2Cool = 10f; // 2번스킬 쿨타임
    public float Skill3Cool = 15f; // 3번스킬 쿨타임
    public float Skill1Time = 5f;
    public float Skill2Time = 10f;
    public float Skill3Time = 15f;

    [Header("1,2,3레벨 별 삭제변수")]
    public float Skill1DeleteTime = 5f;
    public float Skill2DeleteTime = 9.5f;
    public float Skill3DeleteTime = 14f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
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
        // 군인
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

        // 검사
        if (player.tag == "Worrior")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WorriorSpecialSkillPrefab, transform.position, transform.rotation,transform);
                Destroy(SkillInput, 15f);
            }
        }

        // 불법
        if (player.tag == "FireMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(FireMagicianSpecialSkillPrefab, transform.position, transform.rotation);
                Destroy(SkillInput, 15f);
            }
        }

        // 물법
        if (player.tag == "WaterMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WaterMagicianSpecialSkillPrefab, transform.position, transform.rotation);
                SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 2000f);
                Destroy(SkillInput, 15f);
            }
        }

        // 바람법
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
        // 1번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha1) && Skill1Cool == Skill1Time && shopManager.Skill1IsOpen)
        {
            // 군인 
            if (player.tag == "Soldier")
            {
                if (shopManager.SoldierSkill1 == 1)
                {
                    SkillInput = Instantiate(SoldierSkill1Prefab1, transform.position, transform.rotation,transform);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.SoldierSkill1 == 2)
                {
                    SkillInput = Instantiate(SoldierSkill1Prefab2, transform.position, transform.rotation, transform);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.SoldierSkill1 == 3)
                {
                    SkillInput = Instantiate(SoldierSkill1Prefab3, transform.position, transform.rotation,transform);
                    Destroy(SkillInput, Skill1DeleteTime);
                }
                Skill1Time = 0f;
            }

            // 검사
            if (player.tag == "Worrior")
            {
                if (shopManager.WorriorSkill1 == 1)
                {
                    SkillInput = Instantiate(WorriorSkill1Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.WorriorSkill1 == 2)
                {
                    SkillInput = Instantiate(WorriorSkill1Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.WorriorSkill1 == 3)
                {
                    SkillInput = Instantiate(WorriorSkill1Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }
                Skill1Time = 0f;

            }

            // 불법
            if (player.tag == "FireMagician")
            {
                if (shopManager.FireMagicianSkill1 == 1)
                {
                    SkillInput = Instantiate(FireMagicianSkill1Prefab1, transform.position, transform.rotation, transform);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.FireMagicianSkill1 == 2)
                {
                    SkillInput = Instantiate(FireMagicianSkill1Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, 2f);
                }

                if (shopManager.FireMagicianSkill1 == 3)
                {
                    SkillInput = Instantiate(FireMagicianSkill1Prefab3, transform.position, transform.rotation, transform);
                    Destroy(SkillInput, Skill1DeleteTime);
                }
                Skill1Time = 0f;
            }

            // 물법
            if (player.tag == "WaterMagician")
            {
                if (shopManager.WaterMagicianSkill1 == 1)
                {
                    SkillInput = Instantiate(WaterMagicianSkill1Prefab1, transform.position, transform.rotation, transform);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.WaterMagicianSkill1 == 2)
                {
                    SkillInput = Instantiate(WaterMagicianSkill1Prefab2, transform.position, transform.rotation);
                    SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 2000f);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.WaterMagicianSkill1 == 3)
                {
                    SkillInput = Instantiate(WaterMagicianSkill1Prefab3, transform.position, transform.rotation);
                    SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 2000f);
                    Destroy(SkillInput, Skill1DeleteTime);
                }
                Skill1Time = 0f;
            }

            //바람법
            if (player.tag == "WindMagician")
            {
                if (shopManager.WindMagicianSkill1 == 1)
                {
                    SkillInput = Instantiate(WindMagicianSkill1Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.WindMagicianSkill1 == 2)
                {
                    SkillInput = Instantiate(WindMagicianSkill1Prefab2, transform.position, transform.rotation);

                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.WindMagicianSkill1 == 3)
                {
                    SkillInput = Instantiate(WindMagicianSkill1Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }
                Skill1Time = 0f;
            }
        } // 1번 스킬

        // 2번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha2) && Skill2Cool == Skill2Time && shopManager.Skill2IsOpen)
        {
            // 군인
            if (player.tag == "Soldier")
            {
                if (shopManager.SoldierSkill2 == 1)
                {
                    SkillInput = Instantiate(SoldierSkill2Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill2DeleteTime);
                }

                if (shopManager.SoldierSkill2 == 2)
                {
                    SkillInput = Instantiate(SoldierSkill2Prefab2, transform.position, transform.rotation, transform);
                    Destroy(SkillInput, Skill2DeleteTime);
                }

                if (shopManager.SoldierSkill2 == 3)
                {
                    SkillInput = Instantiate(SoldierSkill2Prefab3, skillpos.transform.position, SoldierSkill2Prefab3.transform.rotation,transform);
                    Destroy(SkillInput, Skill2DeleteTime);

                }
                Skill2Time = 0f;
            }

            // 검사
            if (player.tag == "Worrior")
            {
                if (shopManager.WorriorSkill2 == 1)
                {
                    SkillInput = Instantiate(WorriorSkill2Prefab1, skillpos.transform.position, transform.rotation);
                    Destroy(SkillInput, Skill2DeleteTime);
                }

                if (shopManager.WorriorSkill2 == 2)
                {
                    SkillInput = Instantiate(WorriorSkill2Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill2DeleteTime);
                }

                if (shopManager.WorriorSkill2 == 3)
                {
                    SkillInput = Instantiate(WorriorSkill2Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill2DeleteTime);
                }
                Skill2Time = 0f;
            }

            // 불법
            if (player.tag == "FireMagician")
            {
                if (shopManager.FireMagicianSkill2 == 1)
                {
                    SkillInput = Instantiate(FireMagicianSkill2Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.FireMagicianSkill2 == 2)
                {
                    SkillInput = Instantiate(FireMagicianSkill2Prefab2, transform.position, transform.rotation);

                    Destroy(SkillInput, 2f);
                }

                if (shopManager.FireMagicianSkill2 == 3)
                {
                    SkillInput = Instantiate(FireMagicianSkill2Prefab3, transform.position, transform.rotation);
                    SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                    Destroy(SkillInput, Skill1DeleteTime);
                }
                Skill2Time = 0f;
            }

            // 물법
            if (player.tag == "WaterMagician")
            {
                if (shopManager.WaterMagicianSkill2 == 1)
                {
                    SkillInput = Instantiate(WaterMagicianSkill2Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill2DeleteTime);
                }

                if (shopManager.WaterMagicianSkill2 == 2)
                {
                    SkillInput = Instantiate(WaterMagicianSkill2Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill2DeleteTime);
                }

                if (shopManager.WaterMagicianSkill2 == 3)
                {
                    SkillInput = Instantiate(WaterMagicianSkill2Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, 9.5f);
                }
                Skill2Time = 0f;
            }

            // 바람법
            if (player.tag == "WindMagician")
            {
                if (shopManager.WindMagicianSkill2 == 1)
                {
                    SkillInput = Instantiate(WindMagicianSkill2Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.WindMagicianSkill2 == 2)
                {
                    SkillInput = Instantiate(WindMagicianSkill2Prefab2, transform.position, transform.rotation);

                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.WindMagicianSkill2 == 3)
                {
                    SkillInput = Instantiate(WindMagicianSkill2Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }
                Skill2Time = 0f;
            }
        }// 2번 스킬

        // 3번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha3) && Skill3Cool == Skill3Time && shopManager.Skill3IsOpen)
        {
            // 군인
            if (player.tag == "Soldier")
            {
                if (shopManager.SoldierSkill3 == 1)
                {
                    SkillInput = Instantiate(SoldierSkill3Prefab1, transform.position, transform.rotation);
                    SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 100f);
                    Destroy(SkillInput, Skill3DeleteTime);

                }

                if (shopManager.SoldierSkill3 == 2)
                {
                    SkillInput = Instantiate(SoldierSkill3Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill3DeleteTime);
                }

                if (shopManager.SoldierSkill3 == 3)
                {
                    SkillInput = Instantiate(SoldierSkill3Prefab3, transform.position, transform.rotation);
                    SkillInput.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                    Destroy(SkillInput, Skill3DeleteTime);
                }
                Skill3Time = 0f;
            }

            // 검사
            if (player.tag == "Worrior")
            {
                if (shopManager.WorriorSkill3 == 1)
                {
                    SkillInput = Instantiate(WorriorSkill3Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill3DeleteTime);
                }

                if (shopManager.WorriorSkill3 == 2)
                {
                    SkillInput = Instantiate(WorriorSkill3Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, 1f);
                }

                if (shopManager.WorriorSkill3 == 3)
                {
                    SkillInput = Instantiate(WorriorSkill3Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, 1.2f);
                }
                Skill3Time = 0f;
            }

            // 불법
            if (player.tag == "FireMagician")
            {
                if (shopManager.FireMagicianSkill3 == 1)
                {
                    SkillInput = Instantiate(FireMagicianSkill3Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }

                if (shopManager.FireMagicianSkill3 == 2)
                {
                    SkillInput = Instantiate(FireMagicianSkill3Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, 1f);
                }

                if (shopManager.FireMagicianSkill3 == 3)
                {
                    SkillInput = Instantiate(FireMagicianSkill3Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill1DeleteTime);
                }
                Skill3Time = 0f;
            }

            // 물법
            if (player.tag == "WaterMagician")
            {
                if (shopManager.WaterMagicianSkill3 == 1)
                {
                    SkillInput = Instantiate(WaterMagicianSkill3Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill3DeleteTime);
                }

                if (shopManager.WaterMagicianSkill3 == 2)
                {
                    SkillInput = Instantiate(WaterMagicianSkill3Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill3DeleteTime);
                }

                if (shopManager.WaterMagicianSkill3 == 3)
                {
                    SkillInput = Instantiate(WaterMagicianSkill3Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill3DeleteTime);
                }

                Skill3Time = 0f;
            }

            // 바람법
            if (player.tag == "WindMagician")
            {
                if (shopManager.WindMagicianSkill3 == 1)
                {
                    SkillInput = Instantiate(WindMagicianSkill3Prefab1, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill3DeleteTime);
                }

                if (shopManager.WindMagicianSkill3 == 2)
                {
                    SkillInput = Instantiate(WindMagicianSkill3Prefab2, transform.position, transform.rotation);
                    Destroy(SkillInput, 1f);
                }

                if (shopManager.WindMagicianSkill3 == 3)
                {
                    SkillInput = Instantiate(WindMagicianSkill3Prefab3, transform.position, transform.rotation);
                    Destroy(SkillInput, Skill3DeleteTime);
                }
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

        if (Skill1Time <= Skill1Cool)
        {
            Skill1Time += Time.deltaTime;

        }

        if (Skill1Time >= Skill1Cool)
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
