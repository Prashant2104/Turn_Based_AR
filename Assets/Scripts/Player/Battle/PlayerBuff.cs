using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : PlayerUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerBattleController.battleSystem.DialogueText.text = "You used buff...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            playerBattleController.battleSystem.DialogueText.text = "Your attack increased...";
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerBattleController.Buff.Stop();

        playerBattleController.MeleeDamage += 0.75f;
        playerBattleController.MagicDamage += 0.75f;

        playerBattleController.battleSystem.State = BattleState.EnemyTurn;
        playerBattleController.battleSystem.EnemyTurn();
    }
}