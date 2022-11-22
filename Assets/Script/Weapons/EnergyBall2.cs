using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall2 : BaseWeapon
{

    private void Start()
    {
        StartCoroutine(EnergyBallCoroutine());
    }

    IEnumerator EnergyBallCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnnemyCollision(collision, damage);
    }
}
