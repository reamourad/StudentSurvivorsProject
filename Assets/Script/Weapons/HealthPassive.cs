using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPassive : BaseWeapon
{
    [SerializeField] Player player;

    internal override void LevelUp()
    {
        level++;
        Player.maxHp += this.level;
        Debug.Log("Max Health Uodated" + Player.maxHp);
    }

}
