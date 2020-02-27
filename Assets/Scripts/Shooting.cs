
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Projectile projectile;
    public Transform rat;
    public Transform other_hobo;
    private GameObject parentObj;

    public float shot_time;
    public float frate = 2;
    public float range = 65f;
    private float rat_distance; //DISTANCE FROM NEAREST RAT
    private float bum_distance; //DISTANCE FROM OTHER NEAREST HOBO (FOR HOSTILITY WILD CARD)
    public float shot_damage;
    public bool hostile_dmg;
    

    void Start()
    {
        parentObj = transform.parent.gameObject;
        shot_time = frate;
        shot_damage = parentObj.GetComponent<BumClass>().damage; //GET STATS FROM BUMCLASS
        if(parentObj.GetComponent<BumClass>().hostile == true)
        {

        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(parentObj.GetComponent<BumClass>().hostile == true && ) //CHECK FOR OTHER HOBO IN RANGE
        {
            
        }
        if (GameObject.FindGameObjectWithTag("Rat") != null)
        {
            rat = GameObject.FindGameObjectWithTag("Rat").transform;
            rat_distance = Vector3.Distance(rat.transform.position, this.transform.position); //GETS DISTANCE BETWEEN FIREPOINT AND RAT
        }

        //Debug.Log(t_distance);
        if (GameObject.FindGameObjectWithTag("Rat") != null && rat_distance <= range) //CHECK THAT RAT EXISTS AND IS IN RANGE
        {
            if (shot_time <= 0)
            {
                Projectile proj = Instantiate(projectile, transform.position, Quaternion.identity); //INSTANTIATE PROJECTILE
                proj.carried_damage = shot_damage;
                shot_time = frate;
            }
            else
            {
                shot_time -= Time.deltaTime;
            }
        }

    }

    void hostility()
    {

    }
}
