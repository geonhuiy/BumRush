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
        TowerManager.tManagerInstance.SpawnTower();
    }
}
