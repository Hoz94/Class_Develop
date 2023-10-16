using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (player.tag == "Soldier")
        {
            transform.Translate(Vector3.forward * 40 * Time.deltaTime);
        }

        if (player.tag == "Worrior")
        {
            transform.Translate(Vector3.forward * 20 * Time.deltaTime);
        }

        if (player.tag == "FireMagician" || player.tag == "WaterMagician" || player.tag == "WindMagician")
        {
            transform.Translate(Vector3.forward * 8 * Time.deltaTime);

        }
    }

    private void OnDisable()
    {
        transform.position = Vector3.zero; //
        transform.rotation = Quaternion.identity;
        rb.Sleep();//

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnHit();
            }


            this.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            Boss boss = other.gameObject.GetComponent<Boss>();
            if (boss != null)
            {
                boss.OnHit();
            }

            this.gameObject.SetActive(false);
        }

    }

}