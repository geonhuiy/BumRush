using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTower : MonoBehaviour
{
    private bool hasTowerAttached = false;
    private void OnMouseDown() 
    {
        if (!hasTowerAttached) {
        TowerManager.tManagerInstance.spawnedTowers[0].transform.position = this.transform.position;
        hasTowerAttached = true;
        TowerManager.tManagerInstance.spawnedTowerCount--;
        TowerManager.tManagerInstance.spawnedTowers.RemoveAt(0);
        }
    }
}
