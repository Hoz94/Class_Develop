using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellFire : MonoBehaviour
{
    SkillDamage SD;
    public GameObject parentsSkills;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (parentsSkills == null)
        {
            parentsSkills = transform.parent.transform.parent.transform.parent.gameObject;
        }

        if (SD == null && parentsSkills != null)
        {
            SD = parentsSkills.GetComponent<SkillDamage>();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        StartCoroutine(Timeco(enemy));

        /*if (enemy != null) 
        {
            *//*if (SD == null)
            {
                SD = parentsSkills.GetComponent<SkillDamage>();
            }*//*
            enemy.OnHit(SD.SpecialSkillDamage);
        }*/
    }

    IEnumerator Timeco(Enemy enemy)
    {
        yield return new WaitForSeconds(0.1f);
        if (enemy != null)
        {
            /*if (SD == null)
            {
                SD = parentsSkills.GetComponent<SkillDamage>();
            }*/
            enemy.OnHit(SD.SpecialSkillDamage);
        }
    }
}
