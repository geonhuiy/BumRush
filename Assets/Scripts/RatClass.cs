using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatClass : MonoBehaviour
{
    // Start is called before the first frame update¨
    public int currentHealth = 25;
    public Image Healthbar;
    private int damage;
    private float health;

    void Start()
    {
        health = currentHealth;
    }

    private void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.name == "TestShot(Clone)")
        {
            damage = hit.collider.gameObject.GetComponent<Projectile>().carried_damage;

            currentHealth -= damage;
            Healthbar.fillAmount -= damage / 100;

            Debug.Log("Rat took damage for: " + hit.collider.gameObject.GetComponent<Projectile>().carried_damage);
            if (currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
