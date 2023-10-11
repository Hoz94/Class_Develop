using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy=other.gameObject.GetComponent<Enemy>();
            enemy.OnHit(50);
        }
    }

}
