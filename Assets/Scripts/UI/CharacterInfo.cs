using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public static CharacterInfo instance;

    Transform healthContainer;
    Image healthBar;
    Text healthText;

    void Awake()
    {
        instance = this;
        healthContainer = transform.Find("HealthBarContainer");
        healthBar = healthContainer.Find("HealthBar").GetComponent<Image>();
        healthText = healthContainer.Find("Text").GetComponent<Text>();
    }

    public void SetHealth(int health, int maxHealth)
    {
        healthBar.fillAmount = ((float)health) / ((float)maxHealth);
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
    }

}
