using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int rageScoreMultiplier;

    [SerializeField] bool isPlayerDead;
    [SerializeField] int score;

    
    public bool isInRage;
    [SerializeField] float currentRage;
    [SerializeField] int maxRage = 1000;
    [SerializeField] private bool canRage;
    [SerializeField] Slider rageSlider;

    [SerializeField] int rageWhenKill = 100;
    [SerializeField] int rageWhenHit = 300;
    [SerializeField] int rageWhenEggsplosion = 200;

    int[] rageArray = new int[2];

    private PlayerMovement playerMovement;
    private PlayerShooting playerShooting;

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

    void Start()
    {
        rageArray = new int[] {rageWhenHit,rageWhenKill};
    }

    public void AddScore(int value)
    {
        if (isInRage)
        {
            score += value * rageScoreMultiplier;
        }
        else
        {
            score += value;
        }

        if (PlayerPrefs.GetInt("highScore") < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void AddRage(RageType rageType)
    {
        /*if (currentRage < maxRage)
        {
            switch (rageType)
            {
                case RageType.GetHit:
                    currentRage += rageArray[(int)RageType.GetHit];
                    break;
                case RageType.KillEnemy:
                    currentRage += rageArray[(int)RageType.KillEnemy];
                    break;
                case RageType.Explosion:
                    currentRage += rageArray[(int)RageType.Explosion];
                    break;
            }
            rageSlider.value = currentRage;
        }
        if (currentRage >= maxRage)
        {
            canRage = true;
            return;
        }
    */
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canRage)
        {
            isInRage = true;
            
            playerMovement.StartRage();
            playerShooting.StartRage();

            canRage = false;
        }
        ConsumeRage();
    }

    private void ConsumeRage()
    {
        if (isInRage)
        {

            // start Rage
            currentRage -= Time.deltaTime;
            rageSlider.value = currentRage;

            if (currentRage <= 0)
            {
                currentRage = 0;
                GameManager.Instance.isInRage = false;
                playerMovement.EndRage();
                playerShooting.EndRage();
            }
        }
    }
}
public enum RageType
{
    GetHit, //0
    KillEnemy, //0
    Explosion, //0
}