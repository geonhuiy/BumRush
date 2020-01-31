using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboClass
{
    private int health = 0;
    private int damage = 0;
    public void setStats(int newHealth, int newDamage) {
        health = newHealth;
        damage = newDamage;
    }
}
