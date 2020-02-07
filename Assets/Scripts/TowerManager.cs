using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager tManagerInstance;
    public int spawnedTowerCount, totalTowerCount, selectedTower;
    public int maxTowers = 1;
    public List<GameObject> spawnedTowers;
    private void Awake()
    {
        if (tManagerInstance == null)
        {
            tManagerInstance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    private bool hasTowerSpawned()
    {
        if (spawnedTowerCount > 0) {
            return true;
        }
        else {
            return false;
        }
    }
}
