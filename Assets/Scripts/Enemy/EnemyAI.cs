using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public BattleSystem battleSystem;
    public GameObject Player;
    private Animator anim;

    [Header("Class")]
    public bool IsHeavy;
    public bool IsMelee;
    public bool IsMagic;
    public bool IsBoss;

    [Header("Stats")]
    public float MeleeDamage;
    public float MagicDamage;
    public float MeleeDefence;
    public float MagicDefence;

    [Header("Health")]
    public float MaxHP;
    public float CurrentHP;

    [Header("Particle System")]
    public ParticleSystem OnAwake;
    public GameObject LightMagicAttack;
    public GameObject HeavyMagicAttack_Parent;
    public ParticleSystem HeavyMagicAttack;
    public ParticleSystem Defence;
    public ParticleSystem Buff;

    private void Start()
    {
        battleSystem = FindObjectOfType<BattleSystem>();
        anim = GetComponent<Animator>();
        Player = battleSystem.Player_GO;
        battleSystem.Enemy_GO = this.gameObject;
        battleSystem.enabled = true;
    }
    private void OnEnable()
    {
    }
    public GameObject GetPlayer()
    {
        return Player;
    }
    public bool TakeMeleeDamage(float dmg)
    {
        CurrentHP -= (dmg - MeleeDefence);

        battleSystem.EnemyHUD.SetHP(CurrentHP);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
    public bool TakeMagicDamage(float dmg)
    {
        CurrentHP -= (dmg - MagicDefence);

        battleSystem.EnemyHUD.SetHP(CurrentHP);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
    public void LightMagicVFX()
    {
        LightMagicAttack.transform.LookAt(battleSystem.Player_GO.transform.position);
        LightMagicAttack.SetActive(true);
    }
    public void HeavyMagicVFX()
    {
        HeavyMagicAttack.Play(true);
    }
    public void DefenceVFX()
    {
        Defence.Play();
    }
    public void BuffVFX()
    {
        Buff.Play();
    }
}