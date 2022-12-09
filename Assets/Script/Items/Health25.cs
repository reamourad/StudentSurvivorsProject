using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health25 : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] SpriteRenderer sprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.Add25Health();
            boxCollider2D.enabled = false;
            sprite.enabled = false;
            StartCoroutine(ShaderCoroutine(player));
        }
    }

    IEnumerator ShaderCoroutine(Player player)
    {
        for (float i = 0.5f; i > 0; i -= 0.01f)
        {
            player.material.SetFloat("_Flash2", player.material.GetFloat("_Flash2") + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        for (float i = 0.5f; i > 0; i -= 0.01f)
        {
            player.material.SetFloat("_Flash2", player.material.GetFloat("_Flash2") - 0.01f);
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
