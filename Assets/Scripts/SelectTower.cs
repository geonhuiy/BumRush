using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTower : MonoBehaviour
{
    private void OnMouseDown()
    {
        TowerManager.tManagerInstance.confirmSellBtn.SetActive(false);
        TowerManager.tManagerInstance.currentSelectedTower = this.gameObject;
        TowerManager.tManagerInstance.towerStats.SetActive(true);
    }

    private void Update()
    {
        if (TowerManager.tManagerInstance.currentSelectedTower != null)
        {
            TowerManager.tManagerInstance.SetHoboStats(TowerManager.tManagerInstance.currentSelectedTower.GetComponent<BumClass>());
        }
        if (this.gameObject.GetComponent<BumClass>().hp <= 0) {
            this.gameObject.transform.parent.GetComponent<AttachTower>().hasTowerAttached = false;
            Destroy(this.gameObject);
        }
    }
}
