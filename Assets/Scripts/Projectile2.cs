using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    private GameObject parentObj, targetRat;
    private float shotDamage;
    [SerializeField]
    private float speed = 50;
    [SerializeField]
    private float aoe_rad;
    private bool aoe_on = false;
    private void Start()
    {
        parentObj = this.transform.parent.gameObject;
        targetRat = parentObj.GetComponent<TowerShooting>().targetRat;
        shotDamage = parentObj.GetComponent<BumClass>().damage;
        aoe_on = parentObj.GetComponent<BumClass>().bum_aoe_on;
        if (aoe_on == true)
        {
            aoe_rad = parentObj.GetComponent<BumClass>().bum_aoe_radius;
        }
        //shotDamage = 5f;
        StartCoroutine("DestroyProj");
    }
    void Update()
    {
        if (targetRat != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetRat.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator DestroyProj()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Rat")
        {

            if (aoe_on)
            {
                Debug.Log("Goes to AOE");
                AOEdamage(this.transform.position, aoe_rad);
            }
            else
            {
                Debug.Log("Doesn't go to AOE");
                other.gameObject.SendMessage("applyDMG", shotDamage);
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Shot" || other.gameObject.tag == "Hobo" || other.gameObject.tag == "Node")
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
        }

    }

    //AOE FUNCTION
    void AOEdamage(Vector3 center, float rad)
    {
        Collider[] targets_hit = Physics.OverlapSphere(center, rad);
        int i = 0;
        foreach (Collider col in targets_hit)
        {
            if (col.gameObject.tag == "Rat" || col.gameObject.tag == "Hobo")
            {
                col.SendMessage("applyDMG", shotDamage); //ASSIGN DAMAGE TO EACH RAT IN THE RADIUS
                ++i;
            }

        }
        Debug.Log("AOE hit: " + i);
    }
}
