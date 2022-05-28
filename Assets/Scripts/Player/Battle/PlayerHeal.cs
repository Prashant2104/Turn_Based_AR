using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : PlayerUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerBattleController.battleSystem.DialogueText.text = "You used Heal...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            playerBattleController.battleSystem.DialogueText.text = "You heal yourself...";
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerBattleController.Heal.Stop();

        playerBattleController.CurrentHP += 10;
        if (playerBattleController.CurrentHP > playerBattleController.MaxHP)
            playerBattleController.CurrentHP = playerBattleController.MaxHP;

        playerBattleController.battleSystem.State = BattleState.EnemyTurn;
        playerBattleController.battleSystem.EnemyTurn();
    }
}