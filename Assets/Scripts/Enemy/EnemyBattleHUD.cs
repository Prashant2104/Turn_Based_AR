using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattleHUD : MonoBehaviour
{
    public Text Name;
    public Slider Health;

    public void SetHUD(EnemyAI unit)
    {
        Name.text = unit.name;
        Health.maxValue = unit.MaxHP;
        Health.value = unit.CurrentHP;
    }
    public void SetHP(float hp)
    {        
        Health.value = hp;
    }
}