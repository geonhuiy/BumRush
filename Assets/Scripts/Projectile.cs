using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 100;

    private Transform rat;
    private Vector3 target_rat;
    void Start()
    {
        rat = GameObject.FindGameObjectWithTag("Rat").transform;
        target_rat = new Vector3(rat.position.x, rat.position.y, rat.position.z);
        
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, rat.position, speed*Time.deltaTime);
        
    }
    
    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.name == "rat")
        {
            Debug.Log("rat hit");
            Destroy(this.gameObject);
        }    
    }
}
