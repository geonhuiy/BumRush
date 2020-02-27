
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Projectile projectile;
    public Transform rat;
    public Transform other_hobo;
    private GameObject parentObj;

    public float shot_time;
    public float stab_time;
    public float frate = 2;
    public float range = 65f;
    float hostility_range = 5f; //RANGE TO ADJACENT HOBO
    private float rat_distance; //DISTANCE FROM NEAREST RAT
    private float bum_distance; //DISTANCE FROM OTHER NEAREST HOBO (FOR HOSTILITY WILD CARD)
    public float shot_damage;
    
    public bool hostile;


    void Start()
    {
        parentObj = transform.parent.gameObject;
        shot_time = frate;
        stab_time = frate;
        shot_damage = parentObj.GetComponent<BumClass>().damage; //GET STATS FROM BUMCLASS
        hostile = parentObj.GetComponent<BumClass>().hostile_on;

    }

    // Update is called once per frame
    void Update()
    {

        if (hostile == true) //CHECK IF THIS HOBO IS HOSTILE AND TAKE ACTION
        {
            hostility();
        }
       // hostility(); //testing
        if (GameObject.FindGameObjectWithTag("Rat") != null)
        {
            rat = GameObject.FindGameObjectWithTag("Rat").transform;
            rat_distance = Vector3.Distance(rat.position, this.transform.position); //GETS DISTANCE BETWEEN FIREPOINT AND RAT
        }

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

    void hostility() //WORKS ALMOST IDENTICALLY TO shootRat function
    {
        if (GameObject.FindGameObjectsWithTag("Hobo") != null)
        {
            other_hobo = GameObject.FindGameObjectWithTag("Hobo").transform;
            bum_distance = Vector3.Distance(other_hobo.position, this.transform.position); //GET DISTANCE TO CLOSEST HOBO
            if (bum_distance <= hostility_range) //CHECK WHETHER HOBO IS ADAJACENT
            {
                if(stab_time <= 0)
                {
                    other_hobo.SendMessage("applyDMG", 1);
                    stab_time = frate;
                }
                else
                {
                    stab_time -= Time.deltaTime;
                } 
            }
        }
    }


}
