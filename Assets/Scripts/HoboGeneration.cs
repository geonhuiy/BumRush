using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoboGeneration : MonoBehaviour
{
    [SerializeField]
    private Button lvl1, lvl2, lvl3;
    private void Start()
    {
    }
    public void SpawnTower()
    {
        TowerManager.tManagerInstance.SpawnTower();
    }

    public void SpawnTowerLevel(int towerLevel) {
        
    }
}
