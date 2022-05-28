using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleHUD : MonoBehaviour
{
    public Text Name;
    public Text HealthStat;
    public Slider Health;
    [SerializeField] float maxHP;
    public void SetHUD(PlayerBattleController unit)
    {
        //Name.text = unit.name;
        maxHP = unit.MaxHP;
        Health.maxValue = unit.MaxHP;
        Health.value = unit.CurrentHP;
        HealthStat.text = unit.CurrentHP + "/" + unit.MaxHP;
    }
    public void SetHP(float hp)
    {
        Health.value = hp;
        HealthStat.text = hp + "/" + maxHP;
    }
}
