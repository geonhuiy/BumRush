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
        if (wild) //IF WILDCARD CONDITION IS TRUE, RUNS WILDCARD GENERATION FUNCTION
        {
            WildCard();
        }

        if (tr == true)//GIVES POSITIVE STAT MOD
        {
            statMod = Random.Range(1, 11);
        }
        else if (tr == false)
        {
            statMod = -Random.Range(1, 11);//GIVES NEGATIVE STAT MOD
        }

        moddedStat = Random.Range(0, 3);//RANDOMLY DECIDES WHICH STAT TO MOD

        good = tr;//SAVES WHETHER THE STAT IS POSITIVE OR NEGATIVE

    }

    void WildCard() { }

}



