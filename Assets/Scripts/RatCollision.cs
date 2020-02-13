using UnityEngine;

public class RatCollision : MonoBehaviour
{
void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
