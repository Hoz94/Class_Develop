using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Player pr;


    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        pr = GetComponent<Player>();
        Time.timeScale = 0;
        player.tag = "Untagged";
    }



    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale < 1)
        {
            Cursor.visible = true;
        }
        else if (Time.timeScale == 1)
        {
            Cursor.visible = false;
        }
    }
}
