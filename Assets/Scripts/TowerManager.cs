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
    public GameObject hobo_01, hobo_02, hobo_03, towerPlaceHolder;
    private int currentTowerCost;

    public TextMeshProUGUI hobo1, hobo2, hobo3;

    public TextMeshProUGUI hoboDamage, hoboFireRate, hoboHealth, hoboTraits;
    public GameObject towerStats = null;
    public GameObject currentSelectedTower = null;
    public GameObject confirmSellBtn;
    public int lvl1price = 5;
    public int lvl2price =10;
    public int lvl3price = 20;
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
            GameObject newHobo = Instantiate(hobo_01, towerPlaceHolder.transform.position, Quaternion.identity);
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
                GameObject newHobo;
                if (level == 1)
                {
                    newHobo = Instantiate(hobo_01, new Vector3(0, 0, 50), Quaternion.identity);
                    newHobo.GetComponent<TowerShooting>().enabled = false;
                    newHobo.GetComponent<BumClass>().BumInit(level);
                    newHobo.GetComponent<BumClass>().towerLevel = level;
                    currentSelectedTower = newHobo;
                    towerStats.SetActive(true);
                    SetHoboStats(currentSelectedTower.GetComponent<BumClass>());
                    spawnedTowerCount++;
                    spawnedTowers.Add(newHobo);
                }
                if (level == 2)
                {
                    newHobo = Instantiate(hobo_02, new Vector3(0, 0, 50), Quaternion.identity);
                    newHobo.GetComponent<TowerShooting>().enabled = false;
                    newHobo.GetComponent<BumClass>().BumInit(level);
                    newHobo.GetComponent<BumClass>().towerLevel = level;
                    currentSelectedTower = newHobo;
                    towerStats.SetActive(true);
                    SetHoboStats(currentSelectedTower.GetComponent<BumClass>());
                    spawnedTowerCount++;
                    spawnedTowers.Add(newHobo);
                }
                if (level == 3)
                {
                    newHobo = Instantiate(hobo_03, new Vector3(0, 0, 50), Quaternion.identity);
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
    }

    public bool PlayerHasMoney(int towerLevel)
    {
        bool hasMoney = false;
        switch (towerLevel)
        {
            case 1:
                if (GManager.gManagerInstance.money >= lvl1price)
                {
                    hasMoney = true;
                    currentTowerCost = lvl1price;
                    break;
                }
                else
                {
                    Debug.Log("Not enough money for level " + towerLevel);
                    hasMoney = false;
                    break;
                }
            case 2:
                if (GManager.gManagerInstance.money >= lvl2price)
                {
                    hasMoney = true;
                    currentTowerCost = lvl2price;
                    break;
                }
                else
                {
                    Debug.Log("Not enough money for level " + towerLevel);
                    hasMoney = false;
                    break;
                }
            case 3:
                if (GManager.gManagerInstance.money >= lvl3price)
                {
                    hasMoney = true;
                    currentTowerCost = lvl3price;
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
            //hoboStats.gameObject.GetComponent<Renderer>().material.color = Color.red;
            hoboStats.gameObject.transform.Find("Beard").GetComponent<Renderer>().material.color = Color.red;
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
                sellPrice = 5f;
                break;
            case 2:
                sellPrice = 10f;
                break;
            case 3:
                sellPrice = 20f;
                break;
        }
        return Mathf.Floor(sellPrice / 2);
    }

    public void IncreasePrice(float towerLevel) {
        switch(towerLevel)
        {
            case 1:
            lvl1price += 2;
                hobo1.text = lvl1price + "$ HOBO";
                break;
            case 2:
            lvl2price += 4;
                hobo2.text = lvl2price + "$" + "\nHOBO";
            break;
            case 3:
            lvl3price += 10;
                hobo3.text = lvl3price + "$" + "\nHOBO";
            break;
        }
    }

    public void DecreasePrice(float towerLevel) {
        switch(towerLevel)
        {
            case 1:
            lvl1price -= 2;
                hobo1.text = lvl1price + "$ HOBO";
                break;
            case 2:
            lvl2price -= 4;
                hobo2.text = lvl2price + "$" + "\nHOBO";
                break;
            case 3:
            lvl3price -= 10;
                hobo3.text = lvl3price + "$" + "\nHOBO";
                break;
        }
    }
}
