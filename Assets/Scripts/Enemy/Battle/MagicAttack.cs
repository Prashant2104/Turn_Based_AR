using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : EnemyUnits
{
    public int a;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemyAI.transform.LookAt(Opponent.transform.position);
        animator.SetBool("Battle", true);

        a = Random.Range(1, 5);

        if (enemyAI.IsHeavy)
        {
            switch (a)
            {
                case 4:
                    animator.SetTrigger("Light");
                    break;
                case 1:
                    animator.SetTrigger("Defend");
                    break;
                case 2:
                    animator.SetTrigger("Buff");
                    break;
                case 3:
                    animator.SetTrigger("Heavy");
                    break;
            }
        }
        else
        {
            switch (a)
            {
                case 4:
                    animator.SetTrigger("Light");
                    break;
                case 1:
                    animator.SetTrigger("Defend");
                    break;
                case 2:
                    animator.SetTrigger("Buff");
                    break;
                case 3:
                    animator.SetTrigger("Light");
                    break;
            }
        }

        /*if (NPC.GetComponent<EnemyAI>().battleSystem.State != BattleState.Lost || NPC.GetComponent<EnemyAI>().battleSystem.State != BattleState.Won)
        {
            NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
        }*/
    }
}
