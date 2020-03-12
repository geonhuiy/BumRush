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
    private float dmg, towerRatDistance, towerHoboDistance, attackCooldown, stabCooldown, eatCooldown, fireRate, eatRate = 0.5f, stabRate = 1.5f;
    private Transform other_hobo;
    public float shotSpeed = 50f;
    public bool hostile;
    public bool starving;
    private bool gotRat = false;
    public float hostility_range = 5.7f;
    public float eating_range = 9f;
    private float flashTimer = 0.2f;

    private void Start()
    {
        fireRate = gameObject.GetComponent<BumClass>().fire_rate;
        hostile = gameObject.GetComponent<BumClass>().hostile_on;
        starving = gameObject.GetComponent<BumClass>().starving_on;
        dmg = gameObject.GetComponent<BumClass>().damage;
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
                if (IsInRange(towerHoboDistance, hostility_range))
                {
                    FindAdjacentHobo(hobo_targets);
                    AttackHobo();
                }
            }

            this.gameObject.tag = "Hobo";
        }

        if (starving)
        {
            if (targetRat != null) {
                towerRatDistance = Vector3.Distance(targetRat.transform.position, this.transform.position);
                if (IsInRange(towerRatDistance, eating_range))
                {
                    Debug.DrawLine(transform.position, targetRat.transform.position, Color.red);
                    eatRat();
                }
            }

        }
        //ATTACKING RATS
        if (targetRat != null && !starving && !targetRat.GetComponent<RatClass>().grabbed)
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
                targetHobo.SendMessage("applyDMG", dmg);
                stabCooldown = stabRate;
            }
        }
    }

    //FUNCTION FOR "GRABBING" RAT AND EATING IT
    void eatRat()
    {


        targetRat.transform.parent = transform;
        targetRat.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        targetRat.GetComponent<RatClass>().grabbed= true;
        
        eatCooldown -= Time.deltaTime;
        if (eatCooldown <= 0)
        {
            targetRat.SendMessage("applyDMG", dmg);
            if(targetRat.GetComponent<RatClass>().currentHealth <= 0)
            {
                targetRat.GetComponent<RatClass>().grabbed = false;
            }
            eatCooldown = eatRate;
        }


    }

    //FINDS CLOSEST (ADJACENT HOBO)
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

    //FIND CLOSEST ENEMY (RAT)
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
