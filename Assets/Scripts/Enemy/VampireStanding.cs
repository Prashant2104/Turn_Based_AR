using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireStanding : EnemyUnits
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemyAI.transform.LookAt(Opponent.transform.position);
    }
}
