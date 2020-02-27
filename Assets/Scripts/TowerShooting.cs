using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public GameObject targetRat, targetHobo;
    private GameObject[] targets;
    [SerializeField]
    private GameObject projectile;
    private float towerRange = 16f;
    private float hoboRange;
    private float towerRatDistance, towerHoboDistance, attackCooldown, fireRate;
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
        targets = GameObject.FindGameObjectsWithTag("Rat");
        targetRat = FindClosestEnemy(targets);

        if (hostile)
        {
            FindAdjacentHobo();
            AttackHobo();
        }

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
            GameObject hoboShot = Instantiate(projectile, transform.position + 2 * transform.forward, transform.rotation, transform);
            //hoboShot.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
            attackCooldown = fireRate;
        }
    }
    private void AttackHobo()
    {
        if (targetHobo != null)
        {
            transform.LookAt(targetHobo.transform);
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                targetHobo.SendMessage("applyDMG", 1);
                attackCooldown = fireRate;
            }
        }

    }

    private void FindAdjacentHobo()
    {

        this.gameObject.tag = "this hobo";//GIVE THIS HOBO TEMPORARY TAG
        if (GameObject.FindGameObjectsWithTag("Hobo") != null)
        {
            other_hobo = GameObject.FindGameObjectWithTag("Hobo").transform;
            towerHoboDistance = Vector3.Distance(other_hobo.position, this.transform.position); //GET DISTANCE TO CLOSEST HOBO
            Debug.Log("Distance to hobo: " + towerHoboDistance);
            if (towerHoboDistance <= hostility_range && towerHoboDistance > 0) //CHECK WHETHER HOBO IS ADAJACENT
            {
                targetHobo = GameObject.FindGameObjectWithTag("Hobo"); //ASSIGN HOBO TO BE TARGET
            }
        }
        this.gameObject.tag = "Hobo";//RESET TAG TO "Hobo"
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
