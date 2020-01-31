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
    public Traits(bool tr, bool wild = false)
    {
        if (wild)
        {
            WildCard();
        }

        if (tr == true)
        {
            statMod = Random.Range(1, 10);
        }
        else if (tr == false)
        {
            statMod = -Random.Range(1, 10);
        }

        moddedStat = Random.Range(0, 3);

        good = tr;

    }

    void WildCard() { }

}



