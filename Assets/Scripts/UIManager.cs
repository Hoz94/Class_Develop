using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Player player;
    public Text goldText;
    public Slider HPslider;
    public Canvas PlayerUICanvas;

    // Start is called before the first frame update
    void Start()
    {
        HPslider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        printGold();

        if (Time.timeScale == 1)
        {
            PlayerUICanvas.gameObject.SetActive(true);
            HandleHP();
        }
    }



    void printGold()
    {
        int gold = player.gold;

        goldText.text = "°ñµå : "+gold.ToString();
    }

    void HandleHP()
    {
        Status status=player.gameObject.GetComponent<Status>();
        HPslider.value = status.CurHp / status.MaxHp;

    }
}
