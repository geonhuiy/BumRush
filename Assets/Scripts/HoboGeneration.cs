using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject hobo;
    void OnMouseDown()
    {
        Debug.Log("Mouse");
        GameObject newHobo = Instantiate(hobo, new Vector3(0,1,0),Quaternion.identity);
        //Increases tower spawn count
        TowerManager.tManagerInstance.spawnedTowerCount++;
        //Adds spawned tower into a list gameobjects
        TowerManager.tManagerInstance.spawnedTowers.Add(newHobo);
    }
}
