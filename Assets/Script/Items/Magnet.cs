using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if(Crystal.crystals != null)
            {
                foreach(GameObject crystal in Crystal.crystals)
                {
                    if (crystal.GetComponent<Renderer>().isVisible)
                    {
                        crystal.GetComponent<Crystal>().isFollower = true;
                    }
                }

            }
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
