using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableobjectObjectPoolTest : MonoBehaviour
{
    [SerializeField]
    ScriptableObjectObjectPool _objectPool;
    [SerializeField]
    int numberstospawn = 1000;

    // Start is called before the first frame update
    void Start()
    {
        _objectPool.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (_objectPool["rats"].Count < numberstospawn)
        {
            _objectPool["rats"].Spawn(this.transform.position);
        }
        
    }
}
