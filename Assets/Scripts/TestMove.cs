
using UnityEngine;

public class TestMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50f;

    // Update is called once per frame
    void Update()
    {
       
        transform.position = new Vector3(transform.position.x, transform.position.y , Mathf.PingPong(Time.time * speed, 50));
    
    }
}
