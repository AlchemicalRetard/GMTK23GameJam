using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreAtEndScreenText;

    [SerializeField] bool isPlayerDead;
    [SerializeField] int score;

    public GameObject endPanel;
    public GameObject statsPanel;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        scoreText.text = score.ToString();

        endPanel.SetActive(false);
        statsPanel.SetActive(true);
    }

    public GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            }
            if (!pausePanel.activeSelf)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("A_MainMenu");
    }

    public void AddScore(int value)
    {

        score += value;


        if (PlayerPrefs.GetInt("highScore") < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        scoreText.text = score.ToString();
    }

    public void EnableDeathUI()
    {
        statsPanel.SetActive(false);
        endPanel.SetActive(true);
        scoreAtEndScreenText.text = score.ToString();
        Time.timeScale = 0;
    }




}