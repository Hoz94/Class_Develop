using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public struct playerstats
{
    int Atk;
    float Spd;
    float CurHp;
    float MaxHp;
};

public class StatusManager : MonoBehaviour
{
    public static StatusManager _instance;

    playerstats stats;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Soldier(Status status)
    {
        status.Atk = 10;
        status.CurHp = 100f;
        status.MaxHp = 100f;
        status.Spd = 6f;
    }

    public void Worrior(Status status) 
    {
        status.Atk = 20;
        status.CurHp = 90f;
        status.MaxHp = 90f;
        status.Spd = 5f;
    }

    public void Magician(Status status) 
    {
        status.Atk = 50;
        status.CurHp = 60f;
        status.MaxHp = 60f;
        status.Spd = 4f;
    }
}
