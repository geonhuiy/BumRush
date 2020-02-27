using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour, ISpawnEvent
{
    ObjectPool pool;






    // Update is called once per frame
    void Update()
    {


        if (this.transform.position.y < -20)
        {
            pool.Despawn(this.gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        pool.Despawn(this.gameObject);
        Debug.Log("Rat entered the cave");
    }
    public void OnCollisionEnter(Collision collision)
    {

    }

    public void OnSpawned(GameObject targetGameObject, ObjectPool sender)
    {
        pool = sender;

    }
}
