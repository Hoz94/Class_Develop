using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditorInternal;
using UnityEngine;

public struct playerstats
{
    int Atk;
    float Spd;
    int CurHp;
    int MaxHp;
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
        status.CurHp = 100;
        status.MaxHp = 100;
        status.Spd = 6f;
    }

    public void Worrior(Status status) 
    {
        status.Atk = 20;
        status.CurHp = 90;
        status.MaxHp = 90;
        status.Spd = 5f;
    }

    public void Magician(Status status) 
    {
        status.Atk = 50;
        status.CurHp = 60;
        status.MaxHp = 60;
        status.Spd = 4f;
    }
}
