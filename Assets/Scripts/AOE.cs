using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    // Start is called before the first frame update
    void AOEdamage(Vector3 center, float rad, float dmg) //AOE FUNCTION
    {
        Collider[] rats_hit  = Physics.OverlapSphere(center, rad);
        int i = 0;
        while(i < rats_hit.Length)
        {
            rats_hit[i].gameObject.GetComponent<RatClass>().currentHealth  -= dmg; //ASSIGN DAMAGE TO EACH RAT IN THE RADIUS
            Debug.Log("AOE");
        }
    }
}
