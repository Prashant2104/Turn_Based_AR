using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefend : PlayerUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerBattleController.battleSystem.DialogueText.text = "You used Defence...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            playerBattleController.battleSystem.DialogueText.text = "Your Defence increased...";
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerBattleController.Defence.Stop();

        playerBattleController.MeleeDefence += 1.25f;
        playerBattleController.MagicDefence += 1.25f;

        playerBattleController.battleSystem.State = BattleState.EnemyTurn;
        playerBattleController.battleSystem.EnemyTurn();
    }
}