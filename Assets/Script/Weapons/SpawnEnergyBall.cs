using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnergyBall : BaseWeapon
{
    [SerializeField] Player player;
    [SerializeField] GameObject energyBall;

    private void Start()
    {
        StartCoroutine(SpawnEnergyBallCoroutine());
    }

    IEnumerator SpawnEnergyBallCoroutine()
    {
        while (true)
        {
            if (player)
            {
                yield return new WaitForSeconds(6f);
                for (int i = 0; i < level; i++)
                {
                    int xOffset = Random.Range(1, 5);
                    int yOffset = Random.Range(1, 5);
                    Vector3 offset = new Vector3(xOffset, yOffset, 0);
                    GameObject energy = Instantiate(energyBall, player.transform.position + offset, Quaternion.identity);
                    energy.GetComponent<EnergyBall2>().damage = this.damage;
                }
            }
        }
    }
}
