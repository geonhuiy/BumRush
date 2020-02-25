using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    GameObject parentObj, targetRat;
    void Update()
    {
        if (targetRat != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetRat.transform.position, 50 * Time.deltaTime);
        }
    }

    private void Start()
    {
        parentObj = this.transform.parent.gameObject;
        targetRat = parentObj.GetComponent<TowerShooting>().targetRat;
        StartCoroutine("DestroyProj");
    }

    IEnumerator DestroyProj()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
