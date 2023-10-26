using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public static Player _instance;
    [SerializeField] Status status;
    float turnSpeed = 50f;
    float xRotation;
    Rigidbody myRigid;
    public long gold;
    public int Addmoney = 0;


    private void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        status = GetComponent<Status>();
        myRigid = GetComponent<Rigidbody>();
        gold = 0;
        Addmoney = 0;
    }

    private void FixedUpdate()
    {
        Move();
        //PhoneMove();
        //PhoneScreenMove();
    }


    private void LateUpdate()
    {
        MouseRotation();
    }
#if UNITY_ANDROID
    void PhoneMove()
    {

    }

    void PhoneScreenMove()
    {

    }

#endif
    // Update is called once per frame
    void Update()
    {
        /*        if(this.gameObject.tag!="Untagged")
                {
                    Cursor.visible = false;
                }*/
        
    }


    void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(Horizontal, 0, Vertical);
        movement = transform.TransformVector(movement).normalized;
        myRigid.velocity = movement * status.Spd;

    }


    void MouseRotation()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), 0);

        xRotation -= (mouseInput.y * Time.fixedDeltaTime) * turnSpeed; // 
        xRotation = Mathf.Clamp(xRotation, 0, 0);
        transform.Rotate(0f, mouseInput.x * Time.fixedDeltaTime * turnSpeed, 0f);
    }

    public void GetGold(long getgold)
    {
        gold += getgold + Addmoney;
    }
}
