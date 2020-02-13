using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatClass : MonoBehaviour
{
    // Start is called before the first frame update¨
    public int HP  = 25;
    public int damage = 5;
    
    private void OnCollisionEnter(Collision hit) 
    {
        if(hit.gameObject.name == "TestShot(Clone)")
        {
            Debug.Log("Rat took damage");
            HP -= damage;
            if(HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
