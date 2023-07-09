using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int rageMultiplier;
    [SerializeField] int waveNumber;
    int currentRage;
    int maxRage;

    bool isPlayerDead;
    bool isInRage;
    int score;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int value)
    {
        if (isInRage)
        {
            score += value * rageMultiplier;
        }
        else
        {
            score += value;
        }
    }

    public void AddRage(int value)
    {
        if (currentRage < maxRage)
        {
            currentRage += value;
        }
    }
}
