using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BumClass : MonoBehaviour
{

    //BASE STAT VARIABLES
    public float hp = 100;
    public float fire_rate = 1;
    public float damage = 5;
    Color defaultColor;
    //WILDCARDS VARIABLES
    public float bum_aoe_radius = 5;
    public bool bum_aoe_on = false;
    public bool hostile_on = false;
    public bool starving_on = false;
    private Traits t1;
    private Traits t2;
    private Traits t3;
    private void Awake()
    {
        BumInit(3);
        defaultColor = gameObject.GetComponent<Renderer>().material.color;

    }

    public void BumInit(int level)
    {

        if (level == 1) //HOBO AT LEVEL 1 GETS 1 STAT MOD (RANDOMLY EITHER POSITIVE OR NEGATIVE)
        {
            t1 = new Traits(randBool());
            modify_stat(t1.moddedStat, t1.statMod);
        }

        else if (level == 2) //HOBO AT LEVEL 2 GETS 2 STAT MODS (1 POSITIVE, 1 NEGATIVE);
        {
            t1 = new Traits(randBool());
            modify_stat(t1.moddedStat, t1.statMod);

            if (t1.good == false) //ASSIGNS POSITIVE TRAIT IF THE FIRST TRAIT IS NEGATIVE
            {
                t2 = new Traits(true);
                modify_stat(t2.moddedStat, t2.statMod);
            }
            else if (t1.good == true) //ASSIGN NEGATIVE TRAIT IF THE FIRST TRAIT WAS POSITIVE
            {
                t2 = new Traits(false);
                modify_stat(t2.moddedStat, t2.statMod);
            }
        }

        else if (level == 3)//HOBO AT LEVEL 3 GET 3 TRAITS (1 POSITIVE, 1 NEGATIVE, 1 WILDCARD)
        {
            t1 = new Traits(randBool());
            modify_stat(t1.moddedStat, t1.statMod);
            if (t1.good == false)
            {
                t2 = new Traits(true);
                modify_stat(t2.moddedStat, t2.statMod);
            }
            else if (t1.good == true)
            {
                t2 = new Traits(false);
                modify_stat(t2.moddedStat, t2.statMod);
            }
            t3 = new Traits(false, true);
            assign_wildcard(t3);
        }

    }

    public bool randBool() //RETURNS RANDOM BOOLEAN VALUE
    {
        int bit = Random.Range(0, 1);

        if (bit == 1) { return true; }
        else { return false; }
    }

    public void modify_stat(int st, int modifier)
    {
        if (st == 0)//MODIFIES HP STAT
        {
            hp += modifier * 10;
            if (hp <= 0) { hp = 1; }
        }

        else if (st == 1)//MODIFIES FIRE RATE STAT
        {
            fire_rate += modifier * 0.1f;
            if (fire_rate <= 0) { fire_rate = 0.3f; }
        }

        else if (st == 2)//MODIFIES DAMAGE STAT
        {
            damage += modifier;
            if (damage <= 0) { damage = 1; }
        }
    }

    public void assign_wildcard(Traits wc_tr) //APPLIES WILDCARD TRAIT TO HOBO
    {
        if (wc_tr.AOE_wildcard)
        {
            // bum_aoe_on = true;
        }
        else if (wc_tr.HOSTILE_wildcard)
        {
            hostile_on = wc_tr.HOSTILE_wildcard;
        }
        else if (wc_tr.STARVING_wildcard)
        {
            starving_on = true;
        }
    }

    //APPLY DAMAGE
    void applyDMG(float d)
    {
        if (hp <= 0)
        {
            this.gameObject.transform.parent.GetComponent<AttachTower>().hasTowerAttached = false;
            Destroy(this.gameObject);
        }

        hp -= d;
        //gameObject.GetComponent<Renderer>().material.color = Color.red;
        //WaitForSeconds(0.5);
        //gameObject.GetComponent<Renderer>().material.color = defaultColor;
        Debug.Log("Hobo has " + hp + " HP");
        Debug.Log("Hobo took" + d + "damage");

    }
}

