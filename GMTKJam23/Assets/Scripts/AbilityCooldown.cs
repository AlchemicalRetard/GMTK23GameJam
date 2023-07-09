using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityCooldown : MonoBehaviour
{
    public Image eggImage;
    public TextMeshProUGUI eggText;
    public KeyCode eggKey;
    public float eggCooldown = 10;

    public bool isEggCooldown = false;

    private float currentEggCooldown;

    private void Start()
    {
        eggImage.fillAmount = 0;
        eggText.text = "";
    }

    private void Update()
    {
        EggInput();

        AbilityCD(ref currentEggCooldown, eggCooldown, ref isEggCooldown, eggImage, eggText);
    }

    void EggInput()
    {
        if (Input.GetKeyDown(eggKey) && !isEggCooldown)
        {
            isEggCooldown = true;
            currentEggCooldown = eggCooldown;
        }
    }

    void AbilityCD(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, TextMeshProUGUI skillText)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;

                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
