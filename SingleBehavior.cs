﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBehavior : StateMachineBehaviour
{
    private int rand;
    public float timer;
    public float minTime;
    public float maxTime;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            rand = Random.Range(0, 2);

            if (rand == 0)
            {
                animator.SetTrigger("Move");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
        else
        {
            timer = Time.deltaTime;
        }

        //code to fire selected weapon

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}