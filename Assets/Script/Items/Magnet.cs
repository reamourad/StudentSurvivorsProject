using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private float time = 20f;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] SpriteRenderer sprite;
    private bool hasTimeRunOut = false;
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
                sprite.enabled = false;
                boxCollider2D.enabled = false;
                
            }
            StartCoroutine(ShaderCoroutine(player));

        }
    }

    IEnumerator ShaderCoroutine(Player player)
    {
        for(float i = 0.5f; i > 0; i -= 0.01f)
        {
            player.material.SetFloat("_Flash", player.material.GetFloat("_Flash") + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        for (float i = 0.5f; i > 0; i -= 0.01f)
        {
            player.material.SetFloat("_Flash", player.material.GetFloat("_Flash") - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
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
