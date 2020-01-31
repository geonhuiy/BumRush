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
    private HoboClass hobo = new HoboClass();
    void OnMouseDown()
    {
        Debug.Log("Mouse");
        //GameObject newHobo = Instantiate(hobo);
    }
    void CreateHobo() {
        hobo.setStats(1,1);
    }
}
