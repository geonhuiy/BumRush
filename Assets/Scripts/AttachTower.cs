using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTower : MonoBehaviour
{
    public bool hasTowerAttached = false;
    private Vector3 yOffset = new Vector3(0, 2, 0);
    private void OnMouseDown() 
    {
        if (!hasTowerAttached) {
        TowerManager.tManagerInstance.spawnedTowers[0].transform.position = this.transform.position + yOffset;
        TowerManager.tManagerInstance.spawnedTowers[0].transform.parent = this.gameObject.transform;
        hasTowerAttached = true;
        TowerManager.tManagerInstance.spawnedTowers[0].GetComponent<TowerShooting>().enabled = true; 
        TowerManager.tManagerInstance.spawnedTowerCount--;
        TowerManager.tManagerInstance.spawnedTowers.RemoveAt(0);
        }
    }
}
