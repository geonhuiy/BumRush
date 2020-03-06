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

    public int numbertospawn = 2;
    public float objectPoolSize = 100f;
    public int waveSize = 2;
    public float waveTimer = 6f;
    public Text waveCountdown;
    void Start()
    {
        // CREATE THE RAT POOL
        _objectpool = new DictionaryObjectPool();
        _objectpool.AddObjectPool("rats", gos[0], this.transform, (int)objectPoolSize);


        // START BY GIVING THE PLAYER X AMOUNT OF TIME BEFORE THE FIRST WAVE
        // WHEN THE TIMER REACHES 0 WAVE STARTED WILL BE FALSE 
        waveTimer -= Time.deltaTime;
        if (waveTimer <= 0)
        {
            waveTimer = 6f;
        }
    }


    // WILL SPAWN NEW WAVE OR RATS. IF i IS LESS THEN THE NUMBER I WANT TO SPAWN, SPAWN ONE RAT.
    // WHEN THAT IS DONE INCREASE NEXT WAVE BY X
    public void SpawnNewWaveOfRats()
    {
        for (int i = 0; i < numbertospawn; i++)
        {
            _objectpool["rats"].Spawn(pos);
        }
        //waveStarted = true;
        numbertospawn += 2;
    }

   
    void Update()
    {

        // WHEN THE TIMER REACHES 0 RUN THE SPAWN METHOD AND RESET THE WAVE TIMER
        if (waveTimer <= 0)
        {
            SpawnNewWaveOfRats();
            waveTimer = 10f;
        }
        waveTimer -= Time.deltaTime;
        
        waveCountdown.text = "" + (int)waveTimer;
    }
}
