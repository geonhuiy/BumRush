using UnityEngine;
using UnityEngine.UI;


public class PoolObject : MonoBehaviour, ISpawnEvent
{
    ObjectPool pool;
    RatClass ratClassScript;
    public float currentHealth;
    private float maxHealth = 30;
    public Image Healthbar;
    public float damage;
    private Quaternion initialRotation;
    PoolObject po;

    public void OnTriggerEnter(Collider other)
    {
        DespawnPoolObject(other.gameObject);
    }

    public void DespawnPoolObject(GameObject rat)
    {
        pool.Despawn(rat);
        rat.GetComponent<RatClass>().currentHealth = rat.GetComponent<RatClass>().maxHealth;
        rat.GetComponent<RatClass>().Healthbar.fillAmount = 1;
    }

    public void OnSpawned(GameObject targetGameObject, ObjectPool sender)
    {
        pool = sender;
    }

    void Start()
    {
        //currentHealth = maxHealth;
        //initialRotation = Healthbar.transform.rotation;

    }

    void LateUpdate()
    {
        //Healthbar.transform.rotation = initialRotation;
    }

    /*private void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.name == "TestShot(Clone)")
        //if (hit.gameObject.CompareTag("Rat"))
        {
            currentHealth -= damage;
            //Debug.Log("Current health : " + currentHealth + " Damage taken : " + damage);
            Healthbar.fillAmount = (currentHealth / maxHealth);
            if (currentHealth <= 0)
            {
                Debug.Log("Health is 0, should destroy");
                //Destroy(this.gameObject);
                DespawnPoolObject();
            }
        }
    }*/
}
