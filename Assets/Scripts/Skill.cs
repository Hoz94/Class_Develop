using UnityEngine;

public class Skill : MonoBehaviour
{
    public ShopManager shopManager;
    Player player;
    public Transform skillpos; // ��ų�� ������ ��ġ
    public GameObject SkillInput; // �ν��Ͻ��Ѱ��� �����ϴ� ������Ʈ

    [Header("�� ������ �ʻ�� ������")]
    public GameObject SoldierSpecialSkillPrefab;
    public GameObject WorriorSpecialSkillPrefab;
    public GameObject FireMagicianSpecialSkillPrefab;
    public GameObject WaterMagicianSpecialSkillPrefab;
    public GameObject WindMagicianSpecialSkillPrefab;
    [Header("���� 1�� ��Ƽ�꽺ų ������")]
    public GameObject SoldierSkill1Prefab1;
    public GameObject SoldierSkill1Prefab2;
    public GameObject SoldierSkill1Prefab3;
    [Header("���� 2�� ��Ƽ�꽺ų ������")]
    public GameObject SoldierSkill2Prefab1;
    public GameObject SoldierSkill2Prefab2;
    public GameObject SoldierSkill2Prefab3;
    [Header("���� 3�� ��Ƽ�꽺ų ������")]
    public GameObject SoldierSkill3Prefab1;
    public GameObject SoldierSkill3Prefab2;
    public GameObject SoldierSkill3Prefab3;
    [Header("�˻� 1�� ��Ƽ�꽺ų ������")]
    public GameObject WorriorSkill1Prefab1;
    public GameObject WorriorSkill1Prefab2;
    public GameObject WorriorSkill1Prefab3;
    [Header("�˻� 2�� ��Ƽ�꽺ų ������")]
    public GameObject WorriorSkill2Prefab1;
    public GameObject WorriorSkill2Prefab2;
    public GameObject WorriorSkill2Prefab3;
    [Header("�˻� 3�� ��Ƽ�꽺ų ������")]
    public GameObject WorriorSkill3Prefab1;
    public GameObject WorriorSkill3Prefab2;
    public GameObject WorriorSkill3Prefab3;
    [Header("�ҹ��� 1�� ��Ƽ�꽺ų ������")]
    public GameObject FireMagicianSkill1Prefab1;
    public GameObject FireMagicianSkill1Prefab2;
    public GameObject FireMagicianSkill1Prefab3;
    [Header("�ҹ��� 2�� ��Ƽ�꽺ų ������")]
    public GameObject FireMagicianSkill2Prefab1;
    public GameObject FireMagicianSkill2Prefab2;
    public GameObject FireMagicianSkill2Prefab3;
    [Header("�ҹ��� 3�� ��Ƽ�꽺ų ������")]
    public GameObject FireMagicianSkill3Prefab1;
    public GameObject FireMagicianSkill3Prefab2;
    public GameObject FireMagicianSkill3Prefab3;
    [Header("������ 1�� ��Ƽ�꽺ų ������")]
    public GameObject WaterMagicianSkill1Prefab1;
    public GameObject WaterMagicianSkill1Prefab2;
    public GameObject WaterMagicianSkill1Prefab3;
    [Header("������ 2�� ��Ƽ�꽺ų ������")]
    public GameObject WaterMagicianSkill2Prefab1;
    public GameObject WaterMagicianSkill2Prefab2;
    public GameObject WaterMagicianSkill2Prefab3;
    [Header("������ 3�� ��Ƽ�꽺ų ������")]
    public GameObject WaterMagicianSkill3Prefab1;
    public GameObject WaterMagicianSkill3Prefab2;
    public GameObject WaterMagicianSkill3Prefab3;
    [Header("�ٶ����� 1�� ��Ƽ�꽺ų ������")]
    public GameObject WindMagicianSkill1Prefab1;
    public GameObject WindMagicianSkill1Prefab2;
    public GameObject WindMagicianSkill1Prefab3;
    [Header("�ٶ����� 2�� ��Ƽ�꽺ų ������")]
    public GameObject WindMagicianSkill2Prefab1;
    public GameObject WindMagicianSkill2Prefab2;
    public GameObject WindMagicianSkill2Prefab3;
    [Header("�ٶ����� 3�� ��Ƽ�꽺ų ������")]
    public GameObject WindMagicianSkill3Prefab1;
    public GameObject WindMagicianSkill3Prefab2;
    public GameObject WindMagicianSkill3Prefab3;

    [Header("��ų ��Ÿ��")]
    public float SpecialSkillCool = 30f; // �ʻ�� ��Ÿ��
    public float SpecialSkillTime = 30f;
    public float Skill1Cool = 5f; // 1����ų ��Ÿ��
    public float Skill2Cool = 10f; // 2����ų ��Ÿ��
    public float Skill3Cool = 15f; // 3����ų ��Ÿ��
    public float Skill1Time = 5f;
    public float Skill2Time = 10f;
    public float Skill3Time = 15f;

    [Header("1,2,3���� �� ��������")]
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
            SpecialSkill(); // �ʻ�� (Q�� ���)
        }

        ActiveSkill(); // �Ϲ� ��ų ��� (1, 2, 3��)

        SkillCoolTime(); // ��Ÿ�� ���� �޼���


    }

    void SpecialSkill() // �� ������ �ʻ��
    {
        // ����
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

        // �˻�
        if (player.tag == "Worrior")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(WorriorSpecialSkillPrefab, transform.position, transform.rotation,transform);
                Destroy(SkillInput, 15f);
            }
        }

        // �ҹ�
        if (player.tag == "FireMagician")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpecialSkillTime = 0f;
                SkillInput = Instantiate(FireMagicianSpecialSkillPrefab, transform.position, transform.rotation);
                Destroy(SkillInput, 15f);
            }
        }

        // ����
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

        // �ٶ���
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
        // 1�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha1) && Skill1Cool == Skill1Time && shopManager.Skill1IsOpen)
        {
            // ���� 
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

            // �˻�
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

            // �ҹ�
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

            // ����
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

            //�ٶ���
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
        } // 1�� ��ų

        // 2�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha2) && Skill2Cool == Skill2Time && shopManager.Skill2IsOpen)
        {
            // ����
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

            // �˻�
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

            // �ҹ�
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

            // ����
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

            // �ٶ���
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
        }// 2�� ��ų

        // 3�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha3) && Skill3Cool == Skill3Time && shopManager.Skill3IsOpen)
        {
            // ����
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

            // �˻�
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

            // �ҹ�
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

            // ����
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

            // �ٶ���
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


    void SkillCoolTime() // ��ų ��Ÿ��
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
