using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    DictionaryObjectPool _objectpool;
    [SerializeField]
    GameObject[] gos;
    [SerializeField]
    int numberstospawn = 1000;
	// Use this for initialization
	void Start ()
    {
        _objectpool = new DictionaryObjectPool();
        _objectpool.AddObjectPool("rats", gos[0], this.transform, 100);
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (_objectpool["rats"].Count < numberstospawn)
        {
            _objectpool["rats"].Spawn(this.transform.position);
        }
        
    }
}
