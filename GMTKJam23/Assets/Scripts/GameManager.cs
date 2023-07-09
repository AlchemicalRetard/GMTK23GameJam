using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] bool isPlayerDead;
    [SerializeField] int score;





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


    public void AddScore(int value)
    {

        score += value;


        if (PlayerPrefs.GetInt("highScore") < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }




}