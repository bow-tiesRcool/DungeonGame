using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBehavior : StateMachineBehaviour
{

    private int rand;
    public float timer;
    public float minTime;
    public float maxTime;

    private Transform playerPos;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            rand = Random.Range(0, 3);

            if (rand == 0)
            {
                animator.SetTrigger("Triple");
            }
            else if (rand == 1)
            {
                animator.SetTrigger("Sniper");
            }
            else
            {
                animator.SetTrigger("Spread");
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }

        //code to chase the player
        Vector2 target = new Vector2(playerPos.position.x, playerPos.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
