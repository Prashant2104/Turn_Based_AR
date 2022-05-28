using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightMelee : PlayerUnits
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerBattleController.battleSystem.DialogueText.text = "You used light attack...";
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool isDead = Opponent.GetComponent<EnemyAI>().TakeMeleeDamage(playerBattleController.MeleeDamage);

        if (isDead)
        {
            playerBattleController.battleSystem.State = BattleState.Won;
            playerBattleController.battleSystem.EndBattle();
        }
        else
        {
            playerBattleController.battleSystem.State = BattleState.EnemyTurn;
            playerBattleController.battleSystem.EnemyTurn();
        }
    }
}
