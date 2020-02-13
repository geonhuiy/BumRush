using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatClass : MonoBehaviour
{
    // Start is called before the first frame update¨
    int HP  = 25;
    private void OnCollisionEnter(Collision hit) 
    {
        if(hit.gameObject.name == "TestShot(Clone)")
        {
            Debug.Log("Rat took damage");
        }
    }
}
