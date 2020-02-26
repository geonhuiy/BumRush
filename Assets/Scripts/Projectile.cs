﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 100;
    public float carried_damage;
    private Transform rat;
    private Vector3 target_rat;

    //VARIABLES FOR AOE (WILDCARDS)
    public float aoe_radius = 1f;




    void Start()
    {
        rat = GameObject.FindGameObjectWithTag("Rat").transform;
        target_rat = new Vector3(rat.position.x, rat.position.y, rat.position.z);
        if(transform.parent.GetComponent<BumClass>().bum_aoe_on == true)
        {
            aoe_radius = transform.parent.GetComponent<BumClass>().bum_aoe_radius; 
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Rat") != null)
        {
           
            Debug.Log("Projectile damage: " + carried_damage);
            transform.position = Vector3.MoveTowards(transform.position, target_rat, speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Rat")
        {
            if(transform.parent.GetComponent<BumClass>().bum_aoe_on == false)
            {
                target.gameObject.GetComponent<RatClass>().damage = carried_damage;
            }
            else
            {

                AOEdamage(this.transform.position, aoe_radius);
            }
            
            Debug.Log("rat hit");
            Destroy(this.gameObject);
        }
        if(target.gameObject.tag == "Shot") //MAKE THE SHOTS NOT COLLIDE WITH EACH OTHER
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(),target.collider,true);
        }
    }

    void AOEdamage(Vector3 center, float rad) //AOE FUNCTION
    {
        Collider[] rats_hit  = Physics.OverlapSphere(center, rad);
        int i = 0;
        while(i < rats_hit.Length)
        {
               rats_hit[i].gameObject.GetComponent<RatClass>().damage = carried_damage; //ASSIGN DAMAGE TO EACH RAT IN THE RADIUS
        }
    }
}
