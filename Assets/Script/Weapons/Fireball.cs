using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : BaseWeapon
{
    public GameObject player;
    [SerializeField] int speed;
    Vector3 direction;
    private void Start()
    {
        direction = player.transform.localScale == new Vector3(1, 1, 1) ? Vector3.left : Vector3.right; 
    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        EnnemyCollision(collision, damage);
    }
}
