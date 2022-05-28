using UnityEngine;

public class Buff : EnemyUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemyAI.battleSystem.DialogueText.text = "Enemy used Buff...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            enemyAI.battleSystem.DialogueText.text = "Enemy's attack increased...";
        }        
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyAI.Buff.Stop();

        if (enemyAI.IsMelee && !enemyAI.IsMagic)
        {
            enemyAI.MeleeDamage += 1.0f;
            enemyAI.MagicDamage += 0.5f;
        }
        else if (!enemyAI.IsMelee && enemyAI.IsMagic)
        {
            enemyAI.MeleeDamage += 0.5f;
            enemyAI.MagicDamage += 1.0f;
        }
        else if (enemyAI.IsMelee && enemyAI.IsMagic)
        {
            enemyAI.MeleeDamage += 1.0f;
            enemyAI.MagicDamage += 1.0f;
        }

        enemyAI.battleSystem.DialogueText.text = "Choose an action...";
        enemyAI.battleSystem.State = BattleState.PlayerTurn;

        animator.SetTrigger("Attack");
    }
}