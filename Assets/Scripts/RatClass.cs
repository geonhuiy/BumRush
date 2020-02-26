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
    void Start()
    {
        currentHealth = maxHealth;
        initialRotation = Healthbar.transform.rotation;
    }

    void LateUpdate()
    {
        Healthbar.transform.rotation = initialRotation;
    }

    public void applyDMG(float d)
    {
        currentHealth -= d;
        Debug.Log("Current health : " + currentHealth + " Damage taken : " + damage);
        Healthbar.fillAmount = (currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
