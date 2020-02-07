
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public Transform rat;
    public float shot_time;
    public float frate = 2;
    public GameObject projectile;
    void Start()
    {
        rat = GameObject.FindGameObjectWithTag("Rat").transform;
        shot_time = frate;
    }

    // Update is called once per frame
    void Update()
    {
        if(shot_time <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shot_time = frate;
        }
        else
        {
            shot_time -= Time.deltaTime;
        }
    }
}
