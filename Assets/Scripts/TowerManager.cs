using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager tManagerInstance;
    public int spawnedTowerCount, totalTowerCount, selectedTower;
    public int maxTowers = 1;
    public List<GameObject> spawnedTowers;
    public GameObject TempSpawnedHobo, hobo, spawnPlaceholder;
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

    public void PlaceTower() {
        if (hasTowerSpawned()) {

        }
    }

    public void SpawnTower() {
        if(spawnedTowerCount < maxTowers) {
            GameObject newHobo = Instantiate(hobo, spawnPlaceholder.transform.position, Quaternion.identity);
            spawnedTowerCount ++;
            spawnedTowers.Add(newHobo);
        }
    }
}
