using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements_Select : MonoBehaviour
{

    Player pr;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireClass()
    {
        player.tag = "FireMagician";
        Status stat = player.GetComponent<Status>();
        StatusManager._instance.Magician(stat);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;


    }

    public void WaterClass()
    {
        player.tag = "WaterMagician";
        Status stat = player.GetComponent<Status>();
        StatusManager._instance.Magician(stat);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void WindClass()
    {
        player.tag = "WindMagician";
        Status stat = player.GetComponent<Status>();
        StatusManager._instance.Magician(stat);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
