using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGeneration : MonoBehaviour
{   
    [SerializeField]
    private GameObject[,,] layout;
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private float spacing = 0.1f;
    void Update() {

    }

    void Start() {
        GenerateNodes(50,50);
    }

    private void GenerateNodes(int rowSize, int colSize) {
        layout = new GameObject[rowSize,0,colSize];
        for (int i = 0; i < layout.GetLength(0); i++) {
            for (int j = 0; j < layout.GetLength(2); j++) {
                GameObject newTile = Instantiate(tile,new Vector3(i+(i*4f), 0 ,j+(j*4f)),Quaternion.identity);
                //newTile.transform.localScale += new Vector3(4,0,4);
                //newTile.transform.position = new Vector3(i,0,j);
            }
        }
    }
}
