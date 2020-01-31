using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboGeneration : MonoBehaviour
{
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    [SerializeField]
    private GameObject hobo;
    void OnMouseDown()
    {
        Debug.Log("Mouse");
        GameObject newHobo = Instantiate(hobo, new Vector3(0,1,0),Quaternion.identity);
        newHobo.GetComponent<BumClass>().BumInit(2);
    }
}
