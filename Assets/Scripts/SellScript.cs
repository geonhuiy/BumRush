using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SellScript : MonoBehaviour
{

    public TextMeshProUGUI sellValue;
    public void SellTower()
    {
        TowerManager.tManagerInstance.confirmSellBtn.SetActive(true);
        //sellButton.SetActive(false);
        if (TowerManager.tManagerInstance.currentSelectedTower != null)
        {
            sellValue.SetText(TowerManager.tManagerInstance.SellTowerPrice(TowerManager.tManagerInstance.currentSelectedTower.GetComponent<BumClass>().towerLevel).ToString());
        }
    }


    public void ConfirmSell()
    {
        if (TowerManager.tManagerInstance.currentSelectedTower.transform.parent != null)
        {
            if (TowerManager.tManagerInstance.currentSelectedTower.transform.parent.tag == "Node")
            {
                TowerManager.tManagerInstance.DecreasePrice(TowerManager.tManagerInstance.currentSelectedTower.GetComponent<BumClass>().towerLevel);
                TowerManager.tManagerInstance.currentSelectedTower.transform.parent.GetComponent<AttachTower>().hasTowerAttached = false;
            }
        }
        if (TowerManager.tManagerInstance.hasTowerSpawned())
        {
            TowerManager.tManagerInstance.spawnedTowerCount--;
            TowerManager.tManagerInstance.spawnedTowers.RemoveAt(0);
        }
        GManager.gManagerInstance.money += (int)TowerManager.tManagerInstance.SellTowerPrice(TowerManager.tManagerInstance.currentSelectedTower.GetComponent<BumClass>().towerLevel);
        TowerManager.tManagerInstance.towerStats.SetActive(false);
        TowerManager.tManagerInstance.confirmSellBtn.SetActive(false);
        Destroy(TowerManager.tManagerInstance.currentSelectedTower);

    }
}
