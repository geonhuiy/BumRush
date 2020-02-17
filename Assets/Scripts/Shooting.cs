
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Projectile projectile;
    public Transform rat;
    public float shot_time;
    public float frate = 2;
    public float range = 65f;
    private float t_distance;
    public int shot_damage;

    void Start()
    {
        shot_time = frate;
        shot_damage = transform.parent.gameObject.GetComponent<BumClass>().damage;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Shot damage: " + shot_damage);
        if(GameObject.FindGameObjectWithTag("Rat") != null)
        {
            rat = GameObject.FindGameObjectWithTag("Rat").transform;
            t_distance = Vector3.Distance(rat.transform.position, this.transform.position); //GETS DISTANCE BETWEEN FIREPOINT AND RAT
        }
        
        //Debug.Log(t_distance);
        if (GameObject.FindGameObjectWithTag("Rat") != null && t_distance <= range) //CHECK THAT RAT EXISTS AND IS IN RANGE
        {
            if (shot_time <= 0)
            {
                Projectile proj = Instantiate(projectile, transform.position, Quaternion.identity); //INSTANTIATE PROJECTILE
                proj.damage = shot_damage;
                shot_time = frate;
            }
            else
            {
                shot_time -= Time.deltaTime;
            }
        }

    }
}
