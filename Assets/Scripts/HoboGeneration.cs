using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject hobo;
    [SerializeField]
    private GameObject placeholder;
    void OnMouseDown()
    {
        if (TowerManager.tManagerInstance.spawnedTowerCount < TowerManager.tManagerInstance.maxTowers)
        {
            GameObject newHobo = Instantiate(hobo, placeholder.transform.position, Quaternion.identity);
            //Increases tower spawn count
            TowerManager.tManagerInstance.spawnedTowerCount++;
            //Adds spawned tower into a list gameobjects
            TowerManager.tManagerInstance.spawnedTowers.Add(newHobo);
        }
    }
}
