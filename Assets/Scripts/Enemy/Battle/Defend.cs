using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : EnemyUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemyAI.battleSystem.DialogueText.text = "Enemy used Defence...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if(timer >= 0.7f)
        {
            enemyAI.battleSystem.DialogueText.text = "Enemy's defence increased...";
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyAI.Defence.Stop();

        if (enemyAI.IsMelee && !enemyAI.IsMagic)
        {
            enemyAI.MeleeDefence += 1.5f;
            enemyAI.MagicDefence += 1.0f;
        }
        else if (!enemyAI.IsMelee && enemyAI.IsMagic)
        {
            enemyAI.MeleeDefence += 1.0f;
            enemyAI.MagicDefence += 1.5f;
        }
        else if (enemyAI.IsMelee && enemyAI.IsMagic)
        {
            enemyAI.MeleeDefence += 1.5f;
            enemyAI.MagicDefence += 1.5f;
        }

        enemyAI.battleSystem.DialogueText.text = "Choose an action...";
        enemyAI.battleSystem.State = BattleState.PlayerTurn;

        animator.SetTrigger("Attack");
    }
}