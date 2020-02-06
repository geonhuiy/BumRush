using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traits : MonoBehaviour
{
    //BASIC STAT VARIABLES
    public int moddedStat;
    public int statMod;
    public bool good;

    //WILD CARD VARIABLES
    public int AOE_wildcard;
    public int HOSTILE_wildcard;
    public int STARVING_wildcard;




    //CONSTRUCTOR/DESTRUCTOR
    public Traits(bool tr, bool wild = false)
    {
        if (wild) //IF WILDCARD CONDITION IS TRUE, RUNS WILDCARD GENERATION FUNCTION
        {
            WildCard(Random.Range(0,2));
        }

        else if (tr == true && wild == false)//GIVES POSITIVE STAT MOD
        {
            statMod = Random.Range(1, 11);
        }
        else if (tr == false && wild == false)
        {
            statMod = -Random.Range(1, 11);//GIVES NEGATIVE STAT MOD
        }

        moddedStat = Random.Range(0, 3);//RANDOMLY DECIDES WHICH STAT TO MOD

        good = tr;//SAVES WHETHER THE STAT IS POSITIVE OR NEGATIVE

    }

    void WildCard(int wc)
    {
        if(wc == 0)
        {

        }
        else if(wc == 1)
        {

        }
        else if(wc == 2)
        {

        }
    }

}



