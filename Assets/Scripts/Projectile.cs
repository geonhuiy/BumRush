using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 100;
    public int carried_damage;

    private Transform rat;
    private Vector3 target_rat;


    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Rat") != null)
        {
            rat = GameObject.FindGameObjectWithTag("Rat").transform;
            target_rat = new Vector3(rat.position.x, rat.position.y, rat.position.z);
            Debug.Log("Projectile damage: " + carried_damage);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Rat") != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, rat.position, speed * Time.deltaTime);
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
            Debug.Log("rat hit");
            Destroy(this.gameObject);
        }
    }
}
