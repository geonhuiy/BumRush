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
        //shotDamage = parentObj.GetComponent<BumClass>().damage;
        shotDamage = 5f;
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
        if (other.gameObject.tag == "Rat") {
            other.gameObject.GetComponent<RatClass>().damage = shotDamage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Shot" || other.gameObject.tag == "Hobo"|| other.gameObject.tag =="Node") {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
        }

    }
}
