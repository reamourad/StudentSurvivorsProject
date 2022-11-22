using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheSpawner : BaseWeapon
{
    [SerializeField] GameObject scythe;
    [SerializeField] Player player;
    [SerializeField] SimpleObjectPool pool;
    private void Start()
    {
        StartCoroutine(SpawnScytheCoroutine());
    }
    IEnumerator SpawnScytheCoroutine()
    {
        while (true)
        {
            if (player)
            {
                yield return new WaitForSeconds(2f);
                for (int i = 0; i < level; i++)
                {
                    float angle = Random.Range(0, 360);
                    //GameObject newScythe = Instantiate(scythe, transform.position, Quaternion.Euler(0, 0, angle));
                    var newScythe = pool.Get();
                    newScythe.transform.position = transform.position;
                    newScythe.transform.rotation = Quaternion.Euler(0, 0, angle);
                    newScythe.SetActive(true);
                    newScythe.GetComponent<Scythe>().damage = this.damage;
                }
            }
        }
    }
}
