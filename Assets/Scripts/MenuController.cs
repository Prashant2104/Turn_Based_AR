using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject combatManager;
    public GameObject welcomePanel;
    void Start()
    {
        if(combatManager)
            combatManager.SetActive(false);
        if(welcomePanel)
            welcomePanel.SetActive(true);
    }
    public void OnCombatButtonCLick()
    {        
        combatManager.SetActive(true);
        welcomePanel.SetActive(false);
    }
    public void OnFreeRoamButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
