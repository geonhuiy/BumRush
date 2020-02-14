using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGeneration : MonoBehaviour
{   
    [SerializeField]
    private GameObject[,,] layout;
    public List<GameObject> tile;
    [SerializeField]
    private float spacing = 4f;
    void Update() {

    }

    void Start() {
        GenerateNodes(10,16);
    }

    private void GenerateNodes(int rowSize, int colSize) {
        layout = new GameObject[rowSize,0,colSize];
        for (int i = 0; i < layout.GetLength(0); i++) {
            
            for (int j = 0; j < layout.GetLength(2); j++) {
                int randTile = Random.Range(0,tile.Count);
                GameObject newTile = Instantiate(tile[randTile],new Vector3(i+(i*spacing), 0 ,j+(j*spacing)),Quaternion.identity);
                //newTile.transform.localScale += new Vector3(0,40,0);
                //newTile.transform.position = new Vector3(i,0,j);
            }
        }
    }
}
