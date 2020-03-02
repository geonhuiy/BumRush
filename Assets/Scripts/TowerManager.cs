using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager tManagerInstance;
    public int spawnedTowerCount;
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

    public bool hasTowerSpawned()
    {
        if (spawnedTowerCount > 0) {
            return true;
        }
        else {
            return false;
        }
    }
    public void SpawnTower() {
        if(spawnedTowerCount < maxTowers) {
            GManager.gManagerInstance.money -= 5;
            //hobo.GetComponent<BumClass>().BumInit(1); //LEVEL 1 HOBO
            //GameObject newHobo = Instantiate(hobo, spawnPlaceholder.transform.position, Quaternion.identity);'
            GameObject newHobo = Instantiate(hobo, spawnPlaceholder.transform.position, Quaternion.identity);
            newHobo.gameObject.GetComponent<TowerShooting>().enabled = false;
            spawnedTowerCount ++;
            spawnedTowers.Add(newHobo);
        }
    }
}
