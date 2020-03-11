using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerManager : MonoBehaviour
{

    public static TowerManager tManagerInstance;
    public int spawnedTowerCount;
    public int maxTowers = 1;
    public List<GameObject> spawnedTowers;
    public GameObject hobo, towerPlaceHolder;
    private int currentTowerCost = 0;

    public TextMeshProUGUI hoboDamage, hoboFireRate, hoboHealth, hoboTraits;
    public enum TowerPrices
    {
        lvl1 = 5,
        lvl2 = 10,
        lvl3 = 15
    }
    public GameObject towerStats = null;
    public GameObject currentSelectedTower = null;
    public GameObject confirmSellBtn;
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
            GameObject newHobo = Instantiate(hobo, towerPlaceHolder.transform.position, Quaternion.identity);
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
                GameObject newHobo = Instantiate(hobo, new Vector3(0, 0, 0), Quaternion.identity);
                newHobo.transform.SetParent(towerPlaceHolder.transform, false);
                newHobo.GetComponent<TowerShooting>().enabled = false;
                newHobo.GetComponent<BumClass>().BumInit(level);
                newHobo.GetComponent<BumClass>().towerLevel = level;
                currentSelectedTower = newHobo;
                towerStats.SetActive(true);
                SetHoboStats(currentSelectedTower.GetComponent<BumClass>());
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

    public void SetHoboStats(BumClass hoboStats)
    {
        hoboDamage.SetText(hoboStats.damage.ToString());
        hoboHealth.SetText(hoboStats.hp.ToString());
        hoboFireRate.SetText(hoboStats.fire_rate.ToString());
        if (hoboStats.starving_on)
        {
            hoboTraits.SetText("Starving");

        }
        else if (hoboStats.bum_aoe_on)
        {
            hoboTraits.SetText("AOE");
        }
        else if (hoboStats.hostile_on)
        {
            hoboTraits.SetText("Hostile");
        }
        else
        {
            hoboTraits.SetText("No trait");
        }
    }

    public float SellTowerPrice(float towerLevel)
    {
        float sellPrice = 0;
        switch (towerLevel)
        {
            case 1:
                sellPrice = (float)TowerManager.TowerPrices.lvl1;
                break;
            case 2:
                sellPrice = (float)TowerManager.TowerPrices.lvl2;
                break;
            case 3:
                sellPrice = (float)TowerManager.TowerPrices.lvl3;
                break;
        }
        return Mathf.Floor(sellPrice / 2);
    }
}
