
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform rat;
    public float shot_time;
    public float frate = 2;
    private float t_distance = 20f;
    public GameObject projectile;
    void Start()
    {
        rat = GameObject.FindGameObjectWithTag("Rat").transform;
        shot_time = frate;
    }

    // Update is called once per frame
    void Update()
    {
        if (t_distance <= Vector3.Distance(rat.transform.position, this.transform.position)) //CHECK THAT RAT IS IN RANGE
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
