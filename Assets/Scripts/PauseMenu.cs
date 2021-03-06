﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameMaster GM;
    public GameObject GMobj;

    public static bool isPaused;
    bool isDead = false;
    public GameObject pauseMenuUI;
    public GameObject gameUI;
    public GameObject deathUI;
    public GameObject winUI;

    void Start()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        if (GM.enemiesKilled == GM.enemiesOnLevel)
        {
            WinnerIsYou();
        }
    }

    public void Resume()
    {
        if (isDead == false)
        {
            pauseMenuUI.SetActive(false);
            gameUI.SetActive(true);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Pause()
    {
        if (isDead == false)
        {
            pauseMenuUI.SetActive(true);
            gameUI.SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void DeathScreen()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(false);
        deathUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        isDead = true;
    }

    public void WinnerIsYou()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(false);
        deathUI.SetActive(false);
        winUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        isDead = true;
    }
}
