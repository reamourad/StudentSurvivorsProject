using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : BaseWeapon
{
    float angle = 0;
    float speed = (2 * Mathf.PI) / 2;
    float radius = 3;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider2D;

    private void Start()
    {
        transform.position = player.transform.position;
        StartCoroutine(EnergyBallCoroutine());
    }

    void Update()
    {
        //movement of the ball
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius + player.transform.position.x;
        float y = Mathf.Sin(angle) * radius + player.transform.position.y;
        transform.position = new Vector3(x, y, 0);
    }

    IEnumerator EnergyBallCoroutine()
    {
        while (true)
        {
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(5f);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(2f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnnemyCollision(collision, damage);
    }
}
