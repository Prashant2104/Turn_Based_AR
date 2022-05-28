using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : EnemyUnits
{
    [SerializeField] int attackPick;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        thisEnemy.transform.LookAt(Opponent.transform.position);

        enemyAI.OnAwake.Play();

        animator.SetBool("Battle", true);

        if (enemyAI.IsBoss)
        {
            if (!thisEnemy.GetComponent<AudioSource>().isPlaying)
                thisEnemy.GetComponent<AudioSource>().Play();
        }

        attackPick = Random.Range(1, 5);
        if (attackPick == 1)
        {
            if (enemyAI.MeleeDefence + 2f >= Opponent.GetComponent<PlayerBattleController>().MeleeDamage ||
                        enemyAI.MagicDefence + 2f >= Opponent.GetComponent<PlayerBattleController>().MagicDamage)
            {
                attackPick = 4;
            }
        }

        if (enemyAI.IsMelee)
        {
            if (enemyAI.IsHeavy)
            {
                switch (attackPick)
                {
                    case 1:
                        animator.SetTrigger("Light");
                        break;
                    case 2:
                        animator.SetTrigger("DefendB");
                        break;
                    case 3:
                        animator.SetTrigger("Buff");
                        break;
                    case 4:
                        animator.SetTrigger("Heavy");
                        break;
                }
            }
            else
            {                
                switch (attackPick)
                {
                    case 1:
                        animator.SetTrigger("Light");
                        break;
                    case 2:
                        animator.SetTrigger("DefendK");
                        break;
                    case 3:
                        animator.SetTrigger("Buff");
                        break;
                    case 4
                    :
                        animator.SetTrigger("Light");
                        break;
                }
            }
        }

        else if (enemyAI.IsMagic)
        {
            if (enemyAI.IsHeavy)
            {
                switch (attackPick)
                {
                    case 1:
                        animator.SetTrigger("Light");
                        break;
                    case 2:
                        animator.SetTrigger("Defend");
                        break;
                    case 3:
                        animator.SetTrigger("Buff");
                        break;
                    case 4:
                        animator.SetTrigger("Heavy");
                        break;
                }
            }
            else
            {
                switch (attackPick)
                {
                    case 1:
                        animator.SetTrigger("Light");
                        break;
                    case 2:
                        animator.SetTrigger("Defend");
                        break;
                    case 3:
                        animator.SetTrigger("Buff");
                        break;
                    case 4:
                        animator.SetTrigger("Light");
                        break;
                }
            }
        }

        else if (enemyAI.IsBoss)
        {
            int x = Random.Range(1, 3);
            switch (attackPick)
            {
                case 1:
                    if(x == 1)
                        animator.SetTrigger("LightMelee");
                    if(x ==2 )
                        animator.SetTrigger("LightMagic");
                    break;

                case 2:
                    animator.SetTrigger("Defend");
                    break;

                case 3:
                    animator.SetTrigger("Buff");
                    break;

                case 4:
                    if (x == 1)
                        animator.SetTrigger("HeavyMelee");
                    if (x == 2)
                        animator.SetTrigger("HeavyMagic");
                    break;
            }
        }
        /*if (NPC.GetComponent<EnemyAI>().battleSystem.State != BattleState.Lost || NPC.GetComponent<EnemyAI>().battleSystem.State != BattleState.Won)
        {
            NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
        }*/
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy.transform.LookAt(Opponent.transform.position);
    }
}