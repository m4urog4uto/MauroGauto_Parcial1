using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] PlayerBase player;

    public void Update()
    {
        if (player != null && healthSlider.value != player.Health)
        {
            healthSlider.value = player.Health;
        }
    }
}
