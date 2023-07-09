using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarUI : MonoBehaviour
{
    public Slider slider;
    public Color healthColor;
    public Vector3 offset;

    public bool isPlayer;

    private void Start()
    {
        if(!isPlayer)
            slider.gameObject.SetActive(false);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color = healthColor;
        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high,slider.normalizedValue);
        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(high, low,slider.normalizedValue);
    }

   
}
