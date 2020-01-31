using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traits : MonoBehaviour
{
    //CLASS VARIABLES
    public int moddedStat;
    public int statMod;
    public bool good;
  


    //CONSTRUCTOR/DESTRUCTOR
    public Traits(bool tr)
    {
        if(tr == true)
        {
            statMod = Random.Range(1, 5);
            Debug.Log(moddedStat);
        }
        else if(tr == false)
        {
            statMod = -Random.Range(1, 5);
            Debug.Log(moddedStat);
        }
        
        moddedStat = Random.Range(0,3);
        Debug.Log(statMod);
        good = tr;
        Debug.Log(good);
    }
    
    void WildCard(){}

}



