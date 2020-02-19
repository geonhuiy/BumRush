using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatClass : MonoBehaviour
{
    // Start is called before the first frame update¨
    public int currentHealth  = 25;
    public int damage = 5;
    public Image Healthbar;

    private float health;

    void Start ()
    {
        health = currentHealth;
        Healthbar.fillAmount = 1;
    }
    
    private void OnCollisionEnter(Collision hit) 
    {
        if(hit.gameObject.name == "TestShot(Clone)")
        {
            Debug.Log("Rat took damage");
            currentHealth -= damage;
            Debug.Log(currentHealth);

            //Healthbar.fillAmount -= currentHealth / 100;
            Healthbar.fillAmount -= damage / 100;

            if(currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
