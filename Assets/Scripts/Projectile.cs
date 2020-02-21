using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 100;
    public float carried_damage;
    private Transform rat;
    private Vector3 target_rat;

    //VARIABLES FOR AOE (WILDCARDS)
    public bool aoe = false;
    public float aoe_radius = 1f;




    void Start()
    {
        rat = GameObject.FindGameObjectWithTag("Rat").transform;
        target_rat = new Vector3(rat.position.x, rat.position.y, rat.position.z);
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
            target.gameObject.GetComponent<RatClass>().damage = carried_damage;
            Debug.Log("rat hit");
            Destroy(this.gameObject);
        }
    }

    void AOEdamage(Vector3 center, float rad)
    {
        Collider[] rats_hit  = Physics.OverlapSphere(center, rad);
        int i = 0;
        while(i < rats_hit.Length)
        {
            
        }
    }
}
