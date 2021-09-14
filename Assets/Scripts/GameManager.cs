using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject DeathUI;
    public GameObject InGameUI;
    private bool isRestart;

    private void Awake()
    {
        if (!isRestart)
        {
            MainMenuUI.SetActive(true);
        }
        else
        {
            MainMenuUI.SetActive(false);
        }
        Time.timeScale= 0;
    }

    private void FixedUpdate()
    {

    }

    public void StartGame()
    {
        MainMenuUI.SetActive(false);
        InGameUI.SetActive(true);
        Time.timeScale= 1;
    }

    public void RestartGame()
    {
        isRestart = true;
        Time.timeScale= 1;
        DeathUI.SetActive(false);
        SceneManager.LoadScene("Main");
    }
}
