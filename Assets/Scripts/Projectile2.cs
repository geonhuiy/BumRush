using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    private GameObject parentObj, targetRat;
    private float shotDamage;
    [SerializeField]
    private float speed = 50;
    private void Start()
    {
        parentObj = this.transform.parent.gameObject;
        targetRat = parentObj.GetComponent<TowerShooting>().targetRat;
        shotDamage = parentObj.GetComponent<BumClass>().damage;
        //shotDamage = 5f;
        StartCoroutine("DestroyProj");
    }
    void Update()
    {
        if (targetRat != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetRat.transform.position, speed * Time.deltaTime);
        }
        else {
            Destroy(this.gameObject);
        }
    }
    IEnumerator DestroyProj()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Rat" && parentObj.GetComponent<BumClass>().bum_aoe_on == true)
        {
            AOEdamage(this.transform.position, 1000);
        }
        else if (other.gameObject.tag == "Rat") {
            other.gameObject.GetComponent<RatClass>().damage = shotDamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Shot" || other.gameObject.tag == "Hobo"|| other.gameObject.tag =="Node") {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
        }

    }

    
    void AOEdamage(Vector3 center, float rad) //AOE FUNCTION
    {
        Collider[] rats_hit  = Physics.OverlapSphere(center, rad);
        int i = 0;
        while(i < rats_hit.Length)
        {
            rats_hit[i].gameObject.GetComponent<RatClass>().currentHealth  -= shotDamage; //ASSIGN DAMAGE TO EACH RAT IN THE RADIUS
            Debug.Log("AOE");
        }
    }
}
