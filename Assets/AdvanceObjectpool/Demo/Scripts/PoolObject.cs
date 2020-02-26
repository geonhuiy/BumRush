using UnityEngine;


public class PoolObject : MonoBehaviour, ISpawnEvent
{
    ObjectPool pool;

    public void OnTriggerEnter(Collider other)
    {
        DespawnPoolObject();
    }

    public void DespawnPoolObject()
    {
        pool.Despawn(this.gameObject);
    }

    public void OnSpawned(GameObject targetGameObject, ObjectPool sender)
    {
        pool = sender;
    }
}
