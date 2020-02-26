using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    float objectNumber = 1;
    Vector3 pos = new Vector3(0, 1, 10);
    DictionaryObjectPool _objectpool;
    [SerializeField]
    GameObject[] gos;
    [SerializeField]
    public float numberstospawn = 1.0f;
    // Use this for initialization
    void Start()
    {
        _objectpool = new DictionaryObjectPool();
        _objectpool.AddObjectPool("rats", gos[0], this.transform, 100);


    }

    // Update is called once per frame
    void Update()
    {
        numberstospawn += objectNumber * Time.smoothDeltaTime;
        if (_objectpool["rats"].Count < numberstospawn)
        {
            _objectpool["rats"].Spawn(pos);
        }

    }
}
