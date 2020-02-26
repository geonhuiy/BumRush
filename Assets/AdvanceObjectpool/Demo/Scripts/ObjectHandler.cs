using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHandler : MonoBehaviour
{
    float objectNumber = 1;
    Vector3 pos = new Vector3(0, 1, 10);
    DictionaryObjectPool _objectpool;
    [SerializeField]
    GameObject[] gos;
    public int waveSize = 10;
    public int objectPoolSize = 10;
    public int increaseWaveBy = 10;
    public float waveTimer = 20f;
    public bool waveStarted = false;
    public Text waveCountdown;
    void Start()
    {
        _objectpool = new DictionaryObjectPool();
        _objectpool.AddObjectPool("rats", gos[0], this.transform, objectPoolSize);


    }

    public void SpawnNewWaveOfRats()
    {
        waveSize = waveSize + increaseWaveBy;
        increaseWaveBy += increaseWaveBy;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(waveSize + " is the wave size");
        Debug.Log(increaseWaveBy + " increase by");

        //waveSize += objectNumber * Time.smoothDeltaTime;
        if (_objectpool["rats"].Count < waveSize)
        {
            _objectpool["rats"].Spawn(pos);
            


            waveStarted = true;
        }
      
        if (waveStarted)
        {
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0)
            {
                SpawnNewWaveOfRats();
                waveStarted = false;
                waveTimer = 20f;
            }
        }
        waveCountdown.text = "Time Until Next wave  : " + (int)waveTimer;
        


    }
}
