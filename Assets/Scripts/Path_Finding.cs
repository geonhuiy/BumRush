using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path_Finding : MonoBehaviour
{

    //[SerializeField]
    //Transform _destination;

    NavMeshAgent _navMeshAgent;

    GameObject endObject;

    public float ratSpeed = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        endObject = GameObject.Find("EndPoint");


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
        //Vector3 targetVector = _destination.transform.position;
        _navMeshAgent.SetDestination(endVector);
    }

}
