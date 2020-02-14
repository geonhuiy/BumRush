
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform rat;
    public float shot_time;
    public float frate = 2;
    public float range = 65f;
    private float t_distance;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Rat") != null)
        {
            rat = GameObject.FindGameObjectWithTag("Rat").transform;
        }

        shot_time = frate;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Rat") != null)
        {
            t_distance = Vector3.Distance(rat.transform.position, this.transform.position); //GETS DISTANCE BETWEEN FIREPOINT AND RAT
        }
        
        //Debug.Log(t_distance);
        if (rat != null && t_distance <= range) //CHECK THAT RAT EXISTS AND IS IN RANGE
        {
            if (shot_time <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity); //INSTANTIATE PROJECTILE
                shot_time = frate;
            }
            else
            {
                shot_time -= Time.deltaTime;
            }
        }

    }
}
