using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    GameObject player;
    public Transform firepos;
    float CurrentDealy = 0f;

    //군인 기본공격 딜레이
    float MaxDelay = 0.2f;

    //마법사 기본공격 딜레이
    float BoltDelay = 1f;

    //검사 기본공격 딜레이
    float SwordDelay = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        CurrentDealy += Time.deltaTime;
        Attack();
    }


    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            if (player.tag == "Soldier")
            {
                if (CurrentDealy >= MaxDelay)
                {
                    var _bullet = PoolingManager._instance.GetBullet();
                    if (_bullet != null)
                    {

                        _bullet.transform.position = firepos.position;
                        _bullet.transform.rotation = firepos.rotation;
                        _bullet.SetActive(true);
                        CurrentDealy = 0f;
                    }

                }
            }

            if (player.tag == "Worrior")
            {
                if (CurrentDealy >= SwordDelay)
                {
                    var Sword = PoolingManager._instance.GetSword();
                    if (Sword != null)
                    {
                        Sword.transform.position = firepos.position;
                        Sword.transform.rotation = firepos.rotation;
                        Sword.SetActive(true);

                        CurrentDealy = 0f;
                    }

                }
            }

            if (player.tag == "FireMagician" || player.tag == "WaterMagician" || player.tag == "WindMagician")
            {
                if (CurrentDealy >= BoltDelay)
                {
                    var _energybolt = PoolingManager._instance.GetEnergyBolt();
                    if (_energybolt != null)
                    {
                        _energybolt.transform.position = firepos.position;
                        _energybolt.transform.rotation = firepos.rotation;
                        _energybolt.SetActive(true);

                        CurrentDealy = 0f;
                    }
                }
            }

        }
    }

}
