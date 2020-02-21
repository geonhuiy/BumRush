﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatClass : MonoBehaviour
{
    // Start is called before the first frame update¨
    public int currentHealth  = 25;
    public int damage = 5;
    public Image Healthbar;
    private Quaternion initialRotation;
    private float health;

    void Awake()
    {
    }

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

            //HP -= hit.collider.gameObject.GetComponent<Projectile>().carried_damage;
            //Debug.Log("Rat took damage for: " + hit.collider.gameObject.GetComponent<Projectile>().carried_damage);

            Debug.Log("Rat took damage");
            currentHealth -= damage;
            Debug.Log(currentHealth);


            Healthbar.fillAmount -= (health - damage) / 100;
            //Healthbar.fillAmount -= currentHealth - damage / 100;

            if(currentHealth <= 0)

            /*HP -= hit.collider.gameObject.GetComponent<Projectile>().carried_damage;
            Debug.Log("Rat took damage for: " + hit.collider.gameObject.GetComponent<Projectile>().carried_damage);*/
            {
                Destroy(this.gameObject);
            }
        }
    }
}
