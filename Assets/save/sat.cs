using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class sat 
{
    public float point = 2;
    public float maxhp = 100;
    public float currenthp = 100;

    public float maxmp = 100;
    public float currentmp = 100;

    public float defent = 5;
    public float attack = 2;
    public float skill = 2;
    public sat (playersat player)
    {
        point = player.point;
        maxhp = player.maxhp;
        currenthp = player.currenthp;
        currentmp = player.currentmp;
        maxmp = player.maxmp;
        defent = player.defent;
        attack = player.attack;
        skill = player.skill;
    }
}
