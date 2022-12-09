using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnergyBall : BaseWeapon
{
    [SerializeField] Player player;
    [SerializeField] GameObject energyBall;
    [SerializeField] SimpleObjectPool pool;
     
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
                    GameObject energy = pool.Get();
                    energy.transform.position = player.transform.position + offset;
                    energy.transform.rotation = Quaternion.identity;
                    energy.SetActive(true);
                    //GameObject energy = Instantiate(energyBall, player.transform.position + offset, Quaternion.identity);
                    energy.GetComponent<EnergyBall2>().damage = this.damage;
                }
            }
        }
    }
}
