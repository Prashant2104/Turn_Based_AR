using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


public class CombatGameManager : MonoBehaviour
{
    public GameObject enemies;
    public GameObject player;
    public GameObject ChoicePanel;
    public GameObject spawnPanel;
    private void Start()
    {
        enemies.SetActive(false);
        player.SetActive(false);
        ChoicePanel.SetActive(true);
    }

    public void EnemySelect(int _choice)
    {
        enemies.transform.GetChild(_choice).gameObject.SetActive(true);
        for(int i = 0; i < enemies.transform.childCount; i++)
        {
            if(i != _choice)
                enemies.transform.GetChild(i).gameObject.SetActive(false);
        }
        enemies.SetActive(true);
        player.SetActive(true);
        ChoicePanel.SetActive(false);
        spawnPanel.SetActive(true);
    }

    public void EnemyChoice_1()
    {
        EnemySelect(0);
    }
    public void EnemyChoice_2()
    {
        EnemySelect(1);
    }
    public void EnemyChoice_3()
    {
        EnemySelect(2);
    }
    public void EnemyChoice_4()
    {
        EnemySelect(3);
    }
    public void EnemyChoice_5()
    {
        EnemySelect(4);
    }
}