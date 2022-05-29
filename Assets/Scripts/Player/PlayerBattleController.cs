using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour
{
    //public GameObject PlayerOG;
    public GameObject Enemy;
    public BattleSystem battleSystem;
    public GameObject DeathPanel;

    private Animator anim;

    [Header("Battle Stats")]
    public float MeleeDamage;
    public float MagicDamage;
    public float MeleeDefence;
    public float MagicDefence;

    [Header("Actual Stats")]
    public float MeleeDam;
    public float MagicDam;
    public float MeleeDef;
    public float MagicDef;

    [Header("Health")]
    public float MaxHP;
    public float CurrentHP;

    [Header("Particle System")]
    public ParticleSystem OnAwake;
    public ParticleSystem LightMagicAttack;
    public ParticleSystem HeavyMagicAttack;
    public ParticleSystem Defence;
    public ParticleSystem Buff;
    public ParticleSystem Heal;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        battleSystem = FindObjectOfType<BattleSystem>();
    }

    private void OnEnable()
    {
        MeleeDamage = MeleeDam;
        MeleeDefence = MeleeDef;
        MagicDamage = MagicDam;
        MagicDefence = MagicDef;

        //this.gameObject.transform.position = PlayerOG.transform.position;
        battleSystem.Player_GO = this.gameObject;
        Enemy = battleSystem.Enemy_GO;
        this.transform.LookAt(Enemy.transform);
    }
    public bool TakeMeleeDamage(float Dmg)
    {
        CurrentHP -= (Dmg - MeleeDefence);

        battleSystem.PlayerHUD.SetHP(CurrentHP);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
    public bool TakeMagicDamage(float Dmg)
    {
        CurrentHP -= (Dmg - MagicDefence);

        battleSystem.PlayerHUD.SetHP(CurrentHP);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
    public void HUD()
    {
        battleSystem.PlayerHUD.SetHP(CurrentHP);
    }
    public void LightMagicVFX()
    {
        LightMagicAttack.Play();
    }
    public void HeavyMagicVFX()
    {
        HeavyMagicAttack.Play(true);
    }

    IEnumerator VFX_Stop()
    {
        yield return new WaitForSeconds(1f);
        HeavyMagicAttack.Stop();
    }
    public void DefenceVFX()
    {
        Defence.Play();
    }
    public void BuffVFX()
    {
        Buff.Play();
    }
    public void HealVFX()
    {
        Heal.Play();
    }
    public void Death()
    {
        DeathPanel.SetActive(true);
    }
}