using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnits : StateMachineBehaviour
{
    public GameObject Player;
    public GameObject Opponent;
    public PlayerBattleController playerBattleController;

    float defence;
    float maxHP;
    float currentHP;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = animator.gameObject;
        playerBattleController = Player.GetComponent<PlayerBattleController>();
        Opponent = playerBattleController.Enemy;

        playerBattleController.OnAwake.Play();

        currentHP = playerBattleController.CurrentHP;
        maxHP = playerBattleController.MaxHP;
        defence = playerBattleController.MeleeDefence;
    }
    public bool TakeDamage(float Dmg)
    {
        currentHP -= (Dmg - defence);

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
}