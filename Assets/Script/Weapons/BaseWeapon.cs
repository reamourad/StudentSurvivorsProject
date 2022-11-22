using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWeapon : MonoBehaviour
{
    protected bool isCooldown = false;
    public int level;
    public int damage = 1;
    public string weaponName;
    public string description;
    public Sprite sprite;

    //level up a weapon
    internal virtual void LevelUp()
    {
        //when i level up 0 -> 1: activate weapon
        if(++level == 1)
        {
            gameObject.SetActive(true);
        }
    }

    internal IEnumerator WeaponCooldownCoroutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(0.2f);
        isCooldown = false;
    }

    //When the weapon comes in contact with an ennemy 
    internal void EnnemyCollision(Collider2D collision, int damage)
    {
        Ennemy ennemy = collision.GetComponent<Ennemy>();
        if (ennemy)
        {
            if (!isCooldown)
            {
                ennemy.Damage(damage);
                StartCoroutine(WeaponCooldownCoroutine());
            }

        }
    }

}
