using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public GameObject targetRat;
    public GameObject targetHobo = null, nearestHobo;
    private GameObject[] rat_targets, hobo_targets;
    [SerializeField]
    private GameObject projectile;
    private float towerRange = 16f;
    private float hoboRange;
    private float towerRatDistance, towerHoboDistance, attackCooldown, stabCooldown, fireRate, stabRate = 1.5f;
    private Transform other_hobo;
    public float shotSpeed = 50f;
    public bool hostile;
    public float hostility_range = 5.7f;

    private void Start()
    {
        fireRate = gameObject.GetComponent<BumClass>().fire_rate;
        hostile = gameObject.GetComponent<BumClass>().hostile_on;
    }
    void Update()
    {
        rat_targets = GameObject.FindGameObjectsWithTag("Rat");
        targetRat = FindClosestEnemy(rat_targets);
        
        //ATTACKING OTHER HOBOS
        if (hostile) 
        {   
            this.gameObject.tag = "this hobo";
            hobo_targets = GameObject.FindGameObjectsWithTag("Hobo");
            targetHobo = FindAdjacentHobo(hobo_targets);
            if (targetHobo != null)
            {
                towerHoboDistance = Vector3.Distance(targetHobo.transform.position, this.transform.position);
                Debug.Log("Distance to nearest hobo: " + towerHoboDistance);
                if (IsInRange(towerHoboDistance, hostility_range))
                {
                    FindAdjacentHobo(hobo_targets);
                }
            }
            AttackHobo();
            this.gameObject.tag = "Hobo";
        }

        //ATTACKING RATS
        if (targetRat != null) 
        {
            towerRatDistance = Vector3.Distance(targetRat.transform.position, this.transform.position);
            if (IsInRange(towerRatDistance, towerRange))
            {
                Debug.DrawLine(transform.position, targetRat.transform.position, Color.red);

                AttackRat();
            }
        }
    }

    //CHECKS WHETHER TARGET IS IN RANGE
    private bool IsInRange(float targetDistance, float range)
    {
        if (targetDistance <= range)
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
            GameObject hoboShot = Instantiate(projectile, transform.position + 2 * transform.forward, transform.rotation, transform);
            attackCooldown = fireRate;
        }
    }
    private void AttackHobo()
    {
        if (targetHobo != null)
        {
            stabCooldown -= Time.deltaTime;
            if (stabCooldown <= 0)
            {
                targetHobo.SendMessage("applyDMG", 1);
                stabCooldown = stabRate;
            }
        }

    }

    private GameObject FindAdjacentHobo(GameObject[] hobos)
    {

        nearestHobo = null;
        float closestDistSqr = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject potentialTarget in hobos)
        {
            Vector3 directionToTarget = potentialTarget.gameObject.transform.position - currentPos;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistSqr)
            {
                closestDistSqr = dSqrToTarget;
                nearestHobo = potentialTarget;
            }
        }
        return nearestHobo;
    }
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
