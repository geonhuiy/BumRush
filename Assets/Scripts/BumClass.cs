using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BumClass : MonoBehaviour
{

    public int hp = 100;
    public int fire_rate = 1;
    public int damage = 5;
    public int aoe = 1;
   
    private Traits t1;
    private Traits t2;
    private Traits t3;
  
    public void BumInit(int level)
    {

        if (level == 1) //HOBO AT LEVEL 1 GETS 1 STAT MOD
        {

            t1  = new Traits(randBool());
            modify_stat(t1.moddedStat, t1.statMod);
            Debug.Log(t1.moddedStat);
            Debug.Log(t1.statMod);
        }

        else if (level == 2) //HOBO AT LEVEL 2 GETS 2 STAT MODS
        {
            t1 = new Traits(randBool());
            modify_stat(t1.moddedStat, t1.statMod);

            if(t1.good == false) //ASSIGNS POSITIVE TRAIT IF THE FIRST TRAIT IS NEGATIVE
            {
                 t2 = new Traits(true);
                 modify_stat(t2.moddedStat, t2.statMod);
            }
            else if(t1.good == true) //ASSIGN NEGATIVE TRAIT IF THE FIRST TRAIT WAS POSITIVE
            {
                t2 = new Traits(false);
                modify_stat(t2.moddedStat, t2.statMod);
            }
        }

        else if (level == 3)//HOBO AT LEVEL 3 GET 3 TRAITS
        {
            t1 = new Traits(randBool());
            modify_stat(t1.moddedStat, t1.statMod);
            if(t1.good == false)
            {
                 t2 = new Traits(true);
                 modify_stat(t2.moddedStat, t2.statMod);
            }
            else if(t1.good == true)
            {
                t2 = new Traits(false);
                modify_stat(t2.moddedStat, t2.statMod);
            }
            t3 = new Traits(randBool());
        }

    }

    public bool randBool()
    {
        int bit = Random.Range(0,1);

        if (bit == 1) { return true; }
        else { return false; }
    }

    public void modify_stat(int st, int modifier)
    {
        if(st == 0)
        {
            hp +=modifier;
        }

        else if(st == 1)
        {
            fire_rate += modifier;
        }

        else if(st == 2)
        {
            damage +=modifier;
        }

        else if(st == 3)
        {
            aoe +=modifier;
        }
    }

}

