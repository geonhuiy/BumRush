using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public GameObject targetRat;
    private GameObject[] targets;
    [SerializeField]
    private GameObject projectile;
    private float towerRange = 16f;
    private float towerRatDistance, attackCooldown;
    public float shotSpeed = 50f;

    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Rat");
        targetRat = FindClosestEnemy(targets);

        // targetRat = GameObject.FindGameObjectWithTag("Rat");
        if (targetRat != null)
        {
            towerRatDistance = Vector3.Distance(targetRat.transform.position, this.transform.position);
            if (IsInRange())
            {
                Debug.DrawLine(transform.position, targetRat.transform.position, Color.red);

                AttackRat();
            }
        }
    }

    private bool IsInRange()
    {
        if (towerRatDistance <= towerRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void AttackRat()
    {
        transform.LookAt(targetRat.transform);
        attackCooldown -= Time.deltaTime;
        if (attackCooldown <= 0)
        {
            Debug.Log("Hobo ready");
            GameObject hoboShot = Instantiate(projectile, transform.position + 2 * transform.forward, transform.rotation, transform);
            //hoboShot.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
            attackCooldown = 2;
        }
    }

    /*private void FindNewRat()
    {
        targetRat = null;
        targetRat = GameObject.FindGameObjectWithTag("Rat");
    }*/

    private GameObject FindClosestEnemy(GameObject[] enemies)
    {
        GameObject bestTarget = null;
        float closestDistSqr = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.gameObject.transform.position - currentPos;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistSqr)
            {
                closestDistSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}
