using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    public static TowerManager tManagerInstance;
    public int spawnedTowerCount;
    public int maxTowers = 1;
    public List<GameObject> spawnedTowers;
    public GameObject hobo, spawnPlaceholder;
    private int currentTowerCost = 0;
    public enum TowerPrices
    {
        lvl1 = 5,
        lvl2 = 10,
        lvl3 = 15
    }
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
    }

    public bool hasTowerSpawned()
    {
        if (spawnedTowerCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SpawnTower()
    {
        if (spawnedTowerCount < maxTowers)
        {
            GManager.gManagerInstance.money -= 5;
            //hobo.GetComponent<BumClass>().BumInit(1); //LEVEL 1 HOBO
            //GameObject newHobo = Instantiate(hobo, spawnPlaceholder.transform.position, Quaternion.identity);'
            GameObject newHobo = Instantiate(hobo, spawnPlaceholder.transform.position, Quaternion.identity);
            newHobo.gameObject.GetComponent<TowerShooting>().enabled = false;
            spawnedTowerCount++;
            spawnedTowers.Add(newHobo);
        }
    }
    public void SpawnLevelTower(int level)
    {
        if (spawnedTowerCount < maxTowers)
        {
            if (PlayerHasMoney(level))
            {
                GManager.gManagerInstance.money -= currentTowerCost;
                GameObject newHobo = Instantiate(hobo, spawnPlaceholder.transform.position, Quaternion.identity);
                newHobo.GetComponent<TowerShooting>().enabled = false;
                newHobo.GetComponent<BumClass>().BumInit(level);
                spawnedTowerCount++;
                spawnedTowers.Add(newHobo);
            }

        }
    }

    public bool PlayerHasMoney(int towerLevel)
    {
        bool hasMoney = false;
        switch (towerLevel)
        {
            case 1:
                if (GManager.gManagerInstance.money >= (int)(TowerPrices.lvl1))
                {
                    hasMoney = true;
                    currentTowerCost = (int)(TowerPrices.lvl1);
                    break;
                }
                else
                {
                    Debug.Log("Not enough money for level " + towerLevel);
                    hasMoney = false;
                    break;
                }
            case 2:
                if (GManager.gManagerInstance.money >= (int)(TowerPrices.lvl2))
                {
                    hasMoney = true;
                    currentTowerCost = (int)(TowerPrices.lvl2);
                    break;
                }
                else
                {
                    Debug.Log("Not enough money for level " + towerLevel);
                    hasMoney = false;
                    break;
                }
            case 3:
                if (GManager.gManagerInstance.money >= (int)(TowerPrices.lvl3))
                {
                    hasMoney = true;
                    currentTowerCost = (int)(TowerPrices.lvl3);
                    break;
                }
                else
                {
                    Debug.Log("Not enough money for level " + towerLevel);
                    hasMoney = false;
                    break;
                }
        }
        return hasMoney;
    }
}
