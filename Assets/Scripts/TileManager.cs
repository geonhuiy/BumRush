using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private GameObject tower;
    private Vector3 pos;
    void Awake()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            /*Vector2 origin = new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            if (hit) {
                Debug.Log(hit.transform.gameObject.name);
            }*/
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            pos = grid.WorldToCell(worldPoint);
            PlaceTower(worldPoint);
            Debug.Log(pos);
        }
    }

    private void PlaceTower(Vector3 point) {
        Instantiate(tower, point, Quaternion.identity);
    }
}
