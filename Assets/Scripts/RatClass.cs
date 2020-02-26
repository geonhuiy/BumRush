using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatClass : MonoBehaviour
{
    public float currentHealth;
    private float maxHealth = 30;
    public Image Healthbar;
    public float damage;
    private Quaternion initialRotation;
    PoolObject po;
    
    
    void Start ()
    {
        currentHealth = maxHealth;
        initialRotation = Healthbar.transform.rotation;
        
    }

    void LateUpdate()
    {
        Healthbar.transform.rotation = initialRotation;
    }

    private void OnCollisionEnter(Collision hit) 
    {

        if (hit.gameObject.name == "TestShot(Clone)")
        //if (hit.gameObject.CompareTag("Rat"))
        {
            currentHealth -= damage;
            Debug.Log("Current health : " + currentHealth + " Damage taken : " + damage);
            Healthbar.fillAmount = (currentHealth/maxHealth);
            if (currentHealth <= 0)
            {
                
                Destroy(this.gameObject);
            }
        }
    }
}
