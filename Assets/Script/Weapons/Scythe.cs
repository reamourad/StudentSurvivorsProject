using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : BaseWeapon
{

    private void Start()
    {
        StartCoroutine(ScytheCoroutine());
    }
    private void Update()
    {
        transform.position += transform.up * 5 * Time.deltaTime;
    }

    IEnumerator ScytheCoroutine()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnnemyCollision(collision, damage);
    }
}
