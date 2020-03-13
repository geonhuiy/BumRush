using UnityEngine;
using UnityEngine.AI;

public class Path_Finding : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    GameObject endObject;
    public float ratSpeed = 1f;
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        endObject = GameObject.Find("EndPoint");
        target = endObject.transform;
        if (_navMeshAgent == null)
        {
            Debug.LogError("Navmesh error");
        }
        else
        {
            SetDestination();
        }
    }

    private void Update()
    {
        if (_navMeshAgent == null)
        {
            Debug.LogError("Navmesh error");
        }
        else
        {
            SetDestination();
        }
    }
    
    private void SetDestination()
    {
        Vector3 endVector = endObject.transform.position * ratSpeed;
        // Vector3 dir = target.position - transform.position;
        // this.transform.Translate(dir.normalized * Time.deltaTime * ratSpeed, Space.World);
        
        //Vector3 targetVector = _destination.transform.position;
        _navMeshAgent.SetDestination(endVector);
    }
}
