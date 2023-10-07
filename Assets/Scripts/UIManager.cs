using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Player player;
    public GameObject ShopUI;
    bool shopopen;
    public Text goldText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && shopopen == false)
        {
            Time.timeScale = 0;
            ShopUI.SetActive(true);
            shopopen = true;
        }

        else if(Input.GetKeyDown(KeyCode.Escape)&&shopopen==true)
        {
            Time.timeScale = 1;
            ShopUI.SetActive(false);
            shopopen = false;
        }

        printGold();
    }

    void printGold()
    {
        int gold = player.gold;

        goldText.text = "°ñµå : "+gold.ToString();
    }
}
