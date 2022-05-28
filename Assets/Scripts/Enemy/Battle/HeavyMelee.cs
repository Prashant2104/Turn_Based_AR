using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMelee : EnemyUnits
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemyAI.battleSystem.DialogueText.text = "Enemy used Heavy attack...";
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetTrigger("Attack");
        bool isDead = Opponent.GetComponent<PlayerBattleController>().TakeMeleeDamage(enemyAI.MeleeDamage * 1.5f);

        if (isDead)
        {
            //GameOver
            enemyAI.battleSystem.State = BattleState.Lost;
            enemyAI.battleSystem.EndBattle();
        }
        else
        {
            enemyAI.battleSystem.DialogueText.text = "Choose an action...";
            enemyAI.battleSystem.State = BattleState.PlayerTurn;
        }
    }
}
