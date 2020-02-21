using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatClass : MonoBehaviour
{
    // Start is called before the first frame update¨
    public int currentHealth = 25;
    public Image Healthbar;
    public int damage;
    private float health;

    void Start()
    {
        health = currentHealth;
    }

    private void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.name == "TestShot(Clone)")
        {
            currentHealth -= damage;
            Healthbar.fillAmount -= damage / 100;

            Debug.Log("Rat took damage for: " + damage);
            if (currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
