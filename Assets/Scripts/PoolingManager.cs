using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.AI;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager _instance;

    [Header("일반몹 오브젝트풀링")]
    public List<GameObject> Enemypool = new List<GameObject>();
    public GameObject EnemyPrefab;
    int MaxEnemies = 500;

    [Header("총알 오브젝트풀링")]
    public List<GameObject> BulletPool = new List<GameObject>();
    public GameObject BulletPrefab;
    int MaxBull = 20;

    [Header("에너지볼트 오브젝트풀링")]
    public List<GameObject> EnergyBoltPool = new List<GameObject>();
    public GameObject EnergyBoltPrefab;
    int MaxBolt = 20;

    [Header("투척검 오브젝트풀링")]
    public List<GameObject> SwordPool = new List<GameObject>();
    public GameObject SwordPrefab;
    int MaxSword = 20;


    public int AddHp=0;
    public float AddSpeed = 0f;
    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        BulletPooling();
        EnergyBoltPooling();
        SwordPooling();
        EnemyPooling();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void SwordPooling()
    {
        GameObject SwordPools = new GameObject("SwordPools");

        for (int i = 0; i < MaxSword; i++)
        {
            var obj = Instantiate(SwordPrefab, SwordPools.transform);
            obj.name = "Sword_" + i.ToString("00");
            obj.SetActive(false);
            SwordPool.Add(obj);
        }
    }

    public void BulletPooling()
    {
        GameObject BulletPools = new GameObject("BulletPools");

        for(int i=0; i<MaxBull; i++)
        {
            var obj = Instantiate(BulletPrefab, BulletPools.transform);
            obj.name = "Bullet_" + i.ToString("00");
            obj.SetActive(false);
            BulletPool.Add(obj);
        }
    }

    public void EnergyBoltPooling()
    {
        GameObject EnergyBoltPools = new GameObject("EnergyBoltPools");

        for (int i = 0; i < MaxBolt; i++)
        {
            var obj = Instantiate(EnergyBoltPrefab, EnergyBoltPools.transform);
            obj.name = "EnergyBolt_" + i.ToString("00");
            obj.SetActive(false);
            EnergyBoltPool.Add(obj);
        }
    }

    public void EnemyPooling()
    {
        GameObject Enemypools = new GameObject("EnemyPools");
        
        for (int i=0; i< MaxEnemies; i++) 
        {
            var obj = Instantiate(EnemyPrefab, Enemypools.transform);
            obj.name = "Enemy_" + i.ToString("00");
            obj.SetActive(false);
            Enemypool.Add(obj);
        }
    }

    public GameObject GetEnemies()
    {
        for (int i=0; i<Enemypool.Count;i++)
        {
            if (Enemypool[i].activeSelf==false)
            {
                Enemy enemy = Enemypool[i].GetComponent<Enemy>();
                if(enemy != null)
                {
                    enemy.SetHealth(AddHp);
                    enemy.SetSpeed(AddSpeed);
                }
                return Enemypool[i];
            }
        }
        return null;
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < BulletPool.Count; i++)
        {
            if (BulletPool[i].activeSelf == false)
            {
                return BulletPool[i];
            }
        }
        return null;
    }

    public GameObject GetSword()
    {
        for (int i = 0; i < SwordPool.Count; i++)
        {
            if (SwordPool[i].activeSelf == false)
            {
                return SwordPool[i];
            }
        }
        return null;
    }

    public GameObject GetEnergyBolt()
    {
        for (int i = 0; i < EnergyBoltPool.Count; i++)
        {
            if (EnergyBoltPool[i].activeSelf == false)
            {
                return EnergyBoltPool[i];
            }
        }
        return null;
    }
}