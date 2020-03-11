using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTower : MonoBehaviour
{
    public bool hasTowerAttached = false;
    private Vector3 yOffset = new Vector3(0, 2, 0);
    private Color defaultColor;
    [SerializeField]
    private Material hoboMaterial;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        defaultColor = gameObject.GetComponent<Renderer>().material.color;
    }
    private void OnMouseDown()
    {
        if (!hasTowerAttached)
        {
            TowerManager.tManagerInstance.spawnedTowers[0].transform.position = this.transform.position + yOffset;
            TowerManager.tManagerInstance.spawnedTowers[0].transform.parent = this.gameObject.transform;
            hasTowerAttached = true;
            TowerManager.tManagerInstance.towerStats.SetActive(false);
            TowerManager.tManagerInstance.towerStats.transform.Find("ConfirmSellBtn").gameObject.SetActive(false);
            TowerManager.tManagerInstance.spawnedTowers[0].GetComponent<TowerShooting>().enabled = true;
            TowerManager.tManagerInstance.spawnedTowerCount--;
            TowerManager.tManagerInstance.spawnedTowers.RemoveAt(0);
            TowerManager.tManagerInstance.currentSelectedTower = null;
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (TowerManager.tManagerInstance.hasTowerSpawned())
        {
            SetTileColor();
        }
        else {
            gameObject.GetComponent<Renderer>().material.color = defaultColor;
        }

    }
    private void SetTileColor()
    {
        if (hasTowerAttached)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
