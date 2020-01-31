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
            moddedStat = Random.Range(1, 5);
        }
        else if(tr == false)
        {
            moddedStat = -Random.Range(1, 5);
        }
        
        statMod = Random.Range(0,3);
        good = tr;
    }
    
    void WildCard(){}

}



