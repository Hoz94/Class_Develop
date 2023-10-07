using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    public Canvas Selectcanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GameStart()
    {
        this.gameObject.SetActive(false);
        Selectcanvas.gameObject.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
