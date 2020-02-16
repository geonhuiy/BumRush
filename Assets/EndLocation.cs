using UnityEngine;

public class EndLocation : MonoBehaviour
{
    public Transform t;


    private void Start()
    {
        t = GetComponent<Transform>();

        Debug.Log(t);
        
        
    }

    public void OnTriggerEnter(Collider other)
    {

        // Destroy Object
        // Add to destroyed counter or take lives away
        Debug.Log(other + "Enter collider");
    }

    
}
