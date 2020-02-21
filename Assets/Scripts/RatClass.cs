using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatClass : MonoBehaviour
{
    // Start is called before the first frame update¨
    //Rebase
    public int currentHealth = 25;
    public Image Healthbar;
    public int damage;
    private float health;
    private Quaternion initialRotation;
    void Start ()
    {
        health = currentHealth;
        Healthbar.fillAmount = health;
        initialRotation = Healthbar.transform.rotation;

    }

    void LateUpdate()
    {
        Healthbar.transform.rotation = initialRotation;
    }

    private void OnCollisionEnter(Collision hit) 
    {

        if (hit.gameObject.name == "TestShot(Clone)")
        {
            currentHealth -= damage;

            Healthbar.fillAmount -= (health - damage) / 100;
            //Healthbar.fillAmount -= currentHealth - damage / 100;

            Debug.Log("Rat took damage for: " + damage);
            if (currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
