using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnits : StateMachineBehaviour
{
    public GameObject thisEnemy;
    public GameObject Opponent;
    public EnemyAI enemyAI;

    //float currentHP;
    //float maxHP;
    //float magicDefence;
    //float meleeDefence;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject;
        enemyAI = thisEnemy.GetComponent<EnemyAI>();
        Opponent = enemyAI.battleSystem.Player_GO;
    }
}