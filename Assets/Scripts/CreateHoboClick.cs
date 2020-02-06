using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHoboClick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hobo = null;
   

    public void onClickHobo()
    {
        Debug.Log("Clicked");
        BumClass bum = new BumClass();
      //  bum.BumInit(1,hobo);
        Instantiate(hobo, new Vector3(0, 0,15), transform.rotation);
    }
}
