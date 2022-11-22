using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public bool isFollower = false;
    private GameObject player;
    public static List<GameObject> crystals = new List<GameObject>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        crystals.Add(gameObject);
    }

    private void Update()
    {
        if (isFollower)
        {
            if (player)
            {
                //Follow the player
                Vector3 destination = player.transform.position;
                Vector3 source = transform.position;
                Vector3 direction = destination - source;
                direction.Normalize();
                transform.position += direction * Time.deltaTime * 5f;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.AddExp();
            crystals.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
