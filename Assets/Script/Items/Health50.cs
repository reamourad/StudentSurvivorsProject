using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health50 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.Add50Health();
            gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        StartCoroutine(DestroySelfCoroutine());
    }

    IEnumerator DestroySelfCoroutine()
    {

        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}
