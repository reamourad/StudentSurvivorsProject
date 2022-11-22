using System.Collections;
using UnityEngine;
public class Giant : Ennemy
{
    enum GiantState
    {
        Idling,
        Chasing,
        Attacking,
        Berserk
    }
    GiantState currentState = GiantState.Idling;
    [SerializeField] GameObject knifeObject;
    Animator animator;
    float waitTime = 2f;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        if (player)
        {
            if (currentHP < (ennemyHP / 2))
            {
                currentState = GiantState.Berserk;
            }
            switch (currentState)
            {

                case GiantState.Idling:
                    waitTime -= Time.deltaTime;
                    if (waitTime <= 0)
                    {
                        currentState = GiantState.Chasing;
                    }
                    break;
                case GiantState.Chasing:
                    base.Update();
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    animator.SetBool("isWalking", true);
                    if (distance < 5f)
                    {
                        currentState = GiantState.Attacking;
                    }
                    break;
                case GiantState.Attacking:
                    animator.SetBool("isWalking", false);
                    animator.SetTrigger("Attack");
                    waitTime = 5f;
                    currentState = GiantState.Idling;
                    break;
                case GiantState.Berserk:
                    animator.SetTrigger("Attack");
                    waitTime = 5f;
                    waitTime -= Time.deltaTime;
                    if (waitTime <= 0)
                    {
                        animator.SetTrigger("Attack");
                    }
                    break;
            }
        }
        

    }


    public void SpawnKnife()
    {
        GameObject knife = Instantiate(knifeObject, transform.position, Quaternion.identity);
        knife.GetComponent<GiantKnife>().giant = gameObject;
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.OnDamage();
        }
    }

    internal override void Damage(int damage)
    {
        base.Damage(damage);
        currentState = GiantState.Idling;
    }
}