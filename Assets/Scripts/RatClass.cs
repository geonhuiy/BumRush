using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatClass : MonoBehaviour
{
    // Start is called before the first frame update¨
    public int HP = 25;
    public int damage = 5;

    Projectile proj;

    private void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.name == "TestShot(Clone)")
        {
            HP -= hit.collider.gameObject.GetComponent<Projectile>().carried_damage;
            Debug.Log("Rat took damage for: " + hit.collider.gameObject.GetComponent<Projectile>().carried_damage);
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
