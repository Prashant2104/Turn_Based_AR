using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<BattleSystem>().enabled = true;
    }
}