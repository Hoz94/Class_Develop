using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        status = GetComponent<Status>();
        myRigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        MouseRotation();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag!="Untagged")
        {
/*            Cursor.visible = false;*/
/*            Cursor.lockState = CursorLockMode.Locked;*/
            Cursor.visible = true;
        }
        Move();
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
        xRotation = Mathf.Clamp(xRotation,0,0);
        transform.Rotate(0f, mouseInput.x * Time.fixedDeltaTime * turnSpeed, 0f);
    }

    public void GetGold(long getgold)
    {
        gold += getgold+Addmoney;
    }
}
