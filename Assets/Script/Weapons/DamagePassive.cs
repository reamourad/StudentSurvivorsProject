using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePassive : BaseWeapon
{
    [SerializeField] Player player;

    internal override void LevelUp()
    {
        level++;
        player.material.SetFloat("_Flash", player.material.GetFloat("_Flash") + 0.3f); 
        //adds damage = your level in that weapon
        for(int i = 0; i < level; i++)
        {
            foreach(BaseWeapon weapon in player.weapons)
            {
                weapon.damage += 1;
                Debug.Log(weapon.damage);
            }
        }
    }
}
