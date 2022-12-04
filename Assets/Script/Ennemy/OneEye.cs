using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEye : Ennemy
{
    enum OneEyeState
    {
        Idling,
        Walking,
        Attacking
    }
    OneEyeState currentState = OneEyeState.Walking;
    Animator animator;
    float waitTime = 2f;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        switch (currentState)
        {
            case OneEyeState.Idling:
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    currentState = OneEyeState.Walking;
                }
                break;
            case OneEyeState.Walking:
                base.Update();
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                if (distance < 1f)
                {
                    currentState = OneEyeState.Attacking;
                }
                break;
            case OneEyeState.Attacking:
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                waitTime = 5f;
                currentState = OneEyeState.Idling;
                break;
        }
    }
}
