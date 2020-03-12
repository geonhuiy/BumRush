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
    public bool AOE_wildcard = false;
    public bool HOSTILE_wildcard = false;
    public bool STARVING_wildcard = false;




    //CONSTRUCTOR/DESTRUCTOR
    public Traits(bool tr,  int lvl, bool wild = false)
    {
        if (wild) //IF WILDCARD CONDITION IS TRUE, RUNS WILDCARD GENERATION FUNCTION
        {
            
            WildCard(Random.Range(0, 3));
            
        }

        if (tr == true && wild == false)//GIVES POSITIVE STAT MOD
        {
            Debug.Log("Positive stat given");
            if(lvl == 1)
            {
                statMod = Random.Range(2, 5);
            }
            else if(lvl == 2)
            {
                statMod = Random.Range(4, 7);
            }
            else if(lvl == 3)
            {
                statMod = Random.Range(6, 9);
            }
            
        }
        if (tr == false && wild == false)
        {

            //GIVES NEGATIVE STAT MOD
            if(lvl == 1)
            {
                statMod = -(Random.Range(2, 5));
            }
            else if(lvl == 2)
            {
                statMod = -(Random.Range(4, 7));
            }
            else if(lvl == 3)
            {
                statMod = -(Random.Range(6, 9));
            }
        }

        moddedStat = Random.Range(0, 3);//RANDOMLY DECIDES WHICH STAT TO MOD

        //good = tr;//SAVES WHETHER THE STAT IS POSITIVE OR NEGATIVE

    }

    void WildCard(int wc) //DECIDE WHICH WILDCARD TO ASSIGN BASED OF VALUE PASSED
    {
        if (wc == 0)
        {
            AOE_wildcard = true;
        }
        else if (wc == 1)
        {
            HOSTILE_wildcard = true;
        }
        else if (wc == 2)
        {
            STARVING_wildcard = true;
        }
    }

}



