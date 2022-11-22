using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : BaseWeapon
{
    public GameObject player;
    [SerializeField] GameObject fireBall;

    private void Start()
    {
        StartCoroutine(SpawnFireball());
    }
    IEnumerator SpawnFireball()
    {
        while (player)
        {
            var fire = Instantiate(fireBall, player.transform.position, Quaternion.identity);
            fire.GetComponent<Fireball>().damage = this.damage;
            fire.GetComponent<Fireball>().player = this.player;
            fire.transform.localScale += new Vector3(0.5f * level, 0.5f * level, 0.5f * level);
            yield return new WaitForSeconds(1f);
        }
    }
}
