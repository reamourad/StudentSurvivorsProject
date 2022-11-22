using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantKnife : MonoBehaviour
{
    GameObject player;
    public GameObject giant;
    Vector3 destination;
    float adjacent;
    float opposite;
    float angle;
    [SerializeField] int speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destination = player.transform.position;

        //angle
        adjacent = transform.position.x - player.transform.position.x;
        opposite = transform.position.y - player.transform.position.y;
        angle = Mathf.Atan(opposite / adjacent);
        Debug.Log(angle * (180 / Mathf.PI));
        angle = angle * (180 / Mathf.PI);
        int scaleX = giant.transform.localScale.x == -1 ? 180 : 0;
        transform.Rotate(0, 0, angle + scaleX);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position += (transform.right * - 1)* Time.deltaTime * speed;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (player.OnDamage())
            {
                Destroy(gameObject);
            }
        }
    }
}
