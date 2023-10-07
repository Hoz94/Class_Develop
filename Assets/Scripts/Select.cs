using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject player;
    public Canvas thirdcanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoldierSelect()
    {
        player.tag = "Soldier";
        Status stat = player.GetComponent<Status>();
        StatusManager._instance.Soldier(stat);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void WorriorSelect()
    {
        player.tag ="Worrior";
        Status stat = player.GetComponent<Status>();
        StatusManager._instance.Worrior(stat);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void ElementsSelect()
    {
        this.gameObject.SetActive(false);
        thirdcanvas.gameObject.SetActive(true);

    }
}
