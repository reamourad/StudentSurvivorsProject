using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (player.OnDamage())
            {
                //Destroy(gameObject);
            }
        }
    }
}
